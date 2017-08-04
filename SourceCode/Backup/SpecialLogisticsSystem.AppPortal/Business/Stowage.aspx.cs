using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.UserControl;
using SpecialLogisticsSystem.Model;
using DevExpress.Web.Data;
using DevExpress.Web.ASPxGridView;
using System.ComponentModel;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.Business
{
    public partial class Stowage : BasePage<Stowage>
    {
        [Dependency]
        public IWayBillDal _way { get; set; }
        [Dependency]
        public IStowageMainDal _stowaye { get; set; }
        [Dependency]
        public IStowageDetailDal _stowaye_detail { get; set; }
        [Dependency]
        public ICmCustomerDal _customer { get; set; }
        [Dependency]
        public IArrivalMainDal _arrival { get; set; }
        [Dependency]
        public IFinanceDriverDal _finance_driver { get; set; }
        [Dependency]
        public IFinanceDailyDal _finance_daily { get; set; }
        [Dependency]
        public ICmCarDal _car { get; set; }
        [Dependency]
        public ICmLinkDal _link { get; set; }

        private static string strSeeionID = "id";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.Stowage;
                }
                if (null != Session[Constants.StowageDetail])
                {
                    Session[Constants.StowageDetail] = null;
                }
            }
        }

        #region 发车单

        protected void gridStowage_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            List<object> ids = gridStowage.GetSelectedFieldValues(gridStowage.KeyFieldName);
            switch (e.Parameters)
            {
                case "confirm":
                    foreach (var id in ids)
                    {
                        T_Stowage_Main stowage = _stowaye.GetSingle(id);
                        stowage.stowage_statue = StowageStatue.Sended.ToString();
                        IList<T_Stowage_Detail> detailList = _stowaye_detail.GetList(
                            new QueryInfo<T_Stowage_Detail>().SetQuery(T_Stowage_Detail.MainIdColumnName, id));
                        foreach (var detail in detailList)
                        {
                            T_Way_Bill way = _way.GetSingle(detail.bill_id);
                            way.bill_statue = WayStatue.Sended.ToString();
                            _way.Update(way);
                        }
                        _stowaye.Update(stowage);
                        productionList.Refrsh();
                    }
                    break;
                default:
                    break;
            }
            gridStowage.DataBind();
        }

        protected void stowageDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridStowage.FilterExpression))
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(gridStowage.FilterExpression) ? gridStowage.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
        }

        protected void gridStowage_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            Session[Constants.StowageDetail] = null;
        }

        protected void gridStowage_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            //1. 保存发车信息 2. 保存运单
            T_Stowage_Main stowage = new T_Stowage_Main();
            UIHelpers.TryUpdateModel<T_Stowage_Main>.ToUpdateModel(stowage, gridStowage);
            stowage.id = Guid.NewGuid();
            stowage.stowage_statue = WayStatue.UnSend.ToString();
            stowage.emp_id = UserProvide.GetCurrentEmpId().Value;
            stowage.car_id = SaveCar(stowage);
            _stowaye.Insert(stowage);
            //运单
            var detailList = Session[Constants.StowageDetail] as List<T_Stowage_Detail>;
            if (detailList != null)
            {
                detailList.ForEach((p) =>
                {
                    p.main_id = stowage.id;
                    _stowaye_detail.Insert(p);
                });
                Session[Constants.StowageDetail] = null;
            }
            FinishGrid(e);
            gridStowage.JSProperties[Constants.strCpShowPopup] = "/Reports/ReportStowage.aspx?id=" + stowage.id.ToString();
        }

        protected void gridStowage_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            T_Stowage_Main stowage = _stowaye.GetSingle(e.Keys[0]);
            UIHelpers.TryUpdateModel<T_Stowage_Main>.ToUpdateModel(stowage, gridStowage);
            SaveCar(stowage);
            _stowaye.Update(stowage);
            ////货物 先删除 后添加（因为不清楚是新增或修改）
            //_stowaye_detail.DeleteByWay(stowage.id);
            QueryInfo<T_Stowage_Detail> queryInfo = new QueryInfo<T_Stowage_Detail>();
            queryInfo.SetQuery(T_Stowage_Detail.MainIdColumnName, stowage.id);
            List<T_Stowage_Detail> oldDetailList = _stowaye_detail.GetList(queryInfo).ToList();
            List<T_Stowage_Detail> detailList = Session[Constants.StowageDetail] as List<T_Stowage_Detail>;
            SequenceCalculator<T_Stowage_Detail> cal = new SequenceCalculator<T_Stowage_Detail>(oldDetailList, detailList);
            if (cal.ToBeDeletedSequence.Count > 0)
            {
                _stowaye_detail.Delete(cal.ToBeDeletedSequence.Select(p => p.id).ToList());
            }
            foreach (var item in cal.ToBeUpdatedSequence)
            {
                _stowaye_detail.Update(item);
            }
            foreach (var item in cal.ToBeInsertedSequence)
            {
                item.main_id = stowage.id;
                _stowaye_detail.Insert(item);
            }
            Session[Constants.StowageDetail] = null;
            FinishGrid(e);
        }

        protected Guid SaveCar(T_Stowage_Main main)
        {
            bool isAdd = (main.car_id == null || main.car_id==Guid.Empty);
            Guid id = isAdd ? Guid.NewGuid() : main.car_id;
            if (isAdd)
            {
                T_Cm_Link link = new T_Cm_Link();
                link.id = Guid.NewGuid();
                link.link_name = main.link_name;
                link.link_mobilephone = main.link_mobilephone;

                T_Cm_Car car = new T_Cm_Car();
                car.id = id;
                car.car_no = main.car_no;
                car.link = link;
                _car.Insert(car);
            }
            else
            {
                T_Cm_Car car = _car.GetSingle(id);
                T_Cm_Link link = _link.GetSingle(car.car_link);
                link.link_name = main.link_name;
                link.link_mobilephone = main.link_mobilephone;

                car.car_no = main.car_no;
                car.link = link;
                _car.Update(car);
            }
            return id;
        }

        protected void gridStowage_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            List<object> idAndCodes = gridStowage.GetSelectedFieldValues(new string[] { gridStowage.KeyFieldName, T_Stowage_Main.StowageNumberColumnName, T_Stowage_Main.StowageStatueColumnName });
            foreach (object[] id_code in idAndCodes)
            {
                var id = id_code[0];
                var code = id_code[1].ToString();
                var statue = id_code[2].ToString();
                if (statue != StowageStatue.UnSend.ToString())
                {
                    ErrorGrid("已发车，无法删除！", e);
                    return;
                }
                //到货管理
                IList<T_Arrival_Main> arrivalList = _arrival.GetList(new QueryInfo<T_Arrival_Main>().SetQuery(T_Arrival_Main.StowageIDColumnName, id));
                if (arrivalList.Count > 0)
                {
                    ErrorGrid(code, AttributesHelper.GetDisplayNameAttributes(typeof(T_Arrival_Main)), e);
                    return;
                }
                //与司机结算
                IList<T_Finance_Driver> driverList = _finance_driver.GetList(new QueryInfo<T_Finance_Driver>().SetQuery(T_Finance_Driver.StowageIdColumnName, id));
                if (driverList.Count > 0)
                {
                    ErrorGrid(code, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Driver)), e);
                    return;
                }
                //与日常结算
                IList<T_Finance_Daily> dailyList = _finance_daily.GetList(new QueryInfo<T_Finance_Daily>().SetQuery(T_Finance_Daily.StowageIdColumnName, id));
                if (dailyList.Count > 0)
                {
                    ErrorGrid(code, AttributesHelper.GetDisplayNameAttributes(typeof(T_Finance_Daily)), e);
                    return;
                }
            }
            List<object> stowageIds = gridStowage.GetSelectedFieldValues(gridStowage.KeyFieldName);
            _stowaye.Delete(stowageIds);
            FinishGrid(e);
            gridStowage.DataBind();
            gridStowage.JSProperties[Constants.strCpMessage] = Constants.strSuccessMessage;
        }

        private void ErrorGrid(string message, CancelEventArgs e)
        {
            gridStowage.JSProperties[Constants.strCpMessage] = message;
            FinishGrid(e);
        }
        private void ErrorGrid(string stowage_number, string other_name, CancelEventArgs e)
        {
            string message = string.Format(Constants.strCannotDelete, stowage_number, other_name);
            ErrorGrid(message, e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridStowage.CancelEdit();
            gridStowage.DataBind();
            productionList.Refrsh();
        }

        protected void gridStowage_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as SpecialLogisticsSystem.UserControl.ASPxGridView;
            var gridStowageDetail = grid.FindEditFormTemplateControl("gridStowageDetail") as SpecialLogisticsSystem.UserControl.ASPxGridView;
            if (!grid.IsNewRowEditing)
            {
                object id = grid.GetRowValues(grid.EditingRowVisibleIndex, grid.KeyFieldName);
                UpdateControll<T_Stowage_Main>.SetValueToControl(grid);
                List<T_Stowage_Detail> cList = Session[Constants.StowageDetail] as List<T_Stowage_Detail>;
                if (Session[strSeeionID] != null && id.ToString() != Session[strSeeionID].ToString())
                {
                    Session[Constants.StowageDetail] = null;
                    cList = null;
                }
                Session[strSeeionID] = id;
                if (cList == null)
                {
                    QueryInfo<T_Stowage_Detail> queryInfo = new QueryInfo<T_Stowage_Detail>();
                    queryInfo.SetQuery(T_Stowage_Detail.MainIdColumnName, id);
                    List<T_Stowage_Detail> productionList = _stowaye_detail.GetList(queryInfo).ToList();
                    Session[Constants.StowageDetail] = productionList;
                }
                gridStowageDetail.DataBind();
            }
        }
        #endregion

        #region 运单信息
        protected void gridStowageDetail_Load(object sender, EventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            var id = grid.GetMasterRowKeyValue();
            QueryInfo<T_Stowage_Detail> queryInfo = new QueryInfo<T_Stowage_Detail>();
            queryInfo.SetQuery("main_id", id);
            grid.DataSource = _stowaye_detail.Select(queryInfo);
            grid.DataBind();
        }
        #endregion
    }
}
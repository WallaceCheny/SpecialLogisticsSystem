using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using DevExpress.Web.ASPxGridView;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using DevExpress.Web.Data;

namespace SpecialLogisticsSystem.AppPortal.Business
{
    public partial class Arrival : BasePage<Arrival>
    {
        [Dependency]
        public IWayBillDal _way { get; set; }
        [Dependency]
        public IArrivalMainDal _arrival { get; set; }
        [Dependency]
        public IWayProductionDal _way_production { get; set; }
        [Dependency]
        public IStowageMainDal _stowage { get; set; }
        [Dependency]
        public IStowageDetailDal _stowage_detail { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.Arrival;
                }
            }
        }
        protected void gridWay_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            Session[Constants.StowageDetail] = null;
        }

        protected void gridWay_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            //1. 更改货物状态已到达 2. 更改汽车状态为已到达 3.保存到货信息
            var StowageList = Session[Constants.StowageDetail] as List<T_Stowage_Detail>;
            foreach (var item in StowageList)
            {
                T_Way_Production production = _way_production.GetSingle(item.production_id);
                if (null != production)
                {
                    T_Way_Bill way = _way.GetSingle(production.bill_id);
                    way.bill_statue = WayStatue.Arrival.ToString();
                    _way.Update(way);
                }
            }
            Guid stowageId = StowageList.FirstOrDefault().main_id;
            var stowage = _stowage.GetSingle(stowageId);
            if (null != stowage)
            {
                stowage.stowage_statue = StowageStatue.Arrival.ToString();
                _stowage.Update(stowage);
            }
            T_Arrival_Main main = new T_Arrival_Main();
            UIHelpers.TryUpdateModel<T_Arrival_Main>.ToUpdateModel(main, gridWay);
            main.id = Guid.NewGuid();
            main.stowage_id = stowageId;
            main.emp_id = UserProvide.GetCurrentEmpId().Value;
            _arrival.Insert(main);
            gridWay.DataBind();
            ProductionListByCar1.Refresh();
            e.Cancel = true;
            gridWay.CancelEdit();
        }

        protected void gridWay_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            List<object> ids = gridWay.GetSelectedFieldValues(gridWay.KeyFieldName);
            switch (e.Parameters)
            {
                case "confirm":
                    foreach (var id in ids)
                    {
                        T_Way_Bill way = _way.GetSingle(id);
                        way.bill_statue = WayStatue.Arrival.ToString();
                        _way.Update(way);
                    }
                    break;
                case "save_popup":
                    var gridId = ids.FirstOrDefault();
                    T_Way_Bill wayModel = _way.GetSingle(gridId);
                    wayModel.bill_statue = WayStatue.Received.ToString();
                    _way.Update(wayModel);
                    bool isSuccess = ProductionSign1.Save(gridId);
                    gridWay.JSProperties["cp_PopupMsg"] = isSuccess ? "保存成功！" : "保存失败！";
                    break;
                default:
                    break;
            }
            gridWay.DataBind();
        }

        protected void wayDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridWay.FilterExpression))
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(gridWay.FilterExpression) ? gridWay.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.IDal;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.Model;
using DevExpress.Web.Data;
using System.ComponentModel;
using SpecialLogisticsSystem.AppPortal.UserControls;
using DevExpress.Web.ASPxGridView;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using Newtonsoft.Json;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class Car : BasePage<Car>
    {
        [Dependency]
        public ICmCarDal _car { get; set; }
        [Dependency]
        public ICmLinkDal _link { get; set; }
        [Dependency]
        public IStowageMainDal _stowage { get; set; }
        [Dependency]
        public IArrivalDeliverDal _arrival { get; set; }

        private const string link_id = "car_link";

        protected void Page_Init(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            var queryInfo = new QueryInfo<T_Cm_Car>();
            if (Session["cp_filter"] != null)
            {
                Dictionary<string, object> query = JsonConvert.DeserializeObject<Dictionary<string, object>>(Session["cp_filter"].ToString());
                queryInfo.SetQuery(query.Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString())).ToDictionary(x => x.Key, y => y.Value));
            }
            gridCar.DataSource = _car.Select(queryInfo);
            gridCar.DataBind();
        }

        protected void gridCar_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            var linkMan = gridCar.FindEditFormTemplateControl(link_id) as LinkMan;
            T_Cm_Link link = linkMan.GetLink();
            T_Cm_Car car = new T_Cm_Car();
            UIHelpers.TryUpdateModel<T_Cm_Car>.ToUpdateModel(car, gridCar);
            car.id = Guid.NewGuid();
            car.link = link;
            car.branch_id = UserProvide.GetCurrentBranchID();
            _car.Insert(car);
            //_link.Insert(link);
            e.Cancel = true;
            gridCar.CancelEdit();
            BindData();
        }

        protected void gridCar_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            var linkMan = gridCar.FindEditFormTemplateControl(link_id) as LinkMan;
            T_Cm_Link link = linkMan.GetLink();
            T_Cm_Car car = _car.GetSingle(e.Keys[0]);
            UIHelpers.TryUpdateModel<T_Cm_Car>.ToUpdateModel(car, gridCar);
            car.link = link;
            _car.Update(car);
            //_link.Update(link);
            e.Cancel = true;
            gridCar.CancelEdit();
            BindData();
        }

        protected void gridCar_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            List<object> idAndCarNos = gridCar.GetSelectedFieldValues(new string[] { gridCar.KeyFieldName, T_Cm_Car.CarNoColumnName });
            foreach (object[] id_carno in idAndCarNos)
            {
                var id = id_carno[0];
                var carno = id_carno[1].ToString();
                //与配载发车关联
                IList<T_Stowage_Main> stowageList = _stowage.GetList(new QueryInfo<T_Stowage_Main>().SetQuery(T_Stowage_Main.CarIdColumnName, id));
                if (stowageList.Count > 0)
                {
                    ErrorGrid(carno, AttributesHelper.GetDisplayNameAttributes(typeof(T_Stowage_Main)), e);
                    return;
                }
                //货信息关联
                IList<T_Arrival_Deliver> arrivalList = _arrival.GetList(new QueryInfo<T_Arrival_Deliver>().SetQuery(T_Arrival_Deliver.CarIdColumnName, id));
                if (arrivalList.Count > 0)
                {
                    ErrorGrid(carno, AttributesHelper.GetDisplayNameAttributes(typeof(T_Arrival_Deliver)), e);
                    return;
                }
            }
            //先删除联系人
            List<object> linkIds = gridCar.GetSelectedFieldValues("link_id");
            _link.Delete(linkIds);
            List<object> carIds = gridCar.GetSelectedFieldValues(gridCar.KeyFieldName);
            _car.Delete(carIds);
            FinishGrid(e);
            BindData();
            gridCar.JSProperties[Constants.strCpMessage] = Constants.strSuccessMessage;
        }

        private void ErrorGrid(string car_name, string other_name, CancelEventArgs e)
        {
            string message = string.Format(Constants.strCannotDelete, car_name, other_name);
            gridCar.JSProperties[Constants.strCpMessage] = message;
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridCar.CancelEdit();
        }

        protected void gridCar_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            UpdateControll<T_Cm_Car>.SetValueToControl(grid);
        }

        protected void gridCar_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            if (e.CallbackName == "APPLYFILTER")
            {
                Session.Add("cp_filter", e.Args[0]);
                BindData();
            }
        }
    }
}
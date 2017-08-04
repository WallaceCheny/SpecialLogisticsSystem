using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.Data;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.AppPortal.UserControls;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;


namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class Servicer : BasePage<Servicer>
    {
        [Dependency]
        public ICmServicerDal _servicer { get; set; }
        [Dependency]
        public ICmLinkDal _link { get; set; }
        [Dependency]
        public ITransferMainDal _transfer { get; set; }


        protected void Page_Init(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            var queryInfo = new QueryInfo<T_Cm_Servicer>();
            if (Session["cp_filter"] != null)
            {
                Dictionary<string, object> query = JsonConvert.DeserializeObject<Dictionary<string, object>>(Session["cp_filter"].ToString());
                queryInfo.SetQuery(query.Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString())).ToDictionary(x => x.Key, y => y.Value));
            }
            gridServicer.DataSource = _servicer.Select(queryInfo);
            gridServicer.DataBind();
        }

        protected void gridServicer_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            var linkMan = gridServicer.FindEditFormTemplateControl("link_id") as LinkMan;
            T_Cm_Link link = linkMan.GetLink();
            T_Cm_Servicer servicer = new T_Cm_Servicer();
            UIHelpers.TryUpdateModel<T_Cm_Servicer>.ToUpdateModel(servicer, gridServicer);
            servicer.id = Guid.NewGuid();
            servicer.link_id = link.id;
            _servicer.Insert(servicer);
            _link.Insert(link);
            e.Cancel = true;
            gridServicer.CancelEdit();
            BindData();
        }

        protected void gridServicer_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            var linkMan = gridServicer.FindEditFormTemplateControl("link_id") as LinkMan;
            T_Cm_Link link = linkMan.GetLink();
            T_Cm_Servicer Servicer = _servicer.GetSingle(e.Keys[0]);
            link.id = Servicer.link_id;
            UIHelpers.TryUpdateModel<T_Cm_Servicer>.ToUpdateModel(Servicer, gridServicer);
            _servicer.Update(Servicer);
            _link.Update(link);
            e.Cancel = true;
            gridServicer.CancelEdit();
            BindData();
        }

        protected void gridServicer_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            List<object> IDAndNames = gridServicer.GetSelectedFieldValues(new string[] { gridServicer.KeyFieldName, T_Cm_Servicer.NameColumnName });
            foreach (object[] id_name in IDAndNames)
            {
                var id = id_name[0];
                var name = id_name[1].ToString();
                //与中转外包关联
                IList<T_Transfer_Main> transferList = _transfer.GetList(new QueryInfo<T_Transfer_Main>().SetQuery(T_Transfer_Main.ServiceIDColumnName, id));
                if (transferList.Count > 0)
                {
                    ErrorGrid(name, AttributesHelper.GetDisplayNameAttributes(typeof(T_Transfer_Main)), e);
                    return;
                }
            }
            //先删除联系人
            List<object> linkIds = gridServicer.GetSelectedFieldValues(T_Cm_Servicer.LinkIdColumnName);
            _link.Delete(linkIds);
            List<object> ServicerIds = gridServicer.GetSelectedFieldValues(T_Cm_Servicer.IdColumnName);
            _servicer.Delete(ServicerIds);
            FinishGrid(e);
            BindData();
            gridServicer.JSProperties[Constants.strCpMessage] = Constants.strSuccessMessage;
        }

        private void ErrorGrid(string Servicer_name, string other_name, CancelEventArgs e)
        {
            string message = string.Format(Constants.strCannotDelete, Servicer_name, other_name);
            gridServicer.JSProperties[Constants.strCpMessage] = message;
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridServicer.CancelEdit();
        }

        protected void gridServicer_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            UpdateControll<T_Cm_Servicer>.SetValueToControl(grid);
        }

        protected void gridServicer_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewAfterPerformCallbackEventArgs e)
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
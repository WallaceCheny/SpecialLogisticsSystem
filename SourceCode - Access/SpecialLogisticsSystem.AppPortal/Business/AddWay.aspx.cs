using System;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.Data;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses;
using SpecialLogisticsSystem.AppPortal.UserControls;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.Web.ASPxGridLookup;
using DevExpress.Web.ASPxSplitter;

namespace SpecialLogisticsSystem.AppPortal.Business
{
    public partial class AddWay : BasePage<AddWay>
    {
        [Dependency]
        public IWayBillDal _way { get; set; }
        [Dependency]
        public IWayProductionDal _production { get; set; }
        [Dependency]
        public ICmCustomerDal _customer { get; set; }

        private static string strSessionName = "Production";
        private static string strCalTotal = "CalTotal";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存运单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbk_input_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            int result = 0;
            //1. 保存托运单 2. 保存货物
            T_Way_Bill way = new T_Way_Bill();
            bool isUpdate = way_number.HasValue;
            way.way_number = way_number.GetNewNumber();
            if (isUpdate)
            {
                way = _way.GetSingleByNumber(way.way_number);
            }
            //else
            //{
            //    way.id = Guid.NewGuid();
            //}
            if (way == null)
            {
                isUpdate = false;
                way = new T_Way_Bill();
                way.id = Guid.NewGuid();
            }
            way.bill_memo = bill_memo.Text;
            way.bill_rebate = ConvertHelper.ObjectToDecimal(bill_rebate.Text);
            //way.bill_statue
            way.clearing_type = clearing_type.GetValue();
            way.collection_type = collection_type.GetValue();
            way.consignee_id = consignee_id.GetValue().Value;
            way.deliver_id = deliver_id.GetValue().Value;
            way.delivery_type = delivery_type.GetValue();
            way.end_city = end_city.GetCityValue();
            way.pass_city = pass_city.GetCityValue();
            way.pick_payment = ConvertHelper.ObjectToDecimal(pick_payment.Value);
            way.production_payment = ConvertHelper.ObjectToDecimal(production_payment.Value);
            way.receipt_number = ConvertHelper.ObjectToString(receipt_number.Value);
            way.receipt_portion = ConvertHelper.ObjectToInt(receipt_number.Value);
            way.receive_date = receive_date.Date;
            way.shipping_type = shipping_type.GetValue();
            way.spot_payment = ConvertHelper.ObjectToDecimal(spot_payment.Value);
            way.start_city = start_city.GetCityValue();
            way.way_type = way_type.GetValue();
            //way.way_type
            if (!isUpdate)
            {
                result = _way.Insert(way);
            }
            else
            {
                result = _way.Update(way);
                //货物 先删除 后添加（因为不清楚是新增或修改）
                _production.DeleteByWay(way.id);
            }
            //货物
            var ProductionList = Session[strSessionName] as List<T_Way_Production>;
            if (ProductionList != null)
            {
                foreach (var item in ProductionList)
                {
                    item.bill_id = way.id;
                    _production.Insert(item);
                }
                Session[strSessionName] = null;
            }
            if (result > 0)
            {
                e.Result = Newtonsoft.Json.JsonConvert.SerializeObject(new { success = true, msg = "录入成功", id = way.id });
            }
            else
            {
                e.Result = Newtonsoft.Json.JsonConvert.SerializeObject(new { success = true, msg = "录入失败", id = way.id });
            }
        }

        // <summary>
        /// 加载运单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbk_select_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            if (!way_number.HasValue) return;
            string number = way_number.GetNewNumber();
            T_Way_Bill way = _way.GetSingleByNumber(number);
            bill_memo.Text = way.bill_memo;
            bill_rebate.Text = ConvertHelper.ObjectToString(way.bill_rebate);
            //way.bill_statue
            clearing_type.SetValue(way.clearing_type);
            collection_type.SetValue(way.collection_type);
            consignee_id.SetValue(way.consignee_id);
            deliver_id.SetValue(way.deliver_id);
            delivery_type.SetValue(way.delivery_type);
            end_city.SetCityValue(way.end_city);
            pass_city.SetCityValue(way.pass_city);
            pick_payment.Value = way.pick_payment;
             production_payment.Value=way.production_payment;
            receipt_number.Value=way.receipt_number;
            receipt_number.Value=way.receipt_portion;
            receive_date.Date = way.receive_date;
            shipping_type.SetValue(way.shipping_type);
            spot_payment.Value=way.spot_payment;
            start_city.SetCityValue(way.start_city);
            way_type.SetValue(  way.way_type);
            gridProduction.DataSource = _production.Select(new QueryInfo<T_Way_Production>().SetQuery(T_Way_Production.BillIdColumnName, way.id));
            gridProduction.DataBind();
            ////way.way_type
            //if (!isUpdate)
            //{
            //    result = _way.Insert(way);
            //}
            //else
            //{
            //    result = _way.Update(way);
            //    //货物 先删除 后添加（因为不清楚是新增或修改）
            //    _production.DeleteByWay(way.id);
            //}
            ////货物
            //var ProductionList = Session[strSessionName] as List<T_Way_Production>;
            //if (ProductionList != null)
            //{
            //    foreach (var item in ProductionList)
            //    {
            //        item.bill_id = way.id;
            //        _production.Insert(item);
            //    }
            //    Session[strSessionName] = null;
            //}
            //if (result > 0)
            //{
            //    e.Result = Newtonsoft.Json.JsonConvert.SerializeObject(new { success = true, msg = "录入成功", id = way.id });
            //}
            //else
            //{
            //    e.Result = Newtonsoft.Json.JsonConvert.SerializeObject(new { success = true, msg = "录入失败", id = way.id });
            //}
        }
        #region 货物信息

        /// <summary>
        /// grid 没有caching 只能用这种绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProduction_DataBinding(object sender, EventArgs e)
        {
            var grid = sender as ASPxGridView;
            grid.DataSource = Session[strSessionName] as List<T_Way_Production>;
        }

        private void BindProduction(ASPxGridView grid, CancelEventArgs e, List<T_Way_Production> ProductionList)
        {
            Session[strSessionName] = ProductionList;
            e.Cancel = true;
            grid.CancelEdit();
            if (null == Session[strSessionName]) return;
            grid.DataSource = Session[strSessionName] as List<T_Way_Production>;
            grid.DataBind();
            grid.JSProperties.Add("cp_strCalTotal", strCalTotal);
        }
        /// <summary>
        /// 新增货物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProduction_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            var productionList = Session[strSessionName] as List<T_Way_Production>;
            if (productionList == null) productionList = new List<T_Way_Production>();
            T_Way_Production model = new T_Way_Production();
            UIHelpers.TryUpdateModel<T_Way_Production>.ToUpdateModel(model, grid);
            model.id = Guid.NewGuid();
            productionList.Add(model);
            BindProduction(grid, e, productionList);
        }
        /// <summary>
        /// 修改货物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProduction_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            Guid gridId = ConvertHelper.ObjectToGuid(e.Keys[0]).Value;
            T_Way_Production production = _production.GetSingle(e.Keys[0]);
            var productionList = Session[strSessionName] as List<T_Way_Production>;
            if (productionList == null) return;
            if (production == null) production = productionList.FirstOrDefault(p => p.id == gridId);
            UIHelpers.TryUpdateModel<T_Way_Production>.ToUpdateModel(production, grid);
            productionList.ForEach((p) =>
            {
                if (p.id == gridId)
                {
                    p = production;
                }
            });
            BindProduction(grid, e, productionList);
        }
        /// <summary>
        /// 删除货物
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProduction_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            var deleteId = grid.GetSelectedFieldValues(grid.KeyFieldName).Select(p => ConvertHelper.ObjectToGuid(p));
            var roductionList = Session[strSessionName] as List<T_Way_Production>;
            if (roductionList == null) return;
            roductionList.RemoveAll((c) => { return deleteId.Contains(c.id); });
            BindProduction(grid, e, roductionList);
        }
        /// <summary>
        /// 填充货物信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProduction_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            if (grid.IsNewRowEditing) return;
            UpdateControll<T_Way_Production>.SetValueToControl(grid);
            //List<object> ids = grid.GetSelectedFieldValues(grid.KeyFieldName);
            //List<T_Way_Bill> ProductionList = Session[strSessionName] as List<T_Way_Bill>;
            //if (ProductionList == null || ids.Count == 0) return;
            //var Production = ProductionList.FirstOrDefault(p => ids.Contains(p.id));
        }

        protected void gridProduction_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            //var grid = sender as ASPxGridView;
            //decimal totalPrice = 0;
            //if (e.Parameters == strCalTotal)
            //{
            //    var aggregate_amount = gridWay.FindEditFormTemplateControl("aggregate_amount") as UserControl.ASPxTextBox;//总金额
            //    if (aggregate_amount == null) return;
            //    var productionList = Session[strSessionName] as List<T_Way_Production>;
            //    if (productionList != null)
            //    {
            //        //上保险所交的钱是保费,发生保险责任所赔偿的是保险合同成立时约定的保险金额也就是保额
            //        foreach (var item in productionList)
            //        {
            //            totalPrice += item.agency_fund + item.premium + item.delivery_expense + item.freight + item.other_expenses;
            //        }

            //    }
            //    aggregate_amount.Text = totalPrice.ToString();
            //}
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxTreeList;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using System.Drawing;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using System.ComponentModel;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class Code : BasePage<Code>
    {
        [Dependency]
        public ICmCodeDal _code { get; set; }

        private static string para_type = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack || IsCallback)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.Code;
                    master.IsShowSearch = false;
                }
                DataBind();
                SetNodeSelectionSettings(para_type);
            }
        }

        private void DataBind()
        {
            //T_Cm_Code code = new T_Cm_Code();
            //QueryInfo<T_Cm_Code> queryInfo = new QueryInfo<T_Cm_Code>();
            ////获得参数类别
            //queryInfo.SetXml("SelectParaType");
            this.gridParaType.DataSource = ConvertHelper.EnumnToNameDescription(typeof(CodeType)); //_code.Select(queryInfo);
            this.gridParaType.DataBind();
        }



        void SetNodeSelectionSettings(string gridIdstr)
        {
            if (string.IsNullOrEmpty(gridIdstr)) return;
            para_type = gridIdstr;
            if (gridIdstr == null) return;
            //获取所有的，并且未启用的
            QueryInfo<T_Cm_Code> queryInfo = new QueryInfo<T_Cm_Code>();
            queryInfo.SetQuery(T_Cm_Code.TypeColumnName, gridIdstr);
            queryInfo.SetQuery(T_Cm_Code.ActiveColumnName, "0");
            gridCode.DataSource = _code.Select(queryInfo);
            gridCode.DataBind();
        }

        protected void gridCode_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as ASPxGridView;
            UpdateControll<T_Cm_Code>.SetValueToControl(grid);
            bool IsNewRowEditing = grid.IsNewRowEditing;

            // var PARA_TYPE = grid.FindEditFormTemplateControl("PARA_TYPE") as ASPxTextBox;
            var para_value = grid.FindEditFormTemplateControl("para_value") as ASPxTextBox;
            //var PARA_TYPE_NAME = grid.FindEditFormTemplateControl("PARA_TYPE_NAME") as ASPxTextBox;
            ////var PARA_NAME = grid.FindEditFormTemplateControl("PARA_NAME") as ASPxTextBox;
            //var EFF_IND = grid.FindEditFormTemplateControl("EFF_IND") as ASPxComboBox;
            ////var PARA_DEMO = grid.FindEditFormTemplateControl("PARA_DEMO") as ASPxMemo;
            var update_date = grid.FindEditFormTemplateControl("update_date") as ASPxTextBox;
            var update_opr = grid.FindEditFormTemplateControl("update_opr") as ASPxTextBox;

            update_date.Text = DateTime.Now.ToString();
            update_opr.Text = UIHelpers.UserProvide.GetCurrentUserName();

            //  if (IsNewRowEditing) EFF_IND.SelectedItem.Value = "1";

            if (!IsNewRowEditing)
            {
                para_value.BackColor = Color.FromArgb(224, 224, 224);
                para_value.ReadOnly = true;

            }

        }

        protected void gridCode_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            SetNodeSelectionSettings(e.Parameters);
        }


        protected void gridParaType_SelectionChanged(object sender, EventArgs e)
        {
            List<object> table = gridParaType.GetSelectedFieldValues(new string[] { gridParaType.KeyFieldName, "Description" });//这里是想要获取的字段名列表。   
            if (table.Count == 0) return;
            object[] row = (object[])table[0];//这是得到第一行记录的值，如果是多行选择，可以循环取出。   
            //if (!string.IsNullOrEmpty(row[1].ToString()))
            //{
            labShowSelectText.Value = row[0].ToString();
            labShowSelectText.ToolTip = row[1].ToString();
            //}
        }

        protected void gridCode_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            T_Cm_Code code = new T_Cm_Code();
            TryUpdateModel<T_Cm_Code>.ToUpdateModel(code, grid);
            code.id = Guid.NewGuid();
            code.para_type = labShowSelectText.Value.ToString();
            code.para_type_name = labShowSelectText.ToolTip;
            _code.Insert(code);
            SetNodeSelectionSettings(para_type);
            FinishGrid(e);
        }

        protected void gridCode_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var grid = sender as ASPxGridView;
            T_Cm_Code code= _code.GetSingle(e.Keys[0]);
            code.is_active = true;
            _code.Update(code);
            SetNodeSelectionSettings(para_type);
            FinishGrid(e);
        }

        protected void gridCode_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            T_Cm_Code code = _code.GetSingle(e.Keys[0]);
            TryUpdateModel<T_Cm_Code>.ToUpdateModel(code, gridCode);
            _code.Update(code);
            SetNodeSelectionSettings(para_type);
            FinishGrid(e);
        }

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridCode.CancelEdit();
        }
    }
}
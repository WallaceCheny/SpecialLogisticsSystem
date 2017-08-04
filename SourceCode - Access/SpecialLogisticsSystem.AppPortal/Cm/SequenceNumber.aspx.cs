using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using DevExpress.Web.Data;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.UserControl;
using DevExpress.Web.ASPxGridView;
using System.ComponentModel;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class SequenceNumber : BasePage<SequenceNumber>
    {
        [Dependency]
        public ICmSequenceNumberDal _number { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.Number;
                    master.IsShowSearch = false;
                }
            }
        }

        private void BindData()
        {
            List<T_Cm_SequenceNumber> sequenceList = new List<T_Cm_SequenceNumber>();
            Type codeTable = typeof(CodeTable);
            string[] names = Enum.GetNames(codeTable);
            QueryInfo<T_Cm_SequenceNumber> queryInfo = new QueryInfo<T_Cm_SequenceNumber>();
            queryInfo.SetQuery(T_Cm_SequenceNumber.CodeColumnName, names);
            sequenceList = _number.GetList(queryInfo).ToList();
            foreach (var item in names)
            {
                T_Cm_SequenceNumber number = sequenceList.FirstOrDefault(p => p.code == item);
                if (number == null)
                {
                    number = new T_Cm_SequenceNumber();
                    number.code = item;
                    sequenceList.Add(number);
                }
                number.name = ConvertHelper.GetEnumAttribute(item, codeTable);
            }
            gridNumber.DataSource = sequenceList;
            gridNumber.DataBind();
        }

  
        protected void gridNumber_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            T_Cm_SequenceNumber number = _number.GetSingle(e.Keys[0]);
            bool isUpdate = (number != null);
            if (!isUpdate) number = new T_Cm_SequenceNumber();
            UIHelpers.TryUpdateModel<T_Cm_SequenceNumber>.ToUpdateModel(number, gridNumber);
            if (isUpdate)
            {
                _number.Update(number);
            }
            else
            {
                _number.Insert(number);
            }
            FinishGrid(e);
            BindData();
        }

       

        private void FinishGrid(CancelEventArgs e)
        {
            e.Cancel = true;
            gridNumber.CancelEdit();
        }

        protected void gridNumber_HtmlEditFormCreated(object sender, ASPxGridViewEditFormEventArgs e)
        {
            var grid = sender as SpecialLogisticsSystem.UserControl.ASPxGridView;
            UpdateControll<T_Cm_SequenceNumber>.SetValueToControl(grid);
        }
    }
}
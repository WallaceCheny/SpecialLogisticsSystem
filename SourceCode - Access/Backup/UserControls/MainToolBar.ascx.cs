using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class MainToolBar : System.Web.UI.UserControl
    {
        public string ExportName
        {
            get;
            set;
        }
        public bool IsShowMenu
        {
            set
            {
                viewMenu.Visible = value;
            }
        }
        /// <summary>
        /// 是否是子菜单
        /// </summary>
        public bool IsSubMenu
        {
            set
            {
                if (value) //子菜单
                {
                    viewMenu.Items[0].Name = "add_sub";
                    viewMenu.Items[1].Name = "edit_sub";
                    viewMenu.Items[2].Name = "delete_sub";
                    viewMenu.Items.FindByName("refresh").Visible = false;
                    viewMenu.Items.FindByName("help").Visible = false;
                    viewMenu.Items.FindByName("export").Visible = false;
                    viewMenu.ClientInstanceName = "sub_viewMenu";
                }
            }
        }
        public PageType PageToolBar
        {
            set
            {
                switch (value)
                {
                    case PageType.Way:
                        viewMenu.Items.FindByName("add").Text = "运单录入";
                        viewMenu.Items.FindByName("delete").Text = "作废";
                        viewMenu.Items.FindByName("instorage").Visible = true;
                        viewMenu.Items.FindByName("outstorage").Visible = true;
                        viewMenu.Items.FindByName("print").Visible = true;
                        viewMenu.Items.FindByName("message").Visible = true;
                        break;
                    case  PageType.Stowage:
                        viewMenu.Items.FindByName("print").Text = "打印装车清单";
                        viewMenu.Items.FindByName("confirm").Text = "确认发车";
                        viewMenu.Items.FindByName("confirm").Visible = true;
                        viewMenu.Items.FindByName("print").Visible = true;
                        break;
                    case PageType.User:
                        viewMenu.Items.FindByName("set_password").Visible = true;
                        break;
                    case PageType.Number:
                        viewMenu.Items.FindByName("add").Visible = false;
                        viewMenu.Items.FindByName("delete").Visible = false;
                        break;
                    case PageType.Code:
                    case PageType.Export:
                        viewMenu.Items.FindByName("add").Visible = false;
                        viewMenu.Items.FindByName("delete").Visible = false;
                        viewMenu.Items.FindByName("edit").Visible = false;
                        viewMenu.Items.FindByName("export").Visible = false;
                        break;
                    case PageType.Config:
                        viewMenu.Items.FindByName("add").Visible = false;
                        viewMenu.Items.FindByName("delete").Visible = false;
                        viewMenu.Items.FindByName("edit").Visible = false;
                        viewMenu.Items.FindByName("export").Visible = false;
                        viewMenu.Items.FindByName("save_call").Visible = true;
                        break;
                    case PageType.Arrival:
                        viewMenu.Items.FindByName("add").Text = "确认到货";
                        //viewMenu.Items.FindByName("add").Name = "add_select";
                        viewMenu.Items.FindByName("delete").Visible = false;
                        viewMenu.Items.FindByName("edit").Visible = false;
                        //viewMenu.Items.FindByName("confirm").Visible = true;
                        viewMenu.Items.FindByName("signed").Visible = true;
                        break;
                    case PageType.SelectedMenu:
                        viewMenu.Items.FindByName("add").Text = "选择运单";
                        viewMenu.Items.FindByName("add").Name = "add_select";
                        viewMenu.Items.FindByName("delete").Visible = false;
                        viewMenu.Items.FindByName("edit").Visible = false;
                        viewMenu.Items.FindByName("refresh").Visible = false;
                        viewMenu.Items.FindByName("help").Visible = false;
                        viewMenu.Items.FindByName("export").Visible = false;
                        viewMenu.ClientInstanceName = "sub_viewMenu";
                        break;
                    case PageType.CustomerPay:
                    case PageType.DriverPay:
                    case PageType.TransferPay:
                    case PageType.DiscountPay:
                        viewMenu.Items.FindByName("add").Visible = false;
                        viewMenu.Items.FindByName("delete").Visible = false;
                        viewMenu.Items.FindByName("edit").Visible = false;
                        viewMenu.Items.FindByName("settle").Visible = true;
                        viewMenu.Items.FindByName("settle").Text = ConvertHelper.GetEnumAttribute(value.ToString(), typeof(PageType));
                        break;
                    case PageType.Help:
                        viewMenu.Items.FindByName("add").Visible = false;
                        viewMenu.Items.FindByName("edit").Name = "add_popup";
                        viewMenu.Items.FindByName("delete").Visible = false;
                        viewMenu.Items.FindByName("export").Visible = false;
                        viewMenu.Items.FindByName("help").Visible = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public bool IsTreeMenu
        {
            set
            {
                if (!value) return;
                viewMenu.Items.FindByName("add").Name = "add_tree";
                viewMenu.Items.FindByName("edit").Name = "edit_tree";
                viewMenu.Items.FindByName("delete").Name = "delete_tree";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void viewMenu_ItemClick(object source, DevExpress.Web.ASPxMenu.MenuItemEventArgs e)
        {
            if (string.IsNullOrEmpty(this.ExportName)) this.ExportName = "新建单";
            switch (e.Item.Name)
            {
                case "XLSX":
                    gridExport.WriteXlsxToResponse(this.ExportName, true);
                    break;
                case "XLS":
                    gridExport.WriteXlsToResponse(this.ExportName, true);
                    break;
                default:
                    break;
            }
        }
    }
}
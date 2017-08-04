using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using DevExpress.Web.ASPxEditors;
using System.Drawing;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class EditToolBar : BaseUserControl
    {
        private readonly string strSave = "save";
        private readonly string strCancel = "cancel";
        private readonly string strHelp = "help";

        public void SetStatue(string statue)
        {
            ASPxLabel lblStatue = saveMenu.Items.FindByName("building").FindControl("lblStatue") as ASPxLabel;
            if (null != lblStatue)
            {
                lblStatue.Text = ConvertHelper.GetEnumAttribute(statue, typeof(WayStatue));
            }
        }


        public FunctionType MenuTye
        {
            set
            {
                switch (value)
                {
                    case FunctionType.SubMenu:
                        saveMenu.Items.FindByName(strSave).Name = "save_sub";
                        saveMenu.Items.FindByName(strCancel).Name = "cancel_sub";
                        break;
                    case FunctionType.PopupMenu:
                        saveMenu.ID = "sub_popupMenu";
                        saveMenu.ClientInstanceName = "sub_popupMenu";
                        saveMenu.Items.FindByName(strSave).Name = "save_popup";
                        saveMenu.Items.FindByName(strCancel).Name = "cancel_popup";
                        break;
                    case FunctionType.TreeMenu:
                        saveMenu.Items.FindByName(strSave).Name = "save_tree";
                        saveMenu.Items.FindByName(strCancel).Name = "cancel_tree";
                        break;
                    case FunctionType.SelectedMenu:
                        saveMenu.ID = "sub_saveMenu";
                        saveMenu.ClientInstanceName = "sub_saveMenu";
                        saveMenu.Items.FindByName(strSave).Image.SpriteProperties.CssClass = "icon select";
                        saveMenu.Items.FindByName(strSave).Text = "选中";
                        saveMenu.Items.FindByName(strSave).Name = "selectd_popup";
                        saveMenu.Items.FindByName(strCancel).Name = "cancel_select_popup";
                        break;
                    case FunctionType.HelpMenu:
                        saveMenu.Items.FindByName(strSave).Name = "save_call";
                        saveMenu.Items.FindByName(strCancel).Name = "cancel_popup";
                        break;
                    case FunctionType.SmsMenu:
                        saveMenu.Items.FindByName(strSave).Text = "发送";
                        saveMenu.Items.FindByName(strSave).Image.SpriteProperties.CssClass = "icon send_sms";
                        saveMenu.Items.FindByName(strSave).Name = "save_call";
                        saveMenu.Items.FindByName(strCancel).Name = "cancel_sms";
                        break;
                    case FunctionType.WayMenu:
                        saveMenu.Items.FindByName("building").Visible = true;
                        //saveMenu.Items.FindByName("save_print").Visible = true;
                        break;
                    case FunctionType.StowageMenu:
                        //Panel paneStatue = saveMenu.Items.FindByName("building").FindControl("paneStatue") as Panel;
                        //if (null != paneStatue)
                        //{
                        //    paneStatue.CssClass = "last_menu1";
                        //}
                        saveMenu.Items.FindByName("building").Visible = true;
                        //saveMenu.Items.FindByName("save_print").Visible = true;
                        break;
                    default:
                        break;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
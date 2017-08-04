using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;
using System.Configuration;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class Help : BasePage<Help>
    {
        [Dependency]
        public ICmMenuDal _menu { get; set; }
        private const string strMenuID = "menu_id";
        private const string strType = "Type";
        private const string appSettingCanEdit = "HelpCanEdit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var master = this.Master as MenuMaster;
            if (null != master)
            {
                master.MenuToolBar.PageToolBar = PageType.Help;
                master.IsShowSearch = false;
            }
            SetCanEdit(master);
            BindData();
        }
        /// <summary>
        /// 设置是可写入，还是只读
        /// </summary>
        private void SetCanEdit(MenuMaster master)
        {
            string isCanEdit = ConvertHelper.ObjectToString(ConfigurationManager.AppSettings[appSettingCanEdit]);
            master.MenuToolBar.Visible = isCanEdit == "Y";
            //helpHtmlEditor.Settings.AllowHtmlView = false;
            //Model.T_Cm_User user = UIHelpers.UserProvide.GetCurrentUser();
            //if (null != user && user.is_admin) return;
            //this.helpHtmlEditor.Settings.AllowDesignView = false;
            //this.saveMenu.Visible = false;
        }

        private void BindData()
        {
            T_Cm_Menu modelMenu = null;
            if (Request[strMenuID] != null)
            {
                modelMenu = _menu.GetSingle(Request[strMenuID]); 
            }
            else if (Request[strType] != null)
            {
                QueryInfo<T_Cm_Menu> queryInfo = new QueryInfo<T_Cm_Menu>();
                queryInfo.SetQuery(T_Cm_Menu.ActionColumnName, Request[strType]);
                modelMenu = _menu.GetList(queryInfo).FirstOrDefault(); 
            }
            if (null == modelMenu) return;
            hideMenuID.Value = ConvertHelper.ObjectToString(modelMenu.id);
            literalHelp.Text = modelMenu.help_html;
            helpHtmlEditor.Html = modelMenu.help_html;
        }

        protected void reback_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            if (string.IsNullOrEmpty(hideMenuID.Value)) return;
            T_Cm_Menu _modelMenu = _menu.GetSingle(hideMenuID.Value);
            _modelMenu.help_html = helpHtmlEditor.Html;
            _menu.Update(_modelMenu);
            e.Result = "true";
        }
    }
}
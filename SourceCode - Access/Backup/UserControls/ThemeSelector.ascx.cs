using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxMenu;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class ThemeSelector : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ASPxTreeView tvNodes = cbbTheme.FindControl("tvNodes") as ASPxTreeView;
            ThemesContainerRepeater.DataSource = ThemesModel.Current.Groups;
            ThemesContainerRepeater.DataBind();
        }

        private int Index
        {
            get
            {
                if (ViewState["index"] == null)
                {
                    ViewState["index"] = 1;
                    return 1;
                }
                else
                {
                    int index=ConvertHelper.ObjectToInt(ViewState["index"]) + 1;
                    ViewState["index"]=index;
                    return index;
                }

            }
        }
        protected void Menu_DataBinding(object sender, EventArgs e)
        {
            ASPxMenu menu = (ASPxMenu)sender;
            menu.ID = menu.ID + Index;
            RepeaterItem item = menu.NamingContainer as RepeaterItem;
            if (item != null)
            {
                ThemeGroupModel group = item.DataItem as ThemeGroupModel;
                foreach (ThemeModel theme in group.Themes)
                {
                    DevExpress.Web.ASPxMenu.MenuItem menuItem = menu.Items.Add(theme.Title, theme.Name);
                    menuItem.Image.SpriteProperties.CssClass = "ThemeSprite " + theme.SpriteCssClass;
                    menuItem.Selected = (theme.Name == Utils.CurrentTheme);
                }
            }
        }
    }
}
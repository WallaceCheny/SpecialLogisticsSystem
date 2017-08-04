using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxEditors;
using SpecialLogisticsSystem.Tool;
using DevExpress.Web.ASPxGridView;

namespace SpecialLogisticsSystem.UserControl
{
    public class CommonSetting
    {
        public static void SetRequired(ValidationSettings _setting, bool isSub)
        {
            _setting.Display = DevExpress.Web.ASPxEditors.Display.Dynamic;
            _setting.SetFocusOnError = true;
            _setting.ErrorDisplayMode = DevExpress.Web.ASPxEditors.ErrorDisplayMode.ImageWithTooltip;
            _setting.ValidateOnLeave = true;
            _setting.ValidationGroup = isSub ? ConstantsHelper.Validation_Sub_Group : ConstantsHelper.Validation_Group;
            _setting.RequiredField.IsRequired = true;
            _setting.RequiredField.ErrorText = ConstantsHelper.Error_Message;
        }

        public static void SetPager(ASPxGridViewPagerSettings _setting,int pageSize)
        {
            //<SettingsPager AlwaysShowPager="true" Mode="ShowPager" PageSize="10" Position="TopAndBottom" />
            _setting.PageSize = pageSize;
            _setting.AlwaysShowPager= true;
            _setting.Mode= GridViewPagerMode.ShowPager;
            _setting.Position= System.Web.UI.WebControls.PagerPosition.Bottom;
            _setting.Summary.Text = ConstantsHelper.Pager_Formation;
        }
    }
}

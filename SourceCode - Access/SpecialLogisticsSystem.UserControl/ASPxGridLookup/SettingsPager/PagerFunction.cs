using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.UserControl
{
    public class PagerFunction
    {
        public static void _look_Pager(ASPxGridLookup _look, EventArgs e)
        {
            //<SettingsPager PageSize="20" Summary-Text="第{0}/{1}页(共{2}条)" Mode="ShowAllRecords">
            //        <Summary Text="第{0}/{1}页(共{2}条)"></Summary>
            // </SettingsPager>
            CommonSetting.SetPager(_look.GridViewProperties.SettingsPager, _look.PageSize);
        }
    }
}

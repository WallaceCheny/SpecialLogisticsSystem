using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecialLogisticsSystem.Tool;
using System.Web.UI.WebControls;

namespace SpecialLogisticsSystem.UserControl
{
    public class PriceFunction
    {
        public static void _txt_Price(ASPxTextBox _txt)
        {
            _txt.MaskSettings.Mask = "￥<0..99999g>.<00..99>";
            _txt.MaskSettings.IncludeLiterals = DevExpress.Web.ASPxEditors.MaskIncludeLiteralsMode.DecimalSymbol;
            //<ValidationSettings ErrorDisplayMode="None">
            //     <ErrorFrameStyle>
            //         <Paddings Padding="0px" />
            //         <Border BorderWidth="0px" />
            //     </ErrorFrameStyle>
            //</ValidationSettings>
            _txt.ValidationSettings.ErrorDisplayMode = DevExpress.Web.ASPxEditors.ErrorDisplayMode.None;
            _txt.ValidationSettings.ErrorFrameStyle.Paddings.Padding = Unit.Pixel(0);
            _txt.ValidationSettings.ErrorFrameStyle.Border.BorderWidth = Unit.Pixel(0);
        }
    }
}

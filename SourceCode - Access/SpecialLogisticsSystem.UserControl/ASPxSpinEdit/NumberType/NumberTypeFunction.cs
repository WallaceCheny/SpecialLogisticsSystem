using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialLogisticsSystem.UserControl
{
    public class NumberTypeFunction
    {
        public static void _spin_Price(ASPxSpinEdit _spin)
        {
            _spin.NumberType = DevExpress.Web.ASPxEditors.SpinEditNumberType.Integer;
            _spin.MinValue = 0;
        }
    }
}

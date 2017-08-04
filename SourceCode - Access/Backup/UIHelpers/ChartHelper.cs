using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Web;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public static class ChartHelper
    {
        public static void SetChartStyle(WebChartControl chart, ChartSearchType dayType)
        {
            chart.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
            XYDiagram diagramm = (XYDiagram)chart.Diagram;
            AxisX thisAxisX = diagramm.AxisX;
            thisAxisX.Label.Angle = -35;
            thisAxisX.DateTimeOptions.Format = DateTimeFormat.Custom;
            switch (dayType)
            {
                case ChartSearchType.ByDate:
                    thisAxisX.DateTimeMeasureUnit = DateTimeMeasurementUnit.Day;
                    thisAxisX.DateTimeGridAlignment = DateTimeMeasurementUnit.Day;
                    thisAxisX.DateTimeOptions.FormatString = "MM-dd";
                    break;
                case ChartSearchType.ByMonth:
                    thisAxisX.DateTimeMeasureUnit = DateTimeMeasurementUnit.Month;
                    thisAxisX.DateTimeGridAlignment = DateTimeMeasurementUnit.Month;
                    thisAxisX.DateTimeOptions.FormatString = "MM月";
                    break;
                case ChartSearchType.ByYear:
                    thisAxisX.DateTimeMeasureUnit = DateTimeMeasurementUnit.Year;
                    thisAxisX.DateTimeGridAlignment = DateTimeMeasurementUnit.Year;
                    thisAxisX.DateTimeOptions.FormatString = "yyyy年";
                    break;
            }
        }
    }
}
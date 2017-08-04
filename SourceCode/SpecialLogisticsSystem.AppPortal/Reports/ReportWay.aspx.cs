using System;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;
using DevExpress.XtraReports.UI;

namespace SpecialLogisticsSystem.AppPortal.Reports
{
    public partial class ReportWay : BasePage<ReportWay>
    {
        [Dependency]
        public IWayBillDal _way { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            ReportViewerControl1.Report.BeforePrint += new System.Drawing.Printing.PrintEventHandler(XtraReport1_BeforePrint);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //设置打印页的宽度和高度
                XtraReport xrp = ReportViewerControl1.Report;
                xrp.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;  //设置单位为mm
                xrp.PaperKind = System.Drawing.Printing.PaperKind.Custom;                           //纸张类型自定义

                xrp.PageWidth = 241;
                xrp.PageHeight = 140;
            }

        }

        private void XtraReport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Guid? wayId = ConvertHelper.ObjectToGuid(Request["id"]);
            QueryInfo<T_Way_Bill> queryInfo = new QueryInfo<T_Way_Bill>();
            queryInfo.SetQuery("id", wayId);
            //queryInfo.SetXml("SelectPaging");
            var waylist = _way.Select(queryInfo);
            ReportViewerControl1.Report.DataSource = waylist;
        }
    }
}
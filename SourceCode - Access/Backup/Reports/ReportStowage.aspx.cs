using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.IDal;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.Reports
{
    public partial class ReportStowage : BasePage<ReportStowage>
    {
        [Dependency]
        public IStowageDetailDal _stowage_detail { get; set; }
        protected void Page_Init(object sender, EventArgs e)
        {
            ReportViewerControl1.Report.BeforePrint += new System.Drawing.Printing.PrintEventHandler(XtraReport1_BeforePrint);
        }
     

        private void XtraReport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Guid? Id = ConvertHelper.ObjectToGuid(Request["id"]);
            QueryInfo<T_Stowage_Detail> queryInfo = new QueryInfo<T_Stowage_Detail>();
            queryInfo.SetQuery("main_id", Id);
            //queryInfo.SetXml("SelectPaging");
            var stowageList = _stowage_detail.Select(queryInfo);
            ReportViewerControl1.Report.DataSource = stowageList;
        }
    }
}
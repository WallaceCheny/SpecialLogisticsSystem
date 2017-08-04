using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.Web;
using DevExpress.XtraReports.UI;
using System.IO;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class ReportViewerControl : System.Web.UI.UserControl
    {
        bool autoCenter = true;
        public PrintType ReportType
        {
            get;
            set;
        }
        public ReportViewer ReportViewer { get { return ReportViewer1; } }
        public string ReportName
        {
            get { return ReportViewer1.ReportName; }
            set { ReportViewer1.ReportName = value; }
        }
        public XtraReport Report
        {
            get
            {
                return ReportViewer1.Report;
            }
            set
            {
                string path = System.AppDomain.CurrentDomain.BaseDirectory;
                
                string currentFilePath = Path.Combine(path, string.Format(@"XtraReports\{0}.repx",ReportType.ToString()));
                value.LoadLayout(currentFilePath);
                //value=datas
                ReportViewer1.Report = value;
            }
        }
        public bool AutoCenter
        {
            get { return autoCenter; }
            set { autoCenter = value; }
        }
        public string AutoCenterValue
        {
            get { return autoCenter ? "margin:auto" : ""; }
        }

        //void Page_Init()
        //{
        //    if (RightPlaceHolder != null)
        //    {
        //        Panel1.Visible = true;
        //        container = new RightPlaceHolder();
        //        rightPlaceHolder.InstantiateIn(container);
        //        RightSidePlaceHolder.Controls.Add(container);
        //    }
        //    Page.Header.Controls.Add(new LiteralControl(Helper.GetPageBorderCSSLink()));
        //}
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            DataBind();
        }
    }
}
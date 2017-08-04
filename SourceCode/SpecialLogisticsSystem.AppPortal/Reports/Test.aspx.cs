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
    public partial class Test : BasePage<Test>
    {
        [Dependency]
        public IWayBillDal _way { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Guid? wayId=ConvertHelper.ObjectToGuid(Request["id"]);
                QueryInfo<T_Way_Bill> queryInfo=new QueryInfo<T_Way_Bill>();
                queryInfo.SetQuery("id",wayId);
                var waylist=_way.Select(queryInfo);
                ReportViewerControl1.Report.DataSource = waylist;
                //ReportViewerControl1.Report.
            }

        }
    }
}
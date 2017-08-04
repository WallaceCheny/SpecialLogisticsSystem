using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.IDal;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.Print
{
    public partial class PrintWay : BasePage<PrintWay>
    {
        [Dependency]
        public IWayBillDal _way { get; set; }
        [Dependency]
        public ICmBranchDal _branch { get; set; }

        public dynamic way { get; set; }
        public T_Cm_Branch branch { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid? wayId = ConvertHelper.ObjectToGuid(Request["id"]);
            QueryInfo<T_Way_Bill> queryInfo1 = new QueryInfo<T_Way_Bill>();
            queryInfo1.SetQuery("id", wayId);
            way = _way.Select(queryInfo1).FirstOrDefault();

            QueryInfo<T_Cm_Branch> queryInfo2 = new QueryInfo<T_Cm_Branch>();
            queryInfo2.SetQuery("is_headquarters", "1");
            branch = _branch.GetList(queryInfo2).FirstOrDefault();
        }
    }
}
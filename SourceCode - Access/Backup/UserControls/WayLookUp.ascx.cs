using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class WayLookUp : BaseLookUp
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void wayDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["filter"] = !string.IsNullOrEmpty(way_customelookup.GridView.FilterExpression) ? way_customelookup.GridView.FilterExpression : string.Empty;
        }

        protected override UserControl.ASPxGridLookup _lookUp
        {
            get { return this.way_customelookup; }
        }

        protected override void BindData()
        {
            IWayBillDal _way = UIHelper.Resolve<IWayBillDal>();
            this.way_customelookup.DataSource = _way.Select(new QueryInfo<T_Way_Bill>());
            this.way_customelookup.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class ProductionLookUp : BaseLookUp
    {
        public string ClientSideJs
        {
            set
            {
                this._lookUp.ClientSideEvents.ValueChanged = value;
            }
        }
        public WayType WayType
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override UserControl.ASPxGridLookup _lookUp
        {
            get { return this.product_customelookup; }
        }

        protected override void BindData()
        {
            QueryInfo<T_Way_Production> queryInfo = new QueryInfo<T_Way_Production>();
            queryInfo.SetQuery(T_Way_Bill.WayTypeColumnName, (int)WayType);
            queryInfo.SetXml("SelectView");
            IWayProductionDal _production = UIHelper.Resolve<IWayProductionDal>();
            product_customelookup.DataSource = _production.Select(queryInfo);
            product_customelookup.DataBind();
        }
    }
}
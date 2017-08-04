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
    public partial class StowageLookUp : BaseLookUp
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void stowageDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["filter"] = !string.IsNullOrEmpty(stowage_customelookup.GridView.FilterExpression) ? stowage_customelookup.GridView.FilterExpression : string.Empty;
        }

        protected override UserControl.ASPxGridLookup _lookUp
        {
            get { return this.stowage_customelookup; }
        }

        protected override void BindData()
        {
            IStowageMainDal _stowage = UIHelper.Resolve<IStowageMainDal>();
            this.stowage_customelookup.DataSource = _stowage.Select(new QueryInfo<T_Stowage_Main>());
            this.stowage_customelookup.DataBind();
        }
    }
}
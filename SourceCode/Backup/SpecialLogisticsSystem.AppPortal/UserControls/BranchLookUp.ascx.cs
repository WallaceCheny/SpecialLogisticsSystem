using System;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.UserControl;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class BranchLookUp : BaseLookUp
    {
        public string ClientSideJs
        {
            set
            {
                this.branch_customelookup.ClientSideEvents.ValueChanged = value;
            }
        }
        public bool IsMultiple
        {
            set
            {
                if (value)
                {
                    this.branch_customelookup.SelectionMode = DevExpress.Web.ASPxGridLookup.GridLookupSelectionMode.Multiple;
                    this.IsNew = false;
                    this.branch_customelookup.GridViewProperties.SettingsBehavior.AllowSelectSingleRowOnly = false;
                    this.branch_customelookup.IsConfirm = true;
                }
            }
        }
        protected override void BindData()
        {
            ICmBranchDal _branch = UIHelper.Resolve<ICmBranchDal>();
            branch_customelookup.DataSource = _branch.Select(new QueryInfo<T_Cm_Branch>());
            branch_customelookup.DataBind();
        }

        protected override ASPxGridLookup _lookUp
        {
            get { return this.branch_customelookup; }
        }
    }
}
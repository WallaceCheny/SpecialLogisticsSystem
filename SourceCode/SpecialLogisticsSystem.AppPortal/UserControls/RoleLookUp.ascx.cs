using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class RoleLookUp : BaseLookUp
    {
        protected override void BindData()
        {
            ICmRoleDal _role = UIHelper.Resolve<ICmRoleDal>();
            role_customelookup.DataSource = _role.GetList(new QueryInfo<T_Cm_Role>());
            role_customelookup.DataBind();
        }

        protected override UserControl.ASPxGridLookup _lookUp
        {
            get { return role_customelookup; }
        }
    }
}
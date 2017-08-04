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
    public partial class ServicerLookUp : BaseLookUp
    {
        public int Width
        {
            set
            {
                this.service_customelookup.Width = Unit.Pixel(value);
            }
        }
        public string ClientSideJs
        {
            set
            {
                this.service_customelookup.ClientSideEvents.ValueChanged = value;
            }
        }
        protected override UserControl.ASPxGridLookup _lookUp
        {
            get { return this.service_customelookup; }
        }

        protected override void BindData()
        {
            ICmServicerDal _servicer = UIHelper.Resolve<ICmServicerDal>();
            service_customelookup.DataSource = _servicer.Select(new QueryInfo<T_Cm_Servicer>());
            service_customelookup.DataBind();
        }
    }
}
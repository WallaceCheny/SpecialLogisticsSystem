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
    public partial class CarLookUp : BaseLookUp
    {
        public string ClientSideJs
        {
            set
            {
                this.car_customelookup.ClientSideEvents.ValueChanged = value;
            }
        }

        public bool IsDeliver
        {
            set
            {
                if (value)
                {
                    car_customelookup.TextFormatString = "{4}";
                    car_customelookup.ID = "link_id";
                }
            }
        }
        public int Width
        {
            set
            {
                this.car_customelookup.Width = Unit.Pixel(value);
            }
        }
        protected override UserControl.ASPxGridLookup _lookUp
        {
            get { return this.car_customelookup; }
        }

        protected override void BindData()
        {
            ICmCarDal _car = UIHelper.Resolve<ICmCarDal>();
            car_customelookup.DataSource = _car.Select(new QueryInfo<T_Cm_Car>());
            car_customelookup.DataBind();
        }
    }
}
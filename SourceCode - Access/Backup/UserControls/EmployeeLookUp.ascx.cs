using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.AppPortal.UIHelpers;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class EmployeeLookUp : BaseLookUp
    {
        protected override UserControl.ASPxGridLookup _lookUp
        {
            get { return employee_customelookup; }
        }
        public int Width
        {
            set
            {
                this.employee_customelookup.Width = Unit.Pixel(value);
            }
        }
        /// <summary>
        /// 设置默认为当前登入人员
        /// </summary>
        public bool IsSetDefault
        {
            set
            {
                if (value)
                {
                    if (employee_customelookup.DataSource == null)
                    {
                        BindData();
                    }
                    employee_customelookup.Value = UserProvide.GetCurrentEmpId();
                }
            }
        }

        protected override void BindData()
        {
            if (employee_customelookup.DataSource != null) return;
            ICmEmpDal _employee = UIHelper.Resolve<ICmEmpDal>();
            employee_customelookup.DataSource = _employee.Select(new QueryInfo<T_Cm_Emp>());
            employee_customelookup.DataBind();
        }
    }
}
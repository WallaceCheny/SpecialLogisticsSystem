using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class DistrictLookUp : BaseLookUp
    {
        /// <summary>
        /// 是否设置默认值
        /// </summary>
        public bool IsDefault
        {
            get;
            set;
        }

        public long GetDistrictValue()
        {
            return ConvertHelper.ObjectToLong(district_customelookup.Value);
        }

        public void SetDistrictValue(long editValue)
        {
            this.district_customelookup.Value = editValue;
        }

        protected override UserControl.ASPxGridLookup _lookUp
        {
            get { return this.district_customelookup; }
        }

        protected override void BindData()
        {
            QueryInfo<T_Cm_District> queryInfo = new QueryInfo<T_Cm_District>();
            ICmDistrictDal _district = UIHelper.Resolve<ICmDistrictDal>();
            district_customelookup.DataSource = _district.Select(queryInfo);
            district_customelookup.DataBind();
            //设置当前登入人员所在地区
            if (this.IsDefault)
            {
                Guid branchID = UserProvide.GetCurrentBranchID();
                ICmBranchDal _branch = UIHelper.Resolve<ICmBranchDal>();
                QueryInfo<T_Cm_Branch> queryBranch = new QueryInfo<T_Cm_Branch>();
                queryBranch.SetQuery(T_Cm_Branch.IdColumnName, branchID);
                var branch = _branch.Select(queryBranch).FirstOrDefault();
                if (null != branch)
                {
                    district_customelookup.Value = ConvertHelper.ObjectToLong(branch.link_district);// );
                }
            }
        }
    }
}
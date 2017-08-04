using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Tool;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class UserProvide
    {
        private int recordCount = 0;

        public List<T_Cm_User> GetDataByPaging(string filter, string sorter, int PageSize, int StartRow)
        {
            var errorMessage = string.Empty;
            QueryInfo<T_Cm_User> queryInfo = new QueryInfo<T_Cm_User>();
            queryInfo.SetQuery(Constants.PageSize, PageSize);
            queryInfo.SetQuery(Constants.PageIndex, StartRow);
            PagedList<T_Cm_User> results = UIHelper.Resolve<ICmUserDal>().GetPageList(queryInfo);// GetModelListByPaging(filter, StartRow, PageSize, sorter);
            recordCount = results.total;
            return results.rows.ToList();
        }

        public int GetRowsCount(string filter)
        {
            return recordCount;
        }

        public static void LoginOut()
        {
            //删除登录用户记录
            Model.T_Cm_User user = UIHelpers.UserProvide.GetCurrentUser();
            if (user != null)
            {
                //BLL.T_Cm_User_Cache.provide.Delete(Guid.Parse(user.cache_id));
            }
            CookieHelper.ClearTicketCookie(Constants.LOGIN_COOKIE_NAME, string.Empty);
            FormsAuthentication.SignOut();
        }

        public static T_Cm_User GetCurrentUser()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return null;

            var userstr = CookieHelper.GetTicketFromCookie(Constants.LOGIN_COOKIE_NAME);
            return JsonHelper.FromJson<T_Cm_User>(userstr);
        }



        public static string GetCurrentUserName()
        {
            var user = GetCurrentUser();
            if (user != null)
                return user.emp_name;
            else
                return string.Empty;
        }

        public static string GetCurrentUserId()
        {
            var user = GetCurrentUser();
            if (user != null)
                return user.id.ToString();
            else
                return string.Empty;
        }

        public static Guid GetCurrentBranchID()
        {
            var user = GetCurrentUser();
            if (user != null)
                return user.branch_id;
            else
                return Guid.Empty;
        }

        public static dynamic GetCurrentBranch()
        {
            Guid branchID = GetCurrentBranchID();
            ICmBranchDal _branch = UIHelper.Resolve<ICmBranchDal>();
            QueryInfo<T_Cm_Branch> queryBranch = new QueryInfo<T_Cm_Branch>();
            queryBranch.SetQuery(T_Cm_Branch.IdColumnName, branchID);
            var branch = _branch.Select(queryBranch).FirstOrDefault();
            return branch;
        }

        public static int GetCurrentProvinceID()
        {
            int provinceID=0;
            dynamic branch=GetCurrentBranch();
            if (null != branch)
            {
                provinceID = branch.link_province;
            }
            return provinceID;
        }

        public static int GetCurrentCityID()
        {
            int cityID = 0;
            dynamic branch = GetCurrentBranch();
            if (null != branch)
            {
                cityID = branch.link_city;
            }
            return cityID;
        }

        public static int GetCurrentDistrictaID()
        {
            int districtID = 0;
            dynamic branch = GetCurrentBranch();
            if (null != branch)
            {
                districtID = branch.link_district;
            }
            return districtID;
        }

        public static string GetCurrentArea()
        {
            string strArea = string.Empty;
            dynamic branch = GetCurrentBranch();
            if (null != branch)
            {
                strArea = branch.link_area;
            }
            return strArea;
        }
    }
}
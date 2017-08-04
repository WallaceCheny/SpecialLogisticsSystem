using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using DevExpress.Web.ASPxGridLookup;

namespace SpecialLogisticsSystem.AppPortal
{
    public class DataBindDropDownList
    {
        public static void DataBindCode(ASPxComboBox c, QueryInfo<T_Cm_Code> queryInfo, string defaultValue)
        {
            DataBindCode(c, queryInfo);
            var defaultItem = c.Items.FindByValue(defaultValue);
            if (defaultItem != null)
                defaultItem.Selected = true;
        }
        /// <summary>
        /// 绑定字典 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindCode(ASPxComboBox c, QueryInfo<T_Cm_Code> queryInfo)
        {
            ICmCodeDal _code = UIHelper.Resolve<ICmCodeDal>();
            c.Items.Clear();
            c.TextField = T_Cm_Code.NameColumnName;
            c.ValueField = T_Cm_Code.ValueColumnName;
            IList<T_Cm_Code> codeList = _code.GetList(queryInfo);
            c.DataSource = codeList;
            c.DataBind();

            T_Cm_Code code = codeList.FirstOrDefault(p => p.is_default = true);
            if (code == null) return;
            string selectValue = code.para_value;
            var defaultItem = c.Items.FindByValue(selectValue);
            if (defaultItem != null)
                defaultItem.Selected = true;
        }
        /// <summary>
        /// 绑定员工 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindEmployee(ASPxComboBox c)
        {
            DataBindEmployee(c, string.Empty);
        }
        /// <summary>
        /// 绑定员工 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindEmployee(ASPxComboBox c, string selectValue)
        {
            ICmEmpDal _employee = UIHelper.Resolve<ICmEmpDal>();
            c.Items.Clear();
            c.TextField = T_Cm_Emp.EmpNameColumnName;
            c.ValueField = T_Cm_Emp.PropertyId;
            c.DataSource = _employee.Select(new QueryInfo<T_Cm_Emp>());
            c.DataBind();

            var defaultItem = c.Items.FindByValue(selectValue);
            if (defaultItem != null)
                defaultItem.Selected = true;
        }

        /// <summary>
        /// 绑定机构 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindBranch(ASPxGridLookup c)
        {
            DataBindBranch(c, string.Empty);
        }
        /// <summary>
        /// 绑定机构 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindBranch(ASPxGridLookup c, string selectValue)
        {
            ICmBranchDal _branch = UIHelper.Resolve<ICmBranchDal>();

            c.DataSource = _branch.Select(new QueryInfo<T_Cm_Branch>());
            c.DataBind();


        }
        /// <summary>
        /// 绑定机构 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindBranch(ASPxComboBox c)
        {
            DataBindBranch(c, string.Empty);
        }
        /// <summary>
        /// 绑定机构 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindBranch(ASPxComboBox c, string selectValue)
        {
            ICmBranchDal _branch = UIHelper.Resolve<ICmBranchDal>();
            c.Items.Clear();
            c.TextField = T_Cm_Branch.NameColumnName;
            c.ValueField = T_Cm_Branch.IdColumnName;
            c.DataSource = _branch.Select(new QueryInfo<T_Cm_Branch>());
            c.DataBind();

            var defaultItem = c.Items.FindByValue(selectValue);
            if (defaultItem != null)
                defaultItem.Selected = true;
        }
        /// <summary>
        /// 绑定省份 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindProvince(ASPxComboBox c)
        {
            DataBindProvince(c, string.Empty);
        }
        /// <summary>
        /// 绑定省份 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindProvince(ASPxComboBox c, string selectValue)
        {
            ICmProvinceDal _province = UIHelper.Resolve<ICmProvinceDal>();
            c.Items.Clear();
            c.TextField = T_Cm_Province.ProvincenameColumnName;
            c.ValueField = T_Cm_Province.ProvinceidColumnName;
            c.DataSource = _province.GetList(new QueryInfo<T_Cm_Province>());
            c.DataBind();

            var defaultItem = c.Items.FindByValue(selectValue);
            if (defaultItem != null)
                defaultItem.Selected = true;
        }
        /// <summary>
        /// 绑定城市 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindCity(ASPxComboBox c, object provinceID)
        {
            DataBindCity(c, provinceID, string.Empty);
        }
        /// <summary>
        /// 绑定城市 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindCity(ASPxComboBox c, object provinceID, string selectValue)
        {
            ICmCityDal _city = UIHelper.Resolve<ICmCityDal>();
            QueryInfo<T_Cm_City> queryInfo = new QueryInfo<T_Cm_City>();
            queryInfo.SetQuery(T_Cm_City.ProvinceidColumnName, provinceID);
            c.TextField = T_Cm_City.CitynameColumnName;
            c.ValueField = T_Cm_City.CityidColumnName;
            c.DataSource = _city.GetList(queryInfo);
            c.DataBind();

            var defaultItem = c.Items.FindByValue(selectValue);
            if (defaultItem != null)
                defaultItem.Selected = true;
        }
        /// <summary>
        /// 绑定地区 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindDistrict(ASPxComboBox c, object cityID)
        {
            DataBindDistrict(c, cityID, string.Empty);
        }
        /// <summary>
        /// 绑定地区 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="strSql"></param>
        public static void DataBindDistrict(ASPxComboBox c, object cityID, string selectValue)
        {
            ICmDistrictDal _district = UIHelper.Resolve<ICmDistrictDal>();
            c.Items.Clear();
            c.TextField = T_Cm_District.DistrictnameColumnName;
            c.ValueField = T_Cm_District.DistrictidColumnName;
            QueryInfo<T_Cm_District> queryInfo = new QueryInfo<T_Cm_District>();
            queryInfo.SetQuery(T_Cm_District.CityidColumnName, cityID);
            c.DataSource = _district.GetList(queryInfo);
            c.DataBind();

            var defaultItem = c.Items.FindByValue(selectValue);
            if (defaultItem != null)
                defaultItem.Selected = true;
        }
    }
}
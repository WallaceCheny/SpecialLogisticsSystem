using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class Constants
    {
        public const string LOGIN_COOKIE_NAME = "__UserPortalIDENTITY";
        public const string USER_COOKIE_CURRENTDEPARTMENT = "__UserCurrentDepartment";
        public const string THEME_COOKIE_NAME = "__UserPortalTheme";
        public const string CULTURE_COOKIE_NAME = "__UserPortalCulture";

        public const string DEFAULT_CULTURE = "zh";
        public const string DEFAULT_THEME_NAME = "AP970";

        public const string MailFrom = "MailFrom";
        public const string MailTemplatePath = "MailTemplatePath";
        public const string PageSize = "pageSize";
        public const string PageIndex = "pageIndex";
        public const string StartRow = "startRow";
        public const string MaxRows = "maxRows";
        public const string OrderBy = "OrderBy";
        public const string PaymentCount = "PaymentCount";
        public const string LogoFolder = "LogoFolder";
        public const string WebUrl = "WebUrl";
        public const string FaqEmailTo = "FaqEmailTo";
        public const string SERVICE_AS = "service_as";
        public const string PRODUCT_TYPE = "product_type";
        public const string StowageDetail = "StowageDetail";
        public const string TransferDetail = "TransferDetail";
        public const string DeliverDetail = "DeliverDetail";
        public const string ProductionDetail = "Production";

        public const string DEPARTMENT_TYPE = "部门信息";

        public const string strCpMessage="cp_callbackMsg";
        public const string strCannotDelete = "【{0}】 被{1}引用，无法删除！";
        public const string strCpShowPopup = "cp_showPopup";
        public const string strCpFinish = "cp_Finish";
        public const string strSuccessMessage = "删除成功！";
        public const string strNoMessage = "暂无信息";

        public const string WAY_BILL = "托运单";

        public const char splitChar = ',';
        


        /// <summary>
        /// 客户分类
        /// </summary>
        public const string CUSTOMER_TYPE = "CUSTOMER_TYPE";
        /// <summary>
        /// 客户资料角色名称
        /// </summary>
        public const string CUSTOMER_ROLE = "CUSTOMER_ROLE";
        public const string PRODUCT_UNIT = "product_unit";
        

        /// <summary>
        /// 用户信息保存时间
        /// </summary>
        public const int USER_COOKIE_SAVETIME = 60 * 24 * 365;
    }
}
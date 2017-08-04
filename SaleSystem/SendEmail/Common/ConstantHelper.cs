using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Common
{
    /// <summary>
    /// this class will save the constants for all over website.
    /// </summary>
    public static class ConstantHelper
    {
        #region Error message
        public static readonly string errorLogin = "Please enter a correct email or password.";
        public static readonly string errorConnection01 = "Code(01001): Database connection failure.";
        public static readonly string errorConnection02 = "Code(02001): Please try again later or contact the web administrator.";
        public static readonly string errorSendEmailWhenNewIndividual = "Error sending welcome email to {0} when creating a new account.";
        public static readonly string errorSendEmailWhenForetUserId = "Error sending email to {0} when retrieving the user id.";
        public static readonly string errorNotFindEmail = "Invalid user.";
        #endregion

        #region Page path
        public static readonly string errorPage = "~/Error.aspx";
        public static readonly string homePage = "~/Default.aspx";
        public static readonly string adminHomePage = "/Manage/Home.aspx";
        public static readonly string adminLoginPage = "~/Manage/Login.aspx";
        public static readonly string loginPage = "~/User/SignIn.aspx";
        public static readonly string registerPage = "~/User/Register.aspx";
        public static readonly string SHOP_PAGE = "~/Order/Shop.aspx";
        public static readonly string MEMBER_PAGE = "/Member/Member.aspx";
        public static readonly string MYDINNER_PAGE = "/Member/MyDinner.aspx";
        public static readonly string FINISH_PAGE = "/Shop/FinishMessage.aspx";
        #endregion

        #region string
        public static readonly string DefaultImage = "/images/member/photo.png";
        public static readonly string SiteId = "1000";
        public static readonly string pageSize = "PageSize";
        public static readonly string errorString = "error";
        public static readonly string defaultNullItem = "--";
        public static readonly string startIndex = "0";
        public static readonly int beginYear = 1910;
        public static readonly string DateFormat = "yyyy/MM/dd";
        public static readonly string SESSION_USER_ID = "SESSION_USER_ID";
        public static readonly string SESSION_LEGACY_ID = "SESSION_LEGACY_ID";

        public static readonly string SESSION_USER_FIRSTNAME = "SESSION_USER_FIRSTNAME";
        public static readonly string SESSION_SEGMENTATION = "SESSION_SEGMENTATION";
        public static readonly string SESSION_SEGMENTED_HOMEPAGE = "SESSION_SEGMENTED_HOMEPAGE";
        public static readonly string SUCCESSFUL = "Update successful";
        public static readonly string UNSUCCESSFUL = "Update failed, please contact the web administrator";
        public static readonly string SESSION_RETURN_URL = "SESSION_RETURN_URL";
        public static readonly string COOKIE_USERID = "COOKIE_USERID";
        public static readonly string COOKIE_LEGACY_USERID = "COOKIE_LEGACY_USERID";
        public static readonly string COOKIE_USERFIRSTNAME = "COOKIE_USERFIRSTNAME";
        public static readonly string COOKIE_USERNAME = "COOKIE_USERNAME";
        public static readonly string COOKIE_PASSWORD = "COOKIE_PASSWORD";
        public static readonly string tips = "How confident are you? Please specify.";
        public static readonly string DISPLAY_VIDEOS_IN_CONFIG = "display_videos";
        public static readonly string DISPLAY_COUPON_IN_CONFIG = "display_coupon";

        public static readonly string QUERY_STRING_PAGE = "page";
        public static readonly string QUERY_STRING_INDEX = "index";
        public static readonly string MONTH_YEAR = "MMyyyy";

        public static readonly string RETURN_URL = "return";
        public static readonly string SESSION_ADMIN = "SESSION_ADMIN";
        #endregion

        #region enum
        /// <summary>
        /// The menu of site
        /// </summary>
        public enum MainMenu
        {
            DiabetesBasics = 1,
            DiabetesMedicines = 2,
            CornerstonesofCare = 3,
            BeyondtheBasics = 4,
            HelpfulToolsResources = 5,
            User = 6,
            HelpfulToolsResourcesGuideMe = 7
        }

        public enum ShopStatue
        {
            [Description("未激活")]
            InActivity = 0,
            [Description("激活且签约")]
            Activity = 1,
            [Description("非签约")]
            NoSign=2,
        }

        public enum Role
        {
            User = 0,
            Manger = 1,
            Shopkeeper = 2
        }

        #endregion

        #region Class
        public struct Link
        {
            public string Name
            {
                get;
                set;
            }

            public string Url
            {
                get;
                set;
            }

            public string Description
            {
                get;
                set;
            }

            public string CssClass
            {
                get;
                set;
            }
        }


        public class DataValue
        {
            public string Name { get; set; }
            public string Value { get; set; }

        }
        #endregion
    }
}

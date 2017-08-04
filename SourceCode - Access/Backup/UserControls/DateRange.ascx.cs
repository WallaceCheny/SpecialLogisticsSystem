using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    //http://www.2cto.com/kf/201008/55659.html
    public partial class DateRange : BaseUserControl
    {
        //public bool IsPrevious
        //{
        //    set
        //    {
        //        if (value)
        //        {

        //            //config.parameter_value

        //        }
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            QueryInfo<T_Cm_Config> queryInfo = new QueryInfo<T_Cm_Config>();
            ICmConfigDal _config = UIHelper.Resolve<ICmConfigDal>();
            List<T_Cm_Config> configList = _config.GetList(queryInfo).ToList();
            T_Cm_Config config = configList.FirstOrDefault(p => p.parameter_name == ConfigType.SearchType.ToString());
            if (null == config)
            {
                receive_date_start.Date = DateTime.Now.AddMonths(-1);
            }
            else
            {
                SearchType type = (SearchType)Enum.Parse(typeof(SearchType), config.parameter_value);
                DateTime dt = DateTime.Now;  //当前时间
                switch (type)
                {
                    case SearchType.ByDate:
                        receive_date_start.Date = dt.AddDays(-1);
                        break;
                    case SearchType.ByWeek:
                        DateTime startWeek = GetMondayDate(dt);  //本周周一
                        receive_date_start.Date = startWeek;
                        break;
                    case SearchType.ByMonth:
                        DateTime startMonth = dt.AddDays(1 - dt.Day);  //本月月初
                        receive_date_start.Date = startMonth;
                        break;
                    case SearchType.BySeason:
                       DateTime startQuarter = dt.AddMonths(0 - (dt.Month - 1) % 3).AddDays(1 - dt.Day);  //本季度初
                       receive_date_start.Date = startQuarter;
                        break;
                    case SearchType.ByYear:
                        DateTime startYear = new DateTime(dt.Year, 1, 1);  //本年年初
                        receive_date_start.Date = startYear;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary> 
        /// 计算某日起始日期（礼拜一的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns> 
        public static DateTime GetMondayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Subtract(ts);
        }
        /// <summary> 
        /// 计算某日结束日期（礼拜日的日期） 
        /// </summary> 
        /// <param name="someDate">该周中任意一天</param> 
        /// <returns>返回礼拜日日期，后面的具体时、分、秒和传入值相等</returns> 
        public static DateTime GetSundayDate(DateTime someDate)
        {
            int i = someDate.DayOfWeek - DayOfWeek.Sunday;
            if (i != 0) i = 7 - i;// 因为枚举原因，Sunday排在最前，相减间隔要被7减。 
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return someDate.Add(ts);
        }
    }
}
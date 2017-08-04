using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using Newtonsoft.Json;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class WayProvider
    {
        private int recordCount;

        public List<dynamic> GetDataByPaging(string filter, string sorter, int PageSize, int StartRow)
        {
            var errorMessage = string.Empty;
            QueryInfo<T_Way_Bill> queryInfo = new QueryInfo<T_Way_Bill>();
            Dictionary<string, object> query = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
            if (query != null)
            {
                queryInfo.SetQuery(query.Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString())).ToDictionary(x => x.Key, y => y.Value));
            }
            if (PageSize > 0)
            {
                queryInfo.SetQuery(Constants.PageSize, PageSize);
                queryInfo.SetQuery(Constants.PageIndex, StartRow / PageSize + 1);
                queryInfo.SetXml("SelectPaging");
            }
           
            IList<dynamic> results = UIHelper.Resolve<IWayBillDal>().Select(queryInfo);
            return results.ToList();
        }

        public int GetRowsCount(string filter)
        {
            QueryInfo<T_Way_Bill> queryInfo = new QueryInfo<T_Way_Bill>();
            Dictionary<string, object> query = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
            if (query != null)
            {
                queryInfo.SetQuery(query.Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString())).ToDictionary(x => x.Key, y => y.Value));
            }
            recordCount = UIHelper.Resolve<IWayBillDal>().GetTotal(queryInfo);
            return recordCount;
        }
    }
}
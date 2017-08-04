using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public abstract class BaseProvider<T1> where T1 : Entity, new()
    {
        protected abstract IList<dynamic> GetSelect(QueryInfo<T1> queryInfo);
        protected abstract int GetTotal(QueryInfo<T1> queryInfo);
        protected virtual string GetXmlName()
        {
            return "SelectPaging";
        }

        public virtual List<dynamic> GetDataByPaging(string filter, string sorter, int startRow, int maxRows)
        {
            QueryInfo<T1> queryInfo = GetQueryInfo(filter);
            if (!string.IsNullOrEmpty(sorter)) queryInfo.Query.Add(Constants.OrderBy, sorter);
            if (maxRows == 0) maxRows = 15;
            if (startRow > 0)
            {
                queryInfo.SetQuery(Constants.StartRow, startRow);
            }
            queryInfo.SetQuery(Constants.MaxRows, maxRows);
            queryInfo.SetXml(GetXmlName());
            IList<dynamic> results = GetSelect(queryInfo);
            return results.ToList();
        }

        public virtual int GetRowsCount(string filter)
        {
            QueryInfo<T1> queryInfo = GetQueryInfo(filter);
            int recordCount = GetTotal(queryInfo);
            return recordCount;
        }

        private QueryInfo<T1> GetQueryInfo(string filter)
        {
            QueryInfo<T1> queryInfo = new QueryInfo<T1>();
            Dictionary<string, object> query = JsonConvert.DeserializeObject<Dictionary<string, object>>(filter);
            if (query != null)
            {
                queryInfo.SetQuery(query.Where(p => p.Value != null
                    && !string.IsNullOrEmpty(p.Value.ToString())).ToDictionary(x => x.Key, y => y.Value));
            }
            return queryInfo;
        }
    }
}
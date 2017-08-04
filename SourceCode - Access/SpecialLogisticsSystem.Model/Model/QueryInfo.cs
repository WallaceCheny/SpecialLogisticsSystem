using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialLogisticsSystem.Model
{
    [Serializable]
    public class QueryInfo<T> where T : Entity, new()
    {
        public Type MappingType;
        /// <summary>
        /// 附加参数
        /// </summary>
        public Dictionary<string, object> Query { get; set; }
        public QueryInfo()
        {
            MappingType = typeof(T); Query = new Dictionary<string, object>();
        }
        public QueryInfo(Dictionary<string, object> _query)
        {
            MappingType = typeof(T); if (Query == null) Query = new Dictionary<string, object>(); Query = Query.Concat(_query).ToDictionary(x => x.Key, y => y.Value);
        }
        public QueryInfo<T> SetQuery(string key, object value)
        {
            Query.Add(key, value);
            return this;
        }
        public QueryInfo<T> SetQuery(Dictionary<string, object> _query)
        {
            Query = Query.Concat(_query).ToDictionary(x => x.Key, y => y.Value);
            return this;
        }
        public QueryInfo<T> SetXml(string ID)
        {
            XmlID = ID;
            return this;
        }
        public QueryInfo<T> SetPageXmlID(string ID)
        {
            PageXmlID = ID;
            return this;
        }
        public string ConnectionName { get; set; }
        /// <summary>
        /// 自定义XML节点ID
        /// </summary>
        public string XmlID { get; set; }
        /// <summary>
        /// 自定义分页总记录XML节点ID(只有分页有用)
        /// </summary>
        public string PageXmlID { get; set; }
        public object PrimaryKeyValue { get; set; }
    }
}

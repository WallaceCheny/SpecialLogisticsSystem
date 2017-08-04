using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Ms.Data.Common;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.Dal
{
    public class DaoInfo
    {
        protected DBHelper dbHelper = DBHelper.Current;
        protected MappingModel cacheItem { get; set; }
        protected Dictionary<string, MappingModel> cacheData;
        public DaoInfo()
        {
            if (cacheData == null) cacheData = new LoadMapping().GetMappingModel();        
        }

        public dynamic ModeltoDynamic<T>(T entity) where T : Entity, new()
        {
            Type type = entity.MappingType();
            var properties = type.GetProperties();
            DynamicRecord dr = new DynamicRecord();
            foreach (var propertyInfo in properties)
                dr.SetField(propertyInfo.Name, propertyInfo.GetValue(entity, null), propertyInfo.PropertyType);
            return dr;
        }
        public T DynamictoModel<T>(dynamic entity) where T : Entity, new()
        {
            T model = new T();
            var properties = model.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(Model.NoColumn), false).Length != 1);
            foreach (var propertyInfo in properties)
            {
                object result = null;
                object value = entity[propertyInfo.Name];
                Type type = propertyInfo.PropertyType;
                if (IsNullableType(type))
                    result = Convert.ChangeType(value, Nullable.GetUnderlyingType(type));
                else
                    result = Convert.ChangeType(value, type);
                propertyInfo.SetValue(model, result, null);
            }
            return model;
        }
        public int GetPrimaryKey
        {
            get
            {
                return Math.Abs(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
            }
        }
        private bool IsNullableType(Type theType)
        {
            return (theType.IsGenericType && theType.
              GetGenericTypeDefinition().Equals
              (typeof(Nullable<>)));
        }
        protected Tuple<string, Parameter[]> GetSelectSql<T>(string sql, QueryInfo<T> queryInfo) where T : Entity, new()
        {
            Dictionary<string, Parameter> parameterList = new Dictionary<string, Parameter>();
            foreach (var query in queryInfo.Query)
                parameterList.Add(query.Key, new Parameter { ParameterName = query.Key, Value = query.Value });
            if (queryInfo.PrimaryKeyValue != null)
            {
                Type type = queryInfo.MappingType;
                string primaryKey = (from properties in type.GetProperties()
                                     where properties.GetCustomAttributes(typeof(PrimaryKey), false).Length >= 1
                                     select properties.Name).First();
                if (!parameterList.ContainsKey(primaryKey))
                    parameterList.Add(primaryKey, new Parameter { ParameterName = primaryKey, Value = queryInfo.PrimaryKeyValue });
                queryInfo.Query.Add(primaryKey, queryInfo.PrimaryKeyValue);
            }
            //string cacheKey = queryInfo.XmlID + "-" + queryInfo.Query.Values.Aggregate((i, j) => string.Format("{0}-{1}", i, j)).ToString();
            //if (CacheHelper.Current.Get(cacheKey) == null)
            //{
            string pattern = string.Empty;
            #region 解析where
            pattern = @"(where)([^.]+?)(\$(and|or|eg|eq){[^{}]+?})";
            sql = Regex.Replace(sql, pattern, (match) =>
            {
                string query = match.Value;
                if (match.Groups[2].Value.ToLower().Trim() == string.Empty)
                {
                    string where = query.Substring(0, 5);
                    query = query.Replace(where, where + " 1=1");
                }
                return query;
            }, RegexOptions.IgnoreCase);
            #endregion
            #region 解析条件
            pattern = @"\$(and|or|eg|eq){[^{}]+?}";
            while (Regex.IsMatch(sql, pattern, RegexOptions.IgnoreCase))
            {
                sql = Regex.Replace(sql, pattern, delegate(Match m)
                {
                    string query = string.Empty, funName = m.Groups[1].Value;
                    var matches = Regex.Matches(m.Value, @"(#|\$)[^{}]+?(#|\$)", RegexOptions.IgnoreCase);
                    foreach (Match match in matches)
                    {
                        string quy = match.Value.Trim(new char[] { '$', '#' });
                        string frist = match.Groups[1].Value;
                        if (frist == "#")
                        {
                            Match wmatch = Regex.Match(quy, @"\w+", RegexOptions.IgnoreCase);
                            if (wmatch.Success)
                                quy = wmatch.Value;
                        }
                        var key = queryInfo.Query.Where(d => quy.Equals(d.Key, StringComparison.OrdinalIgnoreCase));
                        if (key.Count() > 0)
                        {
                            var queryModel = key.First();
                            query = (query != string.Empty ? query : m.Value);
                            if (frist == "#")
                                query = query.Replace(match.Value, dbHelper.IProvider.GetParameterName(queryModel.Key));
                            else if (frist == "$")
                            {
                                query = query.Replace(match.Value, queryModel.Value.ToString());
                                parameterList.Remove(key.First().Key);
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(query))
                    {
                        if (funName.Equals("and", StringComparison.OrdinalIgnoreCase) || funName.Equals("or", StringComparison.OrdinalIgnoreCase))
                            query = query.Replace("$", string.Empty).Replace("{", " (").Replace("}", ")");
                        else if (funName.Equals("eq", StringComparison.OrdinalIgnoreCase))
                            query = query.Substring(query.IndexOf("$" + funName, StringComparison.OrdinalIgnoreCase) + 3).TrimStart('{').TrimEnd('}');
                        else if (funName.Equals("eg", StringComparison.OrdinalIgnoreCase))
                            query = query.Substring(query.IndexOf("$" + funName, StringComparison.OrdinalIgnoreCase) + 3).Replace("{", "(").Replace("}", ")");
                        else query = string.Empty;
                    }
                    return query;
                }, RegexOptions.IgnoreCase);
            }
            #endregion
            #region 去掉1=1 and|or
            sql += " ";
            pattern = @"(where(\s*))(1[^.]?1)(((\s*)(order|group|having|and|or|([^.]+?))(\S?)))";
            /*
             Select ID_rol,Name_rol,Description_rol FROM iR_Role_rol where 1=1 and userid=(
                Select ID_rol,Name_rol,Description_rol FROM iR_Role_rol where   1=1    order   by ID_rol desc

                Select ID_rol,Name_rol,Description_rol FROM iR_Role_rol where 1=1  and vd=11
                Select ID_rol,Name_rol,Description_rol FROM iR_Role_rol where row_Num BETWEEN @pageIndex-1*@pageSize+1 and @pageIndex*@pageSize)
                Select ID_rol,Name_rol,Description_rol FROM iR_Role_rol where 1=1 
             Success	Index	Length	 Value
                True	56	        13	 where 1=1 and
                True	140	        23	 where 1=1 order
                True	241	        14	 where 1=1 and
                True	453	        10	 where 1=1
             Select ID_usr,UserName_usr,UserCode_usr,Password_usr,Email_usr,DeptID_usr,Lang_usr,LoginTime_usr,LoginNum_usr,LoginIP_usr,RegTime_usr,IsClose_usr FROM(
Select ID_usr,UserName_usr,UserCode_usr,Password_usr,Email_usr,DeptID_usr,Lang_usr,LoginTime_usr,LoginNum_usr,LoginIP_usr,RegTime_usr,IsClose_usr
,ROW_NUMBER() Over(order by ID_usr desc) as row_Num
FROM iR_User_usr where 1=1) t
where row_Num BETWEEN @pageIndex-1*@pageSize+1 and @pageIndex*@pageSize)
                True	453	        10	 where 1=1)
             */
            sql = Regex.Replace(sql, pattern, (match) =>
            {
                string query = match.Value.Trim();
                string where = match.Groups[1].Value;
                string _1_1 = match.Groups[3].Value;
                switch (match.Groups[4].Value.ToLower().Trim())
                {
                    case "":
                    case "order":
                    case "group":
                    case "having":
                        query = query.Replace(where, string.Empty).Replace(_1_1, string.Empty) + " ";
                        break;
                    case "and":
                    case "or":
                        query = query.Replace(match.Groups[4].Value, string.Empty).Replace(_1_1, string.Empty);
                        break;
                    default:
                        query = query.Replace(_1_1, string.Empty);
                        if (query.Replace(where, string.Empty).Trim().Substring(0, 1) == ")")
                            query = query.Replace(where, string.Empty);
                        break;
                }
                return query;
            }, RegexOptions.IgnoreCase);
            sql = sql.TrimEnd(' ');
            #endregion
            #region old解析where
            //sql += " ";
            //pattern = @"(where[^.]+?)((1[^.]+?1)|(\w+)|(\s*$))";
            //sql = Regex.Replace(sql, pattern, delegate(Match match)
            //{
            //    string query = match.Value;
            //    string where = query.Substring(0, 5);
            //    string whereLast = query.Substring(5).Replace("(", string.Empty).Replace(")", string.Empty).Trim();
            //    if (string.IsNullOrEmpty(whereLast))
            //        query = query.Replace(where, string.Empty);
            //    else
            //    {
            //        if (whereLast.Equals("and", StringComparison.OrdinalIgnoreCase) || whereLast.Equals("or", StringComparison.OrdinalIgnoreCase))
            //            query = query.Replace(where, where + " 1=1");
            //        if (whereLast.Equals("order", StringComparison.OrdinalIgnoreCase) || whereLast.Equals("group", StringComparison.OrdinalIgnoreCase)
            //            || whereLast.Equals("having", StringComparison.OrdinalIgnoreCase))
            //            query = query.Replace(where, string.Empty);
            //    }
            //    return query;
            //}, RegexOptions.IgnoreCase);
            #endregion
            var tuple = Tuple.Create(sql, parameterList.Values.ToArray());
            //CacheHelper.Current.Set(cacheKey, tuple);
            return tuple;
            //}
            //else
            //    return (Tuple<string, Parameter[]>)CacheHelper.Current.Get(cacheKey);
        }
        protected Tuple<string, Parameter[]> GetOtherSql<T>(T entity) where T : Entity, new()
        {
            string sql = string.Empty;
            switch (entity.GetState())
            {
                case EntityState.Added:
                    sql = InsertSql(entity);
                    break;
                case EntityState.Modified:
                    sql = UpdateSql(entity);
                    break;
                case EntityState.Deleted:
                    sql = DeleteSql(entity);
                    break;
            }
            return GetOtherSql(sql, entity);
        }
        protected Tuple<string, Parameter[]> GetOtherSql<T>(string sql, T entity) where T : Entity, new()
        {
            if (entity.GetState() == EntityState.Added)
            {
                bool isCodeAuto = entity.GetIsAutoPrimaryKey();
                if (isCodeAuto)
                {
                    var pk = entity.GetPkPropertyInfo();
                    if (pk.GetValue(entity, null) == null)
                        pk.SetValue(entity, Guid.NewGuid(), null);
                        //pk.SetValue(entity, Math.Abs(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)), null);
                }
            }
            Type t = entity.MappingType();
            Dictionary<string, Parameter> parameterList = new Dictionary<string, Parameter>();
            var propertyInfos = from properties in t.GetProperties()
                                where properties.GetCustomAttributes(typeof(NoColumn), false).Length == 0
                                select properties;
            string pattern = @"(#|\$)([^.]+?)(#|\$)";
            sql = Regex.Replace(sql, pattern, delegate(Match m)
            {
                string query = string.Empty;
                var queryModel = propertyInfos.FirstOrDefault(d => m.Groups[2].Value.ToLower() == d.Name.ToLower());
                if (queryModel != null)
                {
                    query = (query != string.Empty ? query : m.Value);
                    if (m.Groups[1].Value == "#")
                    {
                        Parameter parameter = new Parameter { ParameterName = queryModel.Name, Value = queryModel.GetValue(entity, null) };
                        query = query.Replace(m.Value, dbHelper.IProvider.GetParameterName(parameter.ParameterName));
                        if (!parameterList.ContainsKey(parameter.ParameterName))
                            parameterList.Add(parameter.ParameterName, parameter);
                    }
                    else
                        query = query.Replace(m.Value, queryModel.GetValue(entity, null).ToString());
                }
                return query;
            }, RegexOptions.IgnoreCase);
            return Tuple.Create(sql, parameterList.Values.ToArray());
        }
        protected Tuple<string, Parameter[]> GetOtherSql<T>(string sql, QueryInfo<T> queryInfo) where T : Entity, new()
        {
            string pattern = @"(#|\$)([^.]+?)(#|\$)";
            sql = Regex.Replace(sql, pattern, delegate(Match m)
            {
                string query = string.Empty;
                //var key = queryInfo.Query.Where(d => m.Groups.Cast<Group>().FirstOrDefault(g => g.Value.ToLower() == d.Key.ToLower()) != null);
                var key = queryInfo.Query.Where(d => m.Groups[2].Value.ToLower() == d.Key.ToLower());
                if (key.Count() > 0)
                {
                    var queryModel = key.First();
                    query = (query != string.Empty ? query : m.Value);
                    if (m.Groups[1].Value == "#")
                        query = query.Replace(m.Value, dbHelper.IProvider.GetParameterName(queryModel.Key));
                    else
                        query = query.Replace(m.Value, queryModel.Value.ToString());
                }
                return query;
            }, RegexOptions.IgnoreCase);
            List<Parameter> parameterList = new List<Parameter>();
            foreach (var query in queryInfo.Query)
                parameterList.Add(new Parameter { ParameterName = query.Key, Value = query.Value });
            return Tuple.Create(sql, parameterList.ToArray());
        }
        #region queryInfo 使用
        protected string SelectSql<T>(QueryInfo<T> queryInfo, string loadName) where T : Entity, new()
        {
            string tableName = queryInfo.MappingType.Name;
            cacheItem = cacheData[tableName];
            string fullName = queryInfo.MappingType.FullName;
            fullName = fullName.Substring(0, fullName.LastIndexOf('.') + 1);
            string xmlID = queryInfo.XmlID;
            if (string.IsNullOrEmpty(xmlID))
            {
                xmlID = fullName + tableName + "." + loadName + "_" + dbHelper.ProviderTypes.ToString();
                if (cacheItem.Select.ContainsKey(xmlID))
                    return cacheItem.Select[xmlID];
                return cacheItem.Select[fullName + tableName + "." + loadName];
            }
            else
            {
                if (loadName == "Count")
                {
                    if (!string.IsNullOrEmpty(queryInfo.PageXmlID))
                        xmlID = fullName + tableName + "." + queryInfo.PageXmlID;
                    else
                    {
                        if (!queryInfo.XmlID.Equals("PageLoad", StringComparison.OrdinalIgnoreCase))
                            xmlID = fullName + tableName + ".Count_" + queryInfo.XmlID;
                    }
                }
                else
                    xmlID = fullName + tableName + "." + xmlID;
            }
            if (cacheItem.Select.ContainsKey(xmlID))
                return cacheItem.Select[xmlID];
            else
            {
                if (loadName == "Count")
                    return cacheItem.Select[fullName + tableName + ".Count"];
                return string.Empty;
            }
        }
        protected string InsertSql<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            string tableName = queryInfo.MappingType.Name;
            cacheItem = cacheData[tableName];
            string fullName = queryInfo.MappingType.FullName;
            fullName = fullName.Substring(0, fullName.LastIndexOf('.') + 1);
            string xmlID = queryInfo.XmlID;
            if (string.IsNullOrEmpty(xmlID))
            {
                xmlID = fullName + tableName + ".Insert_" + dbHelper.ProviderTypes.ToString();
                if (cacheItem.Insert.ContainsKey(xmlID))
                    return cacheItem.Insert[xmlID];
                return cacheItem.Insert[fullName + tableName + ".Insert"];
            }
            else
                xmlID = fullName + tableName + "." + xmlID;
            if (cacheItem.Insert.ContainsKey(xmlID))
                return cacheItem.Insert[xmlID];
            else
                return string.Empty;
        }
        protected string UpdateSql<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            string tableName = queryInfo.MappingType.Name;
            cacheItem = cacheData[tableName];
            string fullName = queryInfo.MappingType.FullName;
            fullName = fullName.Substring(0, fullName.LastIndexOf('.') + 1);
            string xmlID = queryInfo.XmlID;
            if (string.IsNullOrEmpty(xmlID))
            {
                xmlID = fullName + tableName + ".Update_" + dbHelper.ProviderTypes.ToString();
                if (cacheItem.Update.ContainsKey(xmlID))
                    return cacheItem.Update[xmlID];
                return cacheItem.Update[fullName + tableName + ".Update"];
            }
            else
                xmlID = fullName + tableName + "." + xmlID;
            if (cacheItem.Update.ContainsKey(xmlID))
                return cacheItem.Update[xmlID];
            else
                return string.Empty;
        }
        protected string DeleteSql<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            string tableName = queryInfo.MappingType.Name;
            cacheItem = cacheData[tableName];
            string fullName = queryInfo.MappingType.FullName;
            fullName = fullName.Substring(0, fullName.LastIndexOf('.') + 1);
            string xmlID = queryInfo.XmlID;
            if (string.IsNullOrEmpty(xmlID))
            {
                xmlID = fullName + tableName + ".Delete_" + dbHelper.ProviderTypes.ToString();
                if (cacheItem.Delete.ContainsKey(xmlID))
                    return cacheItem.Delete[xmlID];
                return cacheItem.Delete[fullName + tableName + ".Delete"];
            }
            else
                xmlID = fullName + tableName + "." + xmlID;
            if (cacheItem.Delete.ContainsKey(xmlID))
                return cacheItem.Delete[xmlID];
            else
                return string.Empty;
        }
        protected string ProcedureSql<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            string tableName = queryInfo.MappingType.Name;
            cacheItem = cacheData[tableName];
            string fullName = queryInfo.MappingType.FullName;
            fullName = fullName.Substring(0, fullName.LastIndexOf('.') + 1);
            string xmlID = queryInfo.XmlID;
            if (string.IsNullOrEmpty(xmlID))
            {
                xmlID = fullName + tableName + ".Procedure_" + dbHelper.ProviderTypes.ToString();
                if (cacheItem.Procedure.ContainsKey(xmlID))
                    return cacheItem.Procedure[xmlID];
                return cacheItem.Procedure[fullName + tableName + ".Procedure"];
            }
            else
                xmlID = fullName + tableName + "." + xmlID;
            if (cacheItem.Procedure.ContainsKey(xmlID))
                return cacheItem.Procedure[xmlID];
            else
                return string.Empty;
        }
        #endregion
        #region entity使用
        protected string InsertSql<T>(T entity) where T : Entity, new()
        {
            string tableName = entity.MappingType().Name;
            cacheItem = cacheData[tableName];
            string fullName = entity.MappingType().FullName;
            fullName = fullName.Substring(0, fullName.LastIndexOf('.') + 1);
            string xmlID = entity.GetXmlID();
            if (string.IsNullOrEmpty(xmlID))
            {
                xmlID = fullName + tableName + ".Insert_" + dbHelper.ProviderTypes.ToString();
                if (cacheItem.Insert.ContainsKey(xmlID))
                    return cacheItem.Insert[xmlID];
                return cacheItem.Insert[fullName + tableName + ".Insert"];
            }
            else
                xmlID = fullName + tableName + "." + xmlID;
            if (cacheItem.Insert.ContainsKey(xmlID))
                return cacheItem.Insert[xmlID];
            else
                return string.Empty;
        }
        protected string UpdateSql<T>(T entity) where T : Entity, new()
        {
            string tableName = entity.MappingType().Name;
            cacheItem = cacheData[tableName];
            string fullName = entity.MappingType().FullName;
            fullName = fullName.Substring(0, fullName.LastIndexOf('.') + 1);
            string xmlID = entity.GetXmlID();
            if (string.IsNullOrEmpty(xmlID))
            {
                xmlID = fullName + tableName + ".Update_" + dbHelper.ProviderTypes.ToString();
                if (cacheItem.Update.ContainsKey(xmlID))
                    return cacheItem.Update[xmlID];
                return cacheItem.Update[fullName + tableName + ".Update"];
            }
            else
                xmlID = fullName + tableName + "." + xmlID;
            if (cacheItem.Update.ContainsKey(xmlID))
                return cacheItem.Update[xmlID];
            else
                return string.Empty;
        }
        protected string DeleteSql<T>(T entity) where T : Entity, new()
        {
            string tableName = entity.MappingType().Name;
            cacheItem = cacheData[tableName];
            string fullName = entity.MappingType().FullName;
            fullName = fullName.Substring(0, fullName.LastIndexOf('.') + 1);
            string xmlID = entity.GetXmlID();
            if (string.IsNullOrEmpty(xmlID))
            {
                xmlID = fullName + tableName + ".Delete_" + dbHelper.ProviderTypes.ToString();
                if (cacheItem.Delete.ContainsKey(xmlID))
                    return cacheItem.Delete[xmlID];
                return cacheItem.Delete[fullName + tableName + ".Delete"];
            }
            else
                xmlID = fullName + tableName + "." + xmlID;
            if (cacheItem.Delete.ContainsKey(xmlID))
                return cacheItem.Delete[xmlID];
            else
                return string.Empty;
        }
        #endregion
    }
}
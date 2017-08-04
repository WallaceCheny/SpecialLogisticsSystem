using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Ms.Data;
using Ms.Data.Common;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.Dal
{
    public class Dao : DaoInfo, IDao
    {
        public IList<dynamic> Select(string name, string provider, string sql, params Parameter[] parameters)
        {
            ConnectionStringSettings conn = ConfigurationManager.ConnectionStrings[name];
            var dbProviderTypes = (DbProviderTypes)Enum.Parse(typeof(DbProviderTypes), provider);
            try
            {
                return new DbContext().ConnectionString(conn.ConnectionString, dbProviderTypes).Sql(sql).Parameters(parameters).Query();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int GetTotal<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            string xmlName = string.IsNullOrEmpty(queryInfo.XmlID) ? "Count" : queryInfo.XmlID;
            Tuple<string, Parameter[]> tuple = GetSelectSql(SelectSql(queryInfo, xmlName), queryInfo);
            var qi = tuple.Item2.ToList();
            if (dbHelper.ProviderTypes == DbProviderTypes.Oracle)
            {
                var p = qi.FirstOrDefault(c => c.ParameterName == "pageSize");
                if (p != null)
                    qi.Remove(p);
                p = qi.FirstOrDefault(c => c.ParameterName == "pageIndex");
                if (p != null)
                    qi.Remove(p);
            }
            return dbHelper.IContext.Sql(tuple.Item1).Parameters(qi.ToArray()).QuerySingle<int>();
        }

        public T Single<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            Tuple<string, Parameter[]> tuple = GetSelectSql(SelectSql(queryInfo, "Load"), queryInfo);
            return dbHelper.IContext.Sql(tuple.Item1).Parameters(tuple.Item2).QuerySingle<T>();
        }
        public dynamic SingleDyn<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            Tuple<string, Parameter[]> tuple = GetSelectSql(SelectSql(queryInfo, "Load"), queryInfo);
            return dbHelper.IContext.Sql(tuple.Item1).Parameters(tuple.Item2).QuerySingle();
        }
        public IList<T> GetList<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            Tuple<string, Parameter[]> tuple = GetSelectSql(SelectSql(queryInfo, "Load"), queryInfo);
            return dbHelper.IContext.Sql(tuple.Item1).Parameters(tuple.Item2).Query<T>();
        }
        public IList<dynamic> Select<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            Tuple<string, Parameter[]> tuple = GetSelectSql(SelectSql(queryInfo, "Select"), queryInfo);
            LogHelper.WriteLog(GeneralSQL(tuple));
            return dbHelper.IContext.Sql(tuple.Item1).Parameters(tuple.Item2).Query();
        }
        public PagedList<T> PagedList<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            Tuple<string, Parameter[]> tuple = GetSelectSql(SelectSql(queryInfo, "PageLoad"), queryInfo);
            int total = GetTotal(queryInfo);
            IList<T> list = null;
            if (total > 0) list = dbHelper.IContext.Sql(tuple.Item1).Parameters(tuple.Item2).Query<T>();
            else list = new List<T>();
            return new PagedList<T>(total, list, Convert.ToInt32(queryInfo.Query["pageIndex"]), Convert.ToInt32(queryInfo.Query["pageSize"]));
        }
        public int Batch(string sql, params Parameter[] parameters)
        {
            int reslut = 0;
            using (var db = dbHelper.IContext.UseTransaction(true))
            {
                reslut = db.Sql(sql).Parameters(parameters).Execute();
                db.Commit();
            }
            return reslut;
        }
        public int Batch<T>(List<T> entitys) where T : Entity, new()
        {
            if (entitys.Count == 0) return 0;
            IDbContext context = dbHelper.IContext;
            int v = 0; Tuple<string, Parameter[]> tuple;
            foreach (var entity in entitys)
            {
                tuple = GetOtherSql(entity);
                switch (entity.GetState())
                {
                    case EntityState.Added:
                        if (entity.GetIsAutoPrimaryKey())
                            v += context.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
                        else
                            v += context.Sql(tuple.Item1).Parameters(tuple.Item2).ExecuteReturnLastId<int>();
                        break;
                    case EntityState.Modified:
                        v += context.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
                        break;
                    case EntityState.Deleted:
                        v += context.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
                        break;
                }
            }
            return v;
        }
        public int Insert<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            Tuple<string, Parameter[]> tuple = GetOtherSql(InsertSql(queryInfo), queryInfo);
            return dbHelper.IContext.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
        }
        public int Insert<T>(T entity) where T : Entity, new()
        {
            entity.SetState(EntityState.Added);
            Tuple<string, Parameter[]> tuple = GetOtherSql(entity);
            try
            {
                IDbContext context = dbHelper.IContext;

                if (entity.GetIsAutoPrimaryKey())
                    return context.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
                else
                    return context.Sql(tuple.Item1).Parameters(tuple.Item2).ExecuteReturnLastId<int>();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(GeneralSQL(tuple), ex);
                throw ex;
            }
            return 0;
        }
        /// <summary>
        /// 生成SQL语句，用于写入错误日志
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        private string GeneralSQL(Tuple<string, Parameter[]> tuple)
        {
            string strSql = tuple.Item1;
            foreach (var item in tuple.Item2)
            {
                if (ConvertHelper.IsInt(item.Value))
                {
                    strSql = strSql.Replace(string.Format("@{0}", item.ParameterName),
                          string.Format("{0}", ConvertHelper.ObjectToDecimal(item.Value)));
                }
                else
                {
                    strSql = strSql.Replace(string.Format("@{0}", item.ParameterName),
                         string.Format("'{0}'", ConvertHelper.ObjectToString(item.Value)));
                }

            }
            return strSql;
        }

        public int Update<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            Tuple<string, Parameter[]> tuple = GetOtherSql(UpdateSql(queryInfo), queryInfo);
            return dbHelper.IContext.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
        }
        public int Update<T>(T entity) where T : Entity, new()
        {
            entity.SetState(EntityState.Modified);
            Tuple<string, Parameter[]> tuple = GetOtherSql(UpdateSql(entity), entity);
            try
            {
                return dbHelper.IContext.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(GeneralSQL(tuple), ex);
                throw ex;
            }
            return 0;
        }
        public int Delete<T>(QueryInfo<T> queryInfo) where T : Entity, new()
        {
            Tuple<string, Parameter[]> tuple = GetOtherSql(DeleteSql(queryInfo), queryInfo);
            return dbHelper.IContext.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
        }
        public int Delete<T>(T entity) where T : Entity, new()
        {
            entity.SetState(EntityState.Deleted);
            Tuple<string, Parameter[]> tuple = GetOtherSql(DeleteSql(entity), entity);
            return dbHelper.IContext.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
        }

        //20130803
        public int Insert<T>(T entity, IDbContext context) where T : Entity, new()
        {
            entity.SetState(EntityState.Added);
            Tuple<string, Parameter[]> tuple = GetOtherSql(entity);
            if (entity.GetIsAutoPrimaryKey())
                return context.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
            else
                return context.Sql(tuple.Item1).Parameters(tuple.Item2).ExecuteReturnLastId<int>();
        }
        public int Update<T>(T entity, IDbContext context) where T : Entity, new()
        {
            entity.SetState(EntityState.Modified);
            Tuple<string, Parameter[]> tuple = GetOtherSql(UpdateSql(entity), entity);
            return context.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
        }
        public int Batch<T>(List<T> entitys, IDbContext context) where T : Entity, new()
        {
            if (entitys.Count == 0) return 0;
            int v = 0; Tuple<string, Parameter[]> tuple;
            foreach (var entity in entitys)
            {
                tuple = GetOtherSql(entity);
                switch (entity.GetState())
                {
                    case EntityState.Added:
                        if (entity.GetIsAutoPrimaryKey())
                            v += context.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
                        else
                            v += context.Sql(tuple.Item1).Parameters(tuple.Item2).ExecuteReturnLastId<int>();
                        break;
                    case EntityState.Modified:
                        v += context.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
                        break;
                    case EntityState.Deleted:
                        v += context.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
                        break;
                }
            }
            return v;
        }
        public int Delete<T>(QueryInfo<T> queryInfo, IDbContext context) where T : Entity, new()
        {
            Tuple<string, Parameter[]> tuple = GetOtherSql(DeleteSql(queryInfo), queryInfo);
            try
            {
                return context.Sql(tuple.Item1).Parameters(tuple.Item2).Execute();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(GeneralSQL(tuple), ex);
                throw ex;
            }
            return 0;
        }
    }
}

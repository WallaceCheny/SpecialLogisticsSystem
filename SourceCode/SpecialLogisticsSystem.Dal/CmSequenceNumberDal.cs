using System;
using System.Collections.Generic;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
//T_Cm_SequenceNumber
namespace SpecialLogisticsSystem.Dal
{
    public class CmSequenceNumberDal : ICmSequenceNumberDal
    {
        private IDao _dao;
        public CmSequenceNumberDal(IDao dao) { _dao = dao; }
        public PagedList<T_Cm_SequenceNumber> GetPageList(QueryInfo<T_Cm_SequenceNumber> queryInfo)
        {
            return _dao.PagedList<T_Cm_SequenceNumber>(queryInfo);
        }
        public IList<T_Cm_SequenceNumber> GetList(QueryInfo<T_Cm_SequenceNumber> queryInfo)
        {
            return _dao.GetList(queryInfo);
        }
        public IList<dynamic> Select(QueryInfo<T_Cm_SequenceNumber> queryInfo)
        {
            return _dao.Select(queryInfo);
        }
        public T_Cm_SequenceNumber GetSingle(object id)
        {
            QueryInfo<T_Cm_SequenceNumber> queryInfo = new QueryInfo<T_Cm_SequenceNumber>();
            queryInfo.PrimaryKeyValue = id;
            return _dao.Single(queryInfo);
        }
        public T_Cm_SequenceNumber GetSingleByCode(string code)
        {
            QueryInfo<T_Cm_SequenceNumber> queryInfo = new QueryInfo<T_Cm_SequenceNumber>();
            queryInfo.SetQuery(T_Cm_SequenceNumber.CodeColumnName, code);
            return _dao.Single(queryInfo);
        }
        public int Insert(T_Cm_SequenceNumber item)
        {
            return _dao.Insert<T_Cm_SequenceNumber>(item);
        }
        public int Update(T_Cm_SequenceNumber item)
        {
            return _dao.Update<T_Cm_SequenceNumber>(item);
        }
        public int Delete(List<object> ids)
        {
            return _dao.Delete<T_Cm_SequenceNumber>(new QueryInfo<T_Cm_SequenceNumber>().SetQuery("ids", ids));
        }
        /// <summary>
        /// 获得编号
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public string GetNumber(CodeTable table)
        {
            string strCode = string.Empty;
            QueryInfo<T_Cm_SequenceNumber> queryInfo = new QueryInfo<T_Cm_SequenceNumber>();
            queryInfo.SetQuery("Code", table.ToString());
            queryInfo.SetXml("GetNumber");
            IList<dynamic> codeList = _dao.Select(queryInfo);
            foreach (dynamic model in codeList)
            {
                strCode = model.code;
            }
            return strCode;
        }
    }
}
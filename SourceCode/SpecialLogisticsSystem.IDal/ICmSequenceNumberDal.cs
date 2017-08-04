using System.Collections.Generic;
using SpecialLogisticsSystem.Model;
//T_Cm_SequenceNumber
namespace SpecialLogisticsSystem.IDal
{
    public interface ICmSequenceNumberDal
    {
        PagedList<T_Cm_SequenceNumber> GetPageList(QueryInfo<T_Cm_SequenceNumber> queryInfo);
        IList<T_Cm_SequenceNumber> GetList(QueryInfo<T_Cm_SequenceNumber> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_SequenceNumber> queryInfo);
        T_Cm_SequenceNumber GetSingle(object id);
        T_Cm_SequenceNumber GetSingleByCode(string code);
        int Insert(T_Cm_SequenceNumber item);
        int Update(T_Cm_SequenceNumber item);
        int Delete(List<object> ids);
        string GetNumber(CodeTable table);
    }
}
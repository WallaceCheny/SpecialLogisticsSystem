
using System.Collections.Generic;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmTemplateDal
    {
        PagedList<T_Cm_Template> GetPageList(QueryInfo<T_Cm_Template> queryInfo);
        IList<T_Cm_Template> GetList(QueryInfo<T_Cm_Template> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_Template> queryInfo);
        T_Cm_Template GetSingle(object id);
        int Insert(T_Cm_Template item);
        int Update(T_Cm_Template item);
        int Delete(List<object> ids);
    }
}
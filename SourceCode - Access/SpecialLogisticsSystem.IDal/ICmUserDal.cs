using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.IDal
{
    public interface ICmUserDal
    {
        PagedList<T_Cm_User> GetPageList(QueryInfo<T_Cm_User> queryInfo);
        IList<T_Cm_User> GetList(QueryInfo<T_Cm_User> queryInfo);
        IList<dynamic> Select(QueryInfo<T_Cm_User> queryInfo);
        T_Cm_User GetSingle(object id);
        int Insert(T_Cm_User item);
        int Update(T_Cm_User item);
        int Delete(List<object> ids);
    }
}

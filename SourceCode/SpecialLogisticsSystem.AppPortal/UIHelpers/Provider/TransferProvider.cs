using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using Newtonsoft.Json;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class TransferProvider : BaseProvider<T_Transfer_Main>
    {
        protected override IList<dynamic> GetSelect(QueryInfo<T_Transfer_Main> queryInfo)
        {
            return UIHelper.Resolve<ITransferMainDal>().Select(queryInfo);
        }

        protected override int GetTotal(QueryInfo<T_Transfer_Main> queryInfo)
        {
            return UIHelper.Resolve<ITransferMainDal>().GetTotal(queryInfo);
        }
    }
}
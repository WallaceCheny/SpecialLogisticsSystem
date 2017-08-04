using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Ms.Data;

namespace SpecialLogisticsSystem.Dal
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer ignored)
        {
            return new TransactionHandler();
        }
    }
    public class TransactionHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            using (var context = DBHelper.Current.IContext.UseTransaction(true))
            {
                IMethodReturn result = getNext()(input, getNext);
                if (result.Exception == null) context.Commit();
                return result;
            }
        }
    }
}

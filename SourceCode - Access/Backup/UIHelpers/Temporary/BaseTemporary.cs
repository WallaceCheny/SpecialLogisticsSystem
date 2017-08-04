using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using SpecialLogisticsSystem.Model;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public abstract class BaseTemporary<T1> : IRequiresSessionState where T1 : Entity, new()
    {
        public abstract string SessionName { get; }
        public abstract T1 GetMode(string id);
        public abstract bool IsExit(string id);
        public abstract Guid GetId(T1 model);

        HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public List<T1> GetList()
        {
            if (Session[SessionName] == null)
            {
                Session[SessionName] = new List<T1>();
            }
            List<T1> items = Session[SessionName] as List<T1>;
            if (items == null)
            {
                items = new List<T1>();
                Session[SessionName] = items;
            }
            return items;
        }

        public void ClearCache()
        {
            Session[SessionName] = new List<T1>();
        }

        public T1 GetItemById(Guid id)
        {
            List<T1> list = GetList();
            foreach (T1 item in list)
            {
                if (GetId(item) == id) return item;
            }
            return null;
        }

        public void Delete(Guid id)
        {
            T1 item = GetItemById(id);
            if (item != null)
            {
                GetList().Remove(item);
            }
        }
        public void Update(Guid id)
        {
            //T1 item = GetItemById(id);
            //if (item != null)
            //{
            //    UpdateItem(item, id, numbers, prd_id, stock_manage_id, bit_amt);
            //}
        }
        public void Insert(string id)
        {
            if (IsExit(id)) return;
            T1 model = GetMode(id);
            GetList().Add(model);
        }
    }
}
namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    internal class xe9a2666102b20a2e
    {
        private readonly DbCommandData _x008f39765ea7968e;
        private readonly List<x4a37bdfb56acb0d7> _xa942970cc8a85fd4;
        [CompilerGenerated]
        private static Func<x4a37bdfb56acb0d7, string> x31af784cbc72c68d;

        public xe9a2666102b20a2e(DbCommandData dbCommandData)
        {
            this._x008f39765ea7968e = dbCommandData;
            this._xa942970cc8a85fd4 = x641e0a54984050b1.x0bf67ddd05b3bcb8(this._x008f39765ea7968e.Reader);
        }

        [return: Dynamic]
        public object x398c2378fe09de36()
        {
            Dictionary<string, DynamicDataField> dictionary = new Dictionary<string, DynamicDataField>(StringComparer.OrdinalIgnoreCase);
            foreach (x4a37bdfb56acb0d7 xabdfbacbd in this._xa942970cc8a85fd4)
            {
                DynamicDataField field = new DynamicDataField {
                    Value = x641e0a54984050b1.x1fd66af94fec6cea(this._x008f39765ea7968e.Reader, xabdfbacbd.xd1bdf42207dd3638, true),
                    Type = xabdfbacbd.x3146d638ec378671
                };
                dictionary.Add(xabdfbacbd.x759aa16c2016a289, field);
                if (0 == 0)
                {
                }
            }
            return new DynamicRecord(dictionary);
        }

        [CompilerGenerated]
        private static string x685177d84f3e224b(x4a37bdfb56acb0d7 x9c79b5ad7b769b12)
        {
            return x9c79b5ad7b769b12.x759aa16c2016a289;
        }

        public List<string> xc567147cf8b4fd5d()
        {
            bool flag = this._xa942970cc8a85fd4.Count <= 0;
            if (8 == 0)
            {
                List<string> list;
                return list;
            }
            if (flag)
            {
                return new List<string>();
            }
            if (x31af784cbc72c68d == null)
            {
                x31af784cbc72c68d = new Func<x4a37bdfb56acb0d7, string>(xe9a2666102b20a2e.x685177d84f3e224b);
            }
            return this._xa942970cc8a85fd4.Select<x4a37bdfb56acb0d7, string>(x31af784cbc72c68d).ToList<string>();
        }
    }
}


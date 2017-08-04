namespace Ms.Data
{
    using System;
    using System.Data;
    using System.Dynamic;
    using System.Runtime.InteropServices;

    internal class x42ec19f833cd5adc : DynamicObject
    {
        private readonly System.Data.IDataReader _x2876c9437120b4af;

        internal x42ec19f833cd5adc(System.Data.IDataReader dataReader)
        {
            this._x2876c9437120b4af = dataReader;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            bool flag;
            bool flag2;
            result = this._x2876c9437120b4af[binder.Name];
            goto Label_0068;
        Label_0016:
            if ((((uint) flag) - ((uint) flag)) < 0)
            {
                goto Label_00A7;
            }
        Label_0031:
            return true;
        Label_0068:
            flag2 = result != DBNull.Value;
            if (((uint) flag2) <= uint.MaxValue)
            {
            }
        Label_00A7:
            while (!flag2)
            {
                result = null;
                if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_0016;
                }
            }
            if ((((uint) flag2) + ((uint) flag)) >= 0)
            {
                goto Label_0031;
            }
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                goto Label_0016;
            }
            goto Label_0068;
        }
    }
}


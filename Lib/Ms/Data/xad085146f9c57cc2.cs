namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Runtime.InteropServices;

    internal class xad085146f9c57cc2 : xf09c721001ccb9d0, IStoredProcedureBuilder, IBaseStoredProcedureBuilder, IDisposable
    {
        internal xad085146f9c57cc2(IDbCommand command, string name) : base(command, name)
        {
        }

        public IStoredProcedureBuilder Parameter(string name, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(name, value, parameterType, size);
            return this;
        }

        public IStoredProcedureBuilder ParameterOut(string name, DataTypes parameterType, int size = 0)
        {
            base.xcd08eddb14ea4239.x37e59daf82eb99a9(name, parameterType, size);
            return this;
        }

        public IStoredProcedureBuilder Parameters(params Ms.Data.Common.Parameter[] parameters)
        {
            Ms.Data.Common.Parameter[] parameterArray;
            int num;
            bool flag = parameters == null;
            goto Label_006B;
        Label_0008:
            return this;
        Label_0016:
            flag = num < parameterArray.Length;
            if (-2 == 0)
            {
                goto Label_006B;
            }
            if (!flag)
            {
                goto Label_0008;
            }
            Ms.Data.Common.Parameter parameter = parameterArray[num];
        Label_0031:
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(parameter.ParameterName, parameter.Value, parameter.DataTypes, 0);
            num++;
            goto Label_0016;
        Label_006B:
            if (flag)
            {
                goto Label_0008;
            }
            parameterArray = parameters;
            num = 0;
            if ((((uint) num) & 0) != 0)
            {
                goto Label_0031;
            }
            goto Label_0016;
        }
    }
}


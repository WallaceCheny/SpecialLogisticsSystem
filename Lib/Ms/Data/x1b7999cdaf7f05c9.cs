namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Dynamic;
    using System.Runtime.InteropServices;

    internal class x1b7999cdaf7f05c9 : xf09c721001ccb9d0, IBaseStoredProcedureBuilder, IStoredProcedureBuilderDynamic, IDisposable
    {
        internal x1b7999cdaf7f05c9(IDbProvider dbProvider, IDbCommand command, string name, ExpandoObject item) : base(command, name)
        {
            base.x6b73aa01aa019d3a.Item = item;
        }

        public IStoredProcedureBuilderDynamic AutoMap(params string[] ignoreProperties)
        {
            base.xcd08eddb14ea4239.x102778f7a6dca84c(ignoreProperties);
            return this;
        }

        public IStoredProcedureBuilderDynamic Parameter(string name, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(name, value, parameterType, size);
            return this;
        }

        public IStoredProcedureBuilderDynamic ParameterOut(string name, DataTypes parameterType, int size = 0)
        {
            base.xcd08eddb14ea4239.x37e59daf82eb99a9(name, parameterType, size);
            return this;
        }

        public IStoredProcedureBuilderDynamic Parameters(params Ms.Data.Common.Parameter[] parameters)
        {
            Ms.Data.Common.Parameter[] parameterArray;
            int num;
            bool flag = parameters == null;
            goto Label_0033;
        Label_0025:
            return this;
        Label_0033:
            if (!flag)
            {
                parameterArray = parameters;
            }
            else
            {
                if ((((uint) flag) | 1) != 0)
                {
                    goto Label_0025;
                }
                goto Label_0033;
            }
        Label_00C1:
            num = 0;
            while (true)
            {
                flag = num < parameterArray.Length;
                if (!flag)
                {
                    if (((uint) flag) > uint.MaxValue)
                    {
                        goto Label_00C1;
                    }
                    if (((((uint) num) & 0) != 0) || ((3 != 0) && ((((uint) num) - ((uint) flag)) >= 0)))
                    {
                        goto Label_0025;
                    }
                    goto Label_0033;
                }
                Ms.Data.Common.Parameter parameter = parameterArray[num];
                base.xcd08eddb14ea4239.x4fe829ca2eecf51e(parameter.ParameterName, parameter.Value, parameter.DataTypes, 0);
                num++;
            }
        }
    }
}


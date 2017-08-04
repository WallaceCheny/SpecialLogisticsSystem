namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;

    internal class xac680fb937640290<T> : xf09c721001ccb9d0, IStoredProcedureBuilder<T>, IBaseStoredProcedureBuilder, IDisposable
    {
        internal xac680fb937640290(IDbCommand command, string name, T item) : base(command, name)
        {
            base.x6b73aa01aa019d3a.Item = item;
        }

        public IStoredProcedureBuilder<T> AutoMap(params Expression<Func<T, object>>[] ignoreProperties)
        {
            base.xcd08eddb14ea4239.x06d5957f527cfaa8<T>(ignoreProperties);
            return this;
        }

        public IStoredProcedureBuilder<T> Parameter(Expression<Func<T, object>> expression, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e<T>(expression, parameterType, size);
            return this;
        }

        public IStoredProcedureBuilder<T> Parameter(string name, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(name, value, parameterType, size);
            return this;
        }

        public IStoredProcedureBuilder<T> ParameterOut(string name, DataTypes parameterType, int size = 0)
        {
            base.xcd08eddb14ea4239.x37e59daf82eb99a9(name, parameterType, size);
            return this;
        }
    }
}


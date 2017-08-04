namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Linq.Expressions;

    internal class x325e977a1713db84<T> : xb3889caf08450830, IDeleteBuilder<T>
    {
        public x325e977a1713db84(IDbCommand command, string tableName, T item) : base(command, tableName)
        {
            base.x6b73aa01aa019d3a.Item = item;
        }

        public IDeleteBuilder<T> Where(Expression<Func<T, object>> expression, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e<T>(expression, parameterType, size);
            return this;
        }

        public IDeleteBuilder<T> Where(string columnName, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(columnName, value, parameterType, size);
            return this;
        }
    }
}


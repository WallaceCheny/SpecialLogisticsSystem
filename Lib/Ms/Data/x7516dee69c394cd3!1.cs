namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Linq.Expressions;

    internal class x7516dee69c394cd3<T> : xf3a9e3bf108b45a7, IInsertBuilder<T>, IInsertUpdateBuilder<T>
    {
        internal x7516dee69c394cd3(IDbCommand command, string name, T item) : base(command, name)
        {
            base.x6b73aa01aa019d3a.Item = item;
        }

        public IInsertBuilder<T> AutoMap(params Expression<Func<T, object>>[] ignoreProperties)
        {
            base.xcd08eddb14ea4239.x06d5957f527cfaa8<T>(ignoreProperties);
            return this;
        }

        public IInsertBuilder<T> Column(Expression<Func<T, object>> expression, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e<T>(expression, parameterType, size);
            return this;
        }

        public IInsertBuilder<T> Column(string columnName, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(columnName, value, parameterType, size);
            return this;
        }

        private IInsertUpdateBuilder<T> xbdd6325de39ee00d(Expression<Func<T, object>> xbf5efe8743edba7b, DataTypes x5fa349731ac3ba80, int x0ceec69a97f73617)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e<T>(xbf5efe8743edba7b, x5fa349731ac3ba80, x0ceec69a97f73617);
            return this;
        }

        private IInsertUpdateBuilder<T> xbdd6325de39ee00d(string x59ee5b80c99ccc1a, object xbcea506a33cf9111, DataTypes x5fa349731ac3ba80, int x0ceec69a97f73617)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(x59ee5b80c99ccc1a, xbcea506a33cf9111, x5fa349731ac3ba80, x0ceec69a97f73617);
            return this;
        }
    }
}


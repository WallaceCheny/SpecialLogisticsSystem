namespace Ms.Data
{
    using Ms.Data.Common;
    using System;

    internal class xdf8bb929b6dc0786 : x820de93bc2090b75, IUpdateBuilder, IInsertUpdateBuilder
    {
        internal xdf8bb929b6dc0786(IDbProvider dbProvider, IDbCommand command, string name) : base(dbProvider, command, name)
        {
        }

        public IUpdateBuilder Column(string columnName, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(columnName, value, parameterType, size);
            return this;
        }

        IInsertUpdateBuilder IInsertUpdateBuilder.Column(string columnName, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(columnName, value, parameterType, size);
            return this;
        }

        public virtual IUpdateBuilder Where(string columnName, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x7f921c9ab27d105d(columnName, value, parameterType, size);
            return this;
        }
    }
}


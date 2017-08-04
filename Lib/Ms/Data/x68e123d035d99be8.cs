namespace Ms.Data
{
    using Ms.Data.Common;
    using System;

    internal class x68e123d035d99be8 : xf3a9e3bf108b45a7, IInsertBuilder, IInsertUpdateBuilder
    {
        internal x68e123d035d99be8(IDbCommand command, string name) : base(command, name)
        {
        }

        public IInsertBuilder Column(string columnName, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(columnName, value, parameterType, size);
            return this;
        }

        IInsertUpdateBuilder IInsertUpdateBuilder.Column(string columnName, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(columnName, value, parameterType, size);
            return this;
        }
    }
}


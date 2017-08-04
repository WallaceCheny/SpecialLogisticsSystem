namespace Ms.Data
{
    using Ms.Data.Common;
    using System;

    internal class x7e9f16120f42ee43 : xb3889caf08450830, IDeleteBuilder
    {
        public x7e9f16120f42ee43(IDbCommand command, string tableName) : base(command, tableName)
        {
        }

        public IDeleteBuilder Where(string columnName, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(columnName, value, parameterType, size);
            return this;
        }
    }
}


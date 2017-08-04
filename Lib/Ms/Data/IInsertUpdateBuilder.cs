namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Runtime.InteropServices;

    public interface IInsertUpdateBuilder
    {
        IInsertUpdateBuilder Column(string columnName, object value, DataTypes parameterType = 13, int size = 0);
    }
}


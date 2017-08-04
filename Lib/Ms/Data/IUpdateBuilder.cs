namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Runtime.InteropServices;

    public interface IUpdateBuilder
    {
        IUpdateBuilder Column(string columnName, object value, DataTypes parameterType = 13, int size = 0);
        int Execute();
        IUpdateBuilder Where(string columnName, object value, DataTypes parameterType = 13, int size = 0);
    }
}


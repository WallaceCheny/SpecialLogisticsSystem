namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Runtime.InteropServices;

    public interface IDeleteBuilder
    {
        int Execute();
        IDeleteBuilder Where(string columnName, object value, DataTypes parameterType = 13, int size = 0);
    }
}


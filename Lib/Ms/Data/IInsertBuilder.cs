﻿namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Runtime.InteropServices;

    public interface IInsertBuilder
    {
        IInsertBuilder Column(string columnName, object value, DataTypes parameterType = 13, int size = 0);
        int Execute();
        T ExecuteReturnLastId<T>(string identityColumnName = null);
    }
}


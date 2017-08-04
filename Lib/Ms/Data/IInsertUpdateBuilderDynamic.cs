namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Runtime.InteropServices;

    public interface IInsertUpdateBuilderDynamic
    {
        IInsertUpdateBuilderDynamic Column(string propertyName, DataTypes parameterType = 13, int size = 0);
        IInsertUpdateBuilderDynamic Column(string columnName, object value, DataTypes parameterType = 13, int size = 0);
    }
}


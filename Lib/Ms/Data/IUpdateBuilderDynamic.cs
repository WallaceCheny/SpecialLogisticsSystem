namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Runtime.InteropServices;

    public interface IUpdateBuilderDynamic
    {
        IUpdateBuilderDynamic AutoMap(params string[] ignoreProperties);
        IUpdateBuilderDynamic Column(string propertyName, DataTypes parameterType = 13, int size = 0);
        IUpdateBuilderDynamic Column(string columnName, object value, DataTypes parameterType = 13, int size = 0);
        int Execute();
        IUpdateBuilderDynamic Where(string name, DataTypes parameterType = 13, int size = 0);
        IUpdateBuilderDynamic Where(string columnName, object value, DataTypes parameterType = 13, int size = 0);
    }
}


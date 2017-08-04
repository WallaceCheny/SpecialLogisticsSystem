namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Runtime.InteropServices;

    public interface IInsertBuilderDynamic
    {
        IInsertBuilderDynamic AutoMap(params string[] ignoreProperties);
        IInsertBuilderDynamic Column(string propertyName, DataTypes parameterType = 13, int size = 0);
        IInsertBuilderDynamic Column(string columnName, object value, DataTypes parameterType = 13, int size = 0);
        int Execute();
        T ExecuteReturnLastId<T>(string identityColumnName = null);
    }
}


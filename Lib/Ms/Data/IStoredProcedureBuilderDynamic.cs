namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Runtime.InteropServices;

    public interface IStoredProcedureBuilderDynamic : IBaseStoredProcedureBuilder, IDisposable
    {
        IStoredProcedureBuilderDynamic AutoMap(params string[] ignoreProperties);
        IStoredProcedureBuilderDynamic Parameter(string name, object value, DataTypes parameterType = 13, int size = 0);
        IStoredProcedureBuilderDynamic ParameterOut(string name, DataTypes parameterType, int size = 0);
        IStoredProcedureBuilderDynamic Parameters(params Ms.Data.Common.Parameter[] parameters);
    }
}


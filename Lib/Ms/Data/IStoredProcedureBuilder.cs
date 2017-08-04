namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Runtime.InteropServices;

    public interface IStoredProcedureBuilder : IBaseStoredProcedureBuilder, IDisposable
    {
        IStoredProcedureBuilder Parameter(string name, object value, DataTypes parameterType = 13, int size = 0);
        IStoredProcedureBuilder ParameterOut(string name, DataTypes parameterType, int size = 0);
        IStoredProcedureBuilder Parameters(params Ms.Data.Common.Parameter[] parameters);
    }
}


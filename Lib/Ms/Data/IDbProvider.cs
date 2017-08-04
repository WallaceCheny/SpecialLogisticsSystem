namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Data;

    public interface IDbProvider
    {
        IDbConnection CreateConnection(string connectionString);
        string EscapeColumnName(string name);
        T ExecuteReturnLastId<T>(Ms.Data.IDbCommand command, string identityColumnName);
        DataTypes GetDbTypeForClrType(Type clrType);
        string GetParameterName(string parameterName);
        string GetSelectBuilderAlias(string name, string alias);
        string GetSqlForDeleteBuilder(BuilderData data);
        string GetSqlForInsertBuilder(BuilderData data);
        string GetSqlForSelectBuilder(BuilderData data);
        string GetSqlForStoredProcedureBuilder(BuilderData data);
        string GetSqlForUpdateBuilder(BuilderData data);
        void OnCommandExecuting(Ms.Data.IDbCommand command);

        string ProviderName { get; }

        bool SupportsExecuteReturnLastIdWithNoIdentityColumn { get; }

        bool SupportsMultipleQueries { get; }

        bool SupportsMultipleResultset { get; }

        bool SupportsOutputParameters { get; }

        bool SupportsStoredProcedures { get; }
    }
}


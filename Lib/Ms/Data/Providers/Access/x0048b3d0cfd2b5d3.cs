namespace Ms.Data.Providers.Access
{
    using Ms.Data;
    using Ms.Data.Common;
    using Ms.Data.Providers.Common;
    using Ms.Data.Providers.Common.Builders;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    internal class x0048b3d0cfd2b5d3 : IDbProvider
    {
        public IDbConnection CreateConnection(string connectionString)
        {
            return xff59563c1b935d7a.xac31a164577610bd(this.ProviderName, connectionString);
        }

        public string EscapeColumnName(string name)
        {
            return ("[" + name + "]");
        }

        public T ExecuteReturnLastId<T>(Ms.Data.IDbCommand command, string identityColumnName = null)
        {
            T lastId;
            if (0 == 0)
            {
                lastId = default(T);
            }
            command.Data.x876bc5bb5331d9cc.xa266202b32508032(false, delegate {
                lastId = this.x520945fbc2e8bb0a<T>(command, null);
            });
            return lastId;
        }

        public DataTypes GetDbTypeForClrType(Type clrType)
        {
            return new x0500305f8473badb().x0da8b7b7e680146f(clrType);
        }

        public string GetParameterName(string parameterName)
        {
            return ("@" + parameterName);
        }

        public string GetSelectBuilderAlias(string name, string alias)
        {
            return (name + " as " + alias);
        }

        public string GetSqlForDeleteBuilder(BuilderData data)
        {
            return new x1516a98cea095f5e().x66e80d2fc6a5c50e(this, "@", data);
        }

        public string GetSqlForInsertBuilder(BuilderData data)
        {
            return new x9e2a6e01e374cc32().x66e80d2fc6a5c50e(this, "@", data);
        }

        public string GetSqlForSelectBuilder(BuilderData data)
        {
            throw new NotImplementedException();
        }

        public string GetSqlForStoredProcedureBuilder(BuilderData data)
        {
            throw new NotImplementedException();
        }

        public string GetSqlForUpdateBuilder(BuilderData data)
        {
            return new x980f8b5514dc9cc2().x66e80d2fc6a5c50e(this, "@", data);
        }

        public void OnCommandExecuting(Ms.Data.IDbCommand command)
        {
        }

        private T x520945fbc2e8bb0a<T>(Ms.Data.IDbCommand xfd6dd6e53b1a26d5, string xaaf21d32e46e8fc5 = null)
        {
            T local;
            bool flag;
            int num = xfd6dd6e53b1a26d5.Data.InnerCommand.ExecuteNonQuery();
            if ((((uint) num) - ((uint) flag)) > uint.MaxValue)
            {
                return local;
            }
            local = default(T);
            if (num <= 0)
            {
                return local;
            }
            xfd6dd6e53b1a26d5.Data.InnerCommand.CommandText = "select @@Identity";
            return (T) xfd6dd6e53b1a26d5.Data.InnerCommand.ExecuteScalar();
        }

        public string ProviderName
        {
            get
            {
                return "System.Data.OleDb";
            }
        }

        public bool SupportsExecuteReturnLastIdWithNoIdentityColumn
        {
            get
            {
                return true;
            }
        }

        public bool SupportsMultipleQueries
        {
            get
            {
                return false;
            }
        }

        public bool SupportsMultipleResultset
        {
            get
            {
                return false;
            }
        }

        public bool SupportsOutputParameters
        {
            get
            {
                return false;
            }
        }

        public bool SupportsStoredProcedures
        {
            get
            {
                return false;
            }
        }
    }
}


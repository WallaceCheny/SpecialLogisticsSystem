namespace Ms.Data.Providers.Sqlite
{
    using Ms.Data;
    using Ms.Data.Common;
    using Ms.Data.Providers.Common;
    using Ms.Data.Providers.Common.Builders;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    internal class x5fc4aec3fec9428d : IDbProvider
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
            System.Data.IDbCommand command1;
            bool flag;
            if ((((uint) flag) | 0x80000000) == 0)
            {
                goto Label_00BF;
            }
            flag = command.Data.InnerCommand.CommandText[command.Data.InnerCommand.CommandText.Length - 1] == ';';
        Label_0010:
            if (!flag)
            {
                System.Data.IDbCommand innerCommand = command.Data.InnerCommand;
                innerCommand.CommandText = innerCommand.CommandText + ';';
                goto Label_00BF;
            }
        Label_0016:
            command1 = command.Data.InnerCommand;
            command1.CommandText = command1.CommandText + "select last_insert_rowid();";
            T lastId = default(T);
            command.Data.x876bc5bb5331d9cc.xa266202b32508032(false, delegate {
                bool flag;
                object obj2 = command.Data.InnerCommand.ExecuteScalar();
                if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_004F;
                }
            Label_002F:
                if (!flag)
                {
                    goto Label_0080;
                }
            Label_0032:
                lastId = (T) Convert.ChangeType(obj2, typeof(T));
                return;
            Label_004F:
                flag = !(obj2.GetType() == typeof(T));
                if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_002F;
                }
            Label_0080:
                lastId = (T) obj2;
                if (-1 == 0)
                {
                    goto Label_004F;
                }
                goto Label_0032;
            });
            if (((uint) flag) >= 0)
            {
            }
            T local = lastId;
            if (0x7fffffff == 0)
            {
            }
            return local;
        Label_00BF:
            if (-1 != 0)
            {
                goto Label_0016;
            }
            goto Label_0010;
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
            // This item is obfuscated and can not be translated.
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

        public string ProviderName
        {
            get
            {
                return "System.Data.SQLite";
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
                return true;
            }
        }

        public bool SupportsMultipleResultset
        {
            get
            {
                return true;
            }
        }

        public bool SupportsOutputParameters
        {
            get
            {
                return true;
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


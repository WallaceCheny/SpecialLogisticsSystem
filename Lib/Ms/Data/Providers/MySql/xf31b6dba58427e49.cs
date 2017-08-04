namespace Ms.Data.Providers.MySql
{
    using Ms.Data;
    using Ms.Data.Common;
    using Ms.Data.Providers.Common;
    using Ms.Data.Providers.Common.Builders;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    internal class xf31b6dba58427e49 : IDbProvider
    {
        public IDbConnection CreateConnection(string connectionString)
        {
            return xff59563c1b935d7a.xac31a164577610bd(this.ProviderName, connectionString);
        }

        public string EscapeColumnName(string name)
        {
            return ("`" + name + "`");
        }

        public T ExecuteReturnLastId<T>(Ms.Data.IDbCommand command, string identityColumnName = null)
        {
            System.Data.IDbCommand command1;
            T local;
            bool flag;
            T lastId;
            if (0 == 0)
            {
                flag = command.Data.InnerCommand.CommandText[command.Data.InnerCommand.CommandText.Length - 1] == ';';
                if ((((uint) flag) <= uint.MaxValue) && flag)
                {
                    if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                    {
                        goto Label_0062;
                    }
                    goto Label_0026;
                }
                System.Data.IDbCommand innerCommand = command.Data.InnerCommand;
                innerCommand.CommandText = innerCommand.CommandText + ';';
                if (0 != 0)
                {
                    return local;
                }
                goto Label_0062;
            }
        Label_000C:
            if (((uint) flag) > uint.MaxValue)
            {
                goto Label_0062;
            }
            return local;
        Label_0026:
            lastId = default(T);
            command.Data.x876bc5bb5331d9cc.xa266202b32508032(false, delegate {
                object obj2 = command.Data.InnerCommand.ExecuteScalar();
                if (obj2.GetType() == typeof(T))
                {
                    lastId = (T) obj2;
                }
                lastId = (T) Convert.ChangeType(obj2, typeof(T));
            });
            local = lastId;
            goto Label_000C;
        Label_0062:
            command1 = command.Data.InnerCommand;
            command1.CommandText = command1.CommandText + "select LAST_INSERT_ID() as `LastInsertedId`";
            goto Label_0026;
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
            bool flag;
            string str = "";
        Label_0141:
            str = ("select " + data.Select) + " from " + data.From;
            if ((((uint) flag) + ((uint) flag)) >= 0)
            {
                flag = data.WhereSql.Length <= 0;
                if (0x7fffffff != 0)
                {
                    if (!flag)
                    {
                        str = str + " where " + data.WhereSql;
                    }
                    flag = data.GroupBy.Length <= 0;
                    if (((((uint) flag) & 0) == 0) && flag)
                    {
                        if (-2147483648 == 0)
                        {
                            goto Label_000C;
                        }
                    }
                    else
                    {
                        str = str + " group by " + data.GroupBy;
                    }
                }
                flag = data.Having.Length <= 0;
                if (!flag)
                {
                    str = str + " having " + data.Having;
                    if (0 != 0)
                    {
                        goto Label_0141;
                    }
                }
                flag = data.OrderBy.Length <= 0;
                if (!flag)
                {
                    str = str + " order by " + data.OrderBy;
                    goto Label_0043;
                }
                if (((uint) flag) >= 0)
                {
                    goto Label_0043;
                }
            }
            goto Label_004D;
        Label_000C:
            if (!flag)
            {
                return (str + string.Format(" limit {0}, {1}", data.xfe758c7684820895() - 1, data.xf4393586de9748ad()));
            }
            return str;
        Label_0043:
            if (data.PagingItemsPerPage <= 0)
            {
            }
        Label_004D:
            flag = true;
            goto Label_000C;
        }

        public string GetSqlForStoredProcedureBuilder(BuilderData data)
        {
            return data.ObjectName;
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
                return "MySql.Data.MySqlClient";
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
                return true;
            }
        }
    }
}


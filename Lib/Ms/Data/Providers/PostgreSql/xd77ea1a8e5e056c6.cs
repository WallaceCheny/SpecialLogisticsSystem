namespace Ms.Data.Providers.PostgreSql
{
    using Ms.Data;
    using Ms.Data.Common;
    using Ms.Data.Providers.Common;
    using Ms.Data.Providers.Common.Builders;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    internal class xd77ea1a8e5e056c6 : IDbProvider
    {
        public IDbConnection CreateConnection(string connectionString)
        {
            return xff59563c1b935d7a.xac31a164577610bd(this.ProviderName, connectionString);
        }

        public string EscapeColumnName(string name)
        {
            return name;
        }

        public T ExecuteReturnLastId<T>(Ms.Data.IDbCommand command, string identityColumnName = null)
        {
            T lastId;
            if (command.Data.InnerCommand.CommandText[command.Data.InnerCommand.CommandText.Length - 1] != ';')
            {
                System.Data.IDbCommand innerCommand = command.Data.InnerCommand;
                innerCommand.CommandText = innerCommand.CommandText + ';';
            }
            while (true)
            {
                bool flag;
                System.Data.IDbCommand command1 = command.Data.InnerCommand;
                command1.CommandText = command1.CommandText + "select lastval();";
                lastId = default(T);
                command.Data.x876bc5bb5331d9cc.xa266202b32508032(false, delegate {
                    object obj2 = command.Data.InnerCommand.ExecuteScalar();
                    bool flag = !(obj2.GetType() == typeof(T));
                    while (true)
                    {
                        while (!flag)
                        {
                            lastId = (T) obj2;
                            break;
                        }
                        lastId = (T) Convert.ChangeType(obj2, typeof(T));
                        if (15 != 0)
                        {
                            return;
                        }
                    }
                });
                T local = lastId;
                if ((((uint) flag) - ((uint) flag)) >= 0)
                {
                    return local;
                }
            }
        }

        public DataTypes GetDbTypeForClrType(Type clrType)
        {
            return new x0500305f8473badb().x0da8b7b7e680146f(clrType);
        }

        public string GetParameterName(string parameterName)
        {
            return (":" + parameterName);
        }

        public string GetSelectBuilderAlias(string name, string alias)
        {
            return (name + " as " + alias);
        }

        public string GetSqlForDeleteBuilder(BuilderData data)
        {
            return new x1516a98cea095f5e().x66e80d2fc6a5c50e(this, ":", data);
        }

        public string GetSqlForInsertBuilder(BuilderData data)
        {
            return new x9e2a6e01e374cc32().x66e80d2fc6a5c50e(this, ":", data);
        }

        public string GetSqlForSelectBuilder(BuilderData data)
        {
            bool flag;
            string str = "";
            goto Label_01BB;
        Label_000F:
            return (str + " offset " + (data.xfe758c7684820895() - 1));
        Label_0101:
            str = str + " having " + data.Having;
        Label_0113:
            flag = data.OrderBy.Length <= 0;
        Label_0071:
            if (!flag)
            {
                str = str + " order by " + data.OrderBy;
                if ((((uint) flag) - ((uint) flag)) < 0)
                {
                    string str2;
                    return str2;
                }
            }
            flag = data.PagingItemsPerPage <= 0;
            if (flag)
            {
                return str;
            }
            if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
            {
                if (-2 != 0)
                {
                    flag = data.PagingItemsPerPage <= 0;
                    if ((((uint) flag) >= 0) && flag)
                    {
                        goto Label_000F;
                    }
                    str = str + " limit " + data.PagingItemsPerPage;
                }
                if (0 == 0)
                {
                    goto Label_000F;
                }
                goto Label_0071;
            }
            goto Label_01BB;
        Label_0136:
            flag = data.GroupBy.Length <= 0;
            if ((((uint) flag) | 8) != 0)
            {
                if (!flag)
                {
                    str = str + " group by " + data.GroupBy;
                }
                if (data.Having.Length <= 0)
                {
                    goto Label_0113;
                }
                goto Label_0101;
            }
        Label_0160:
            flag = data.WhereSql.Length <= 0;
            do
            {
                if ((((uint) flag) + ((uint) flag)) >= 0)
                {
                    if (!flag)
                    {
                        break;
                    }
                    goto Label_0136;
                }
            }
            while ((((uint) flag) | uint.MaxValue) == 0);
            str = str + " where " + data.WhereSql;
            if (1 == 0)
            {
                goto Label_0101;
            }
            goto Label_0136;
        Label_01BB:
            str = ("select " + data.Select) + " from " + data.From;
            goto Label_0160;
        }

        public string GetSqlForStoredProcedureBuilder(BuilderData data)
        {
            return data.ObjectName;
        }

        public string GetSqlForUpdateBuilder(BuilderData data)
        {
            return new x980f8b5514dc9cc2().x66e80d2fc6a5c50e(this, ":", data);
        }

        public void OnCommandExecuting(Ms.Data.IDbCommand command)
        {
        }

        public string ProviderName
        {
            get
            {
                return "Npgsql";
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


namespace Ms.Data.Providers.SqlServer
{
    using Ms.Data;
    using Ms.Data.Common;
    using Ms.Data.Providers.Common;
    using Ms.Data.Providers.Common.Builders;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    internal class xb41ee2fa4b36daf9 : IDbProvider
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
            bool flag = command.Data.InnerCommand.CommandText[command.Data.InnerCommand.CommandText.Length - 1] == ';';
        Label_0049:
            if (!flag)
            {
                System.Data.IDbCommand command2 = command.Data.InnerCommand;
                command2.CommandText = command2.CommandText + ';';
                if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_000B;
                }
                if (((uint) flag) < 0)
                {
                    goto Label_0049;
                }
            }
            System.Data.IDbCommand innerCommand = command.Data.InnerCommand;
            innerCommand.CommandText = innerCommand.CommandText + "select SCOPE_IDENTITY()";
        Label_000B:
            lastId = default(T);
            command.Data.x876bc5bb5331d9cc.xa266202b32508032(false, delegate {
                bool flag;
                object obj2 = command.Data.InnerCommand.ExecuteScalar();
                if (((uint) flag) >= 0)
                {
                    flag = !(obj2.GetType() == typeof(T));
                }
                if (!flag)
                {
                    lastId = (T) obj2;
                }
                lastId = (T) Convert.ChangeType(obj2, typeof(T));
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
            bool flag;
            string str = "";
            if (2 != 0)
            {
                goto Label_0333;
            }
            goto Label_0105;
        Label_00B7:
            flag = data.Having.Length <= 0;
            if (!flag)
            {
                str = str + " having " + data.Having;
                if (1 == 0)
                {
                    goto Label_023B;
                }
            }
            str = string.Format("with PagedPersons as\r\n\t\t\t\t\t\t\t\t\t\t(\r\n\t\t\t\t\t\t\t\t\t\t\tselect top 100 percent {0}, row_number() over (order by {1}) as Ms_Data_ROWNUMBER\r\n\t\t\t\t\t\t\t\t\t\t\t{2}\r\n\t\t\t\t\t\t\t\t\t\t)\r\n\t\t\t\t\t\t\t\t\t\tselect *\r\n\t\t\t\t\t\t\t\t\t\tfrom PagedPersons\r\n\t\t\t\t\t\t\t\t\t\twhere Ms_Data_RowNumber between {3} and {4}", new object[] { data.Select, data.OrderBy, str, data.xfe758c7684820895(), data.xf4393586de9748ad() });
            if (((uint) flag) > uint.MaxValue)
            {
                goto Label_016B;
            }
            return str;
        Label_00E2:
            if (!flag)
            {
                str = str + " group by " + data.GroupBy;
                if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_00E2;
                }
            }
            goto Label_00B7;
        Label_0105:
            flag = data.GroupBy.Length <= 0;
            goto Label_00E2;
        Label_0165:
            if (!flag)
            {
                str = ("select " + data.Select) + " from " + data.From;
                flag = data.WhereSql.Length <= 0;
                if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_00B7;
                }
                if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_017F;
                }
                goto Label_023B;
            }
        Label_016B:
            flag = data.PagingItemsPerPage <= 0;
            if (!flag)
            {
                str = str + " from " + data.From;
                if (data.WhereSql.Length > 0)
                {
                    str = str + " where " + data.WhereSql;
                }
                goto Label_0105;
            }
            if (-2 != 0)
            {
                return str;
            }
            if (-1 != 0)
            {
                string str2;
                return str2;
            }
            goto Label_00E2;
        Label_017F:
            if (0 != 0)
            {
                goto Label_0165;
            }
        Label_0187:
            flag = data.OrderBy.Length <= 0;
            if (flag)
            {
                return str;
            }
            str = str + " order by " + data.OrderBy;
            if (0 == 0)
            {
                if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
                {
                    return str;
                }
                goto Label_0333;
            }
        Label_01CE:
            str = str + " group by " + data.GroupBy;
            if ((((uint) flag) + ((uint) flag)) < 0)
            {
                goto Label_00B7;
            }
        Label_0200:
            flag = data.Having.Length <= 0;
            if ((3 != 0) && flag)
            {
                goto Label_0187;
            }
            str = str + " having " + data.Having;
            goto Label_017F;
        Label_023B:
            if (((((uint) flag) - ((uint) flag)) < 0) || !flag)
            {
                str = str + " where " + data.WhereSql;
            }
            flag = data.GroupBy.Length <= 0;
            if (2 != 0)
            {
                if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                {
                    if (!flag)
                    {
                        goto Label_01CE;
                    }
                    goto Label_0200;
                }
                if ((((uint) flag) | 0x80000000) != 0)
                {
                    goto Label_01CE;
                }
            }
            else
            {
                goto Label_0165;
            }
        Label_0333:
            flag = data.PagingItemsPerPage != 0;
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                goto Label_0165;
            }
            goto Label_01CE;
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
                return "System.Data.SqlClient";
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


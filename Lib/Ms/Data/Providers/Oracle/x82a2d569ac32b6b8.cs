namespace Ms.Data.Providers.Oracle
{
    using Ms.Data;
    using Ms.Data.Common;
    using Ms.Data.Providers.Common;
    using Ms.Data.Providers.Common.Builders;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    internal class x82a2d569ac32b6b8 : IDbProvider
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
            if (0 == 0)
            {
                if (0x7fffffff == 0)
                {
                    return lastId;
                }
                command.ParameterOut("Ms_Data_LastId", command.Data.Context.Data.Provider.GetDbTypeForClrType(typeof(T)), 0);
            }
            command.Sql(" returning " + identityColumnName + " into :Ms_Data_LastId");
            lastId = default(T);
            command.Data.x876bc5bb5331d9cc.xa266202b32508032(false, delegate {
                command.Data.InnerCommand.ExecuteNonQuery();
                lastId = command.ParameterValue<T>("Ms_Data_LastId");
            });
            return lastId;
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
            return (name + " " + alias);
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
            goto Label_0295;
        Label_000C:
            if (!flag)
            {
                str = str + " from " + data.From;
                if (0x7fffffff == 0)
                {
                    goto Label_0033;
                }
                if (8 != 0)
                {
                    goto Label_0109;
                }
                goto Label_01AE;
            }
            return str;
        Label_0033:
            if (!flag)
            {
                str = str + " having " + data.Having;
                if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
                {
                }
            }
            str = string.Format("select * from\r\n\t\t\t\t\t\t\t\t\t\t(\r\n\t\t\t\t\t\t\t\t\t\t\tselect {0}, \r\n\t\t\t\t\t\t\t\t\t\t\t\trow_number() over (order by {1}) Ms_Data_ROWNUMBER\r\n\t\t\t\t\t\t\t\t\t\t\t{2}\r\n\t\t\t\t\t\t\t\t\t\t)\r\n\t\t\t\t\t\t\t\t\t\twhere Ms_Data_RowNumber between {3} and {4}\r\n\t\t\t\t\t\t\t\t\t\torder by Ms_Data_RowNumber", new object[] { data.Select, data.OrderBy, str, data.xfe758c7684820895(), data.xf4393586de9748ad() });
            if ((((uint) flag) | 0xff) != 0)
            {
                return str;
            }
            goto Label_000C;
        Label_00DB:
            flag = data.Having.Length <= 0;
            if (0 == 0)
            {
                if (0 != 0)
                {
                    string str2;
                    return str2;
                }
                goto Label_0033;
            }
        Label_0109:
            flag = data.WhereSql.Length <= 0;
            if ((((uint) flag) + ((uint) flag)) >= 0)
            {
                if (!flag)
                {
                    str = str + " where " + data.WhereSql;
                }
                flag = data.GroupBy.Length <= 0;
                if (!flag)
                {
                    str = str + " group by " + data.GroupBy;
                }
            }
            goto Label_00DB;
        Label_01AE:
            if (data.Having.Length > 0)
            {
                str = str + " having " + data.Having;
            }
            if (data.OrderBy.Length <= 0)
            {
                return str;
            }
            return (str + " order by " + data.OrderBy);
        Label_01F1:
            if (flag)
            {
                goto Label_01AE;
            }
            str = str + " group by " + data.GroupBy;
            if ((((uint) flag) + ((uint) flag)) < 0)
            {
                goto Label_00DB;
            }
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                if (((uint) flag) <= uint.MaxValue)
                {
                    goto Label_01AE;
                }
                goto Label_0109;
            }
            goto Label_0295;
        Label_0250:
            if (!flag)
            {
                str = str + " where " + data.WhereSql;
                if (0 == 0)
                {
                    if ((((uint) flag) <= uint.MaxValue) && (((uint) flag) <= uint.MaxValue))
                    {
                        goto Label_0267;
                    }
                    goto Label_0250;
                }
                goto Label_01F1;
            }
        Label_0267:
            flag = data.GroupBy.Length <= 0;
            if (0 == 0)
            {
                goto Label_01F1;
            }
            goto Label_0250;
        Label_0295:
            flag = data.PagingItemsPerPage != 0;
            if (!flag)
            {
                str = ("select " + data.Select) + " from " + data.From;
                flag = data.WhereSql.Length <= 0;
                if (((uint) flag) >= 0)
                {
                    goto Label_0250;
                }
                goto Label_01F1;
            }
            flag = data.PagingItemsPerPage <= 0;
            goto Label_000C;
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
            bool flag = command.Data.InnerCommand.CommandType != CommandType.Text;
            while (!flag)
            {
                dynamic innerCommand = command.Data.InnerCommand;
                innerCommand.BindByName = true;
                if (-1 != 0)
                {
                    break;
                }
            }
        }

        public string ProviderName
        {
            get
            {
                return "System.Data.OracleClient";
            }
        }

        public bool SupportsExecuteReturnLastIdWithNoIdentityColumn
        {
            get
            {
                return false;
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
                return false;
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


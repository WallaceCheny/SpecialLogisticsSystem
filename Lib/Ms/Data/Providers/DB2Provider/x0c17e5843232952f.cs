namespace Ms.Data.Providers.DB2Provider
{
    using Ms.Data;
    using Ms.Data.Common;
    using Ms.Data.Providers.Common;
    using Ms.Data.Providers.Common.Builders;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    internal class x0c17e5843232952f : IDbProvider
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
            if (command.Data.InnerCommand.CommandText[command.Data.InnerCommand.CommandText.Length - 1] != ';')
            {
                System.Data.IDbCommand command1 = command.Data.InnerCommand;
                command1.CommandText = command1.CommandText + ';';
            }
            System.Data.IDbCommand innerCommand = command.Data.InnerCommand;
            innerCommand.CommandText = innerCommand.CommandText + "select IDENTITY_VAL_LOCAL() as LastId from sysibm.sysdummy1;";
            T lastId = default(T);
            command.Data.x876bc5bb5331d9cc.xa266202b32508032(false, delegate {
                object obj2 = command.Data.InnerCommand.ExecuteScalar();
                while (true)
                {
                    bool flag = !(obj2.GetType() == typeof(T));
                    do
                    {
                        while (!flag)
                        {
                            lastId = (T) obj2;
                            if ((((uint) flag) - ((uint) flag)) >= 0)
                            {
                                break;
                            }
                        }
                    }
                    while ((((uint) flag) + ((uint) flag)) > uint.MaxValue);
                    lastId = (T) Convert.ChangeType(obj2, typeof(T));
                    if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
                    {
                        return;
                    }
                }
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
            // This item is obfuscated and can not be translated.
            string str = "";
            str = "select " + data.Select;
            str = str + " from " + data.From;
            bool flag = data.WhereSql.Length <= 0;
            if (0 != 0)
            {
                goto Label_00FB;
            }
            goto Label_0153;
        Label_0011:
            str = str + string.Format(" limit {0}, {1}", data.xfe758c7684820895() - 1, data.xf4393586de9748ad());
            if (0 != 0)
            {
                goto Label_00A4;
            }
            if (((uint) flag) >= 0)
            {
                return str;
            }
        Label_0054:
            if (!flag)
            {
                goto Label_0011;
            }
            return str;
        Label_005B:
            if (-2 != 0)
            {
                goto Label_0054;
            }
            goto Label_0011;
        Label_0067:
            if (data.PagingItemsPerPage <= 0)
            {
            }
            flag = true;
            if (((uint) flag) <= uint.MaxValue)
            {
                goto Label_005B;
            }
            goto Label_0011;
        Label_00A4:
            if (-2 == 0)
            {
                goto Label_00F3;
            }
            goto Label_0067;
        Label_00B0:
            flag = data.OrderBy.Length <= 0;
            if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
            {
                goto Label_005B;
            }
        Label_00F3:
            while (!flag)
            {
                str = str + " order by " + data.OrderBy;
                goto Label_00A4;
            }
            if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
            {
                goto Label_0067;
            }
            goto Label_00A4;
        Label_00FB:
            str = str + " group by " + data.GroupBy;
        Label_010D:
            flag = data.Having.Length <= 0;
            while (!flag)
            {
                str = str + " having " + data.Having;
                goto Label_00B0;
            }
            if ((((uint) flag) | 2) != 0)
            {
                goto Label_00B0;
            }
        Label_0153:
            if (!flag)
            {
                str = str + " where " + data.WhereSql;
                if (0x7fffffff == 0)
                {
                    goto Label_0067;
                }
            }
            flag = data.GroupBy.Length <= 0;
            if (flag)
            {
                goto Label_010D;
            }
            if (((uint) flag) >= 0)
            {
                goto Label_00FB;
            }
            goto Label_00B0;
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
                return "IBM.data.DB2";
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


namespace Ms.Data.Providers.SqlServerCompact
{
    using Ms.Data;
    using Ms.Data.Common;
    using Ms.Data.Providers.Common;
    using Ms.Data.Providers.Common.Builders;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    internal class x5a504537ae2f4c91 : IDbProvider
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
            T lastId = default(T);
            command.Data.x876bc5bb5331d9cc.xa266202b32508032(false, delegate {
                lastId = this.x520945fbc2e8bb0a<T>(command, null);
            });
            T local = lastId;
            if (0 != 0)
            {
            }
            return local;
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
            string str2;
            bool flag;
            object obj2;
            object[] objArray;
            string str = "";
            if (0 == 0)
            {
                str = ("select " + data.Select) + " from " + data.From;
                flag = data.WhereSql.Length <= 0;
                goto Label_028E;
            }
            goto Label_029D;
        Label_0032:
            if (!flag)
            {
                goto Label_0085;
            }
            return str;
        Label_003D:
            objArray = new object[4];
            if ((((uint) flag) + ((uint) flag)) >= 0)
            {
                objArray[0] = obj2;
                objArray[1] = " fetch next ";
                objArray[2] = data.PagingItemsPerPage;
                objArray[3] = " rows only";
                str = string.Concat(objArray);
                if ((((uint) flag) | 8) != 0)
                {
                    return str;
                }
                goto Label_0032;
            }
        Label_0085:
            obj2 = str;
            if (3 != 0)
            {
                goto Label_003D;
            }
        Label_00D9:
            if (0 != 0)
            {
                goto Label_028E;
            }
            if ((((uint) flag) - ((uint) flag)) < 0)
            {
                goto Label_024C;
            }
            objArray = new object[4];
            objArray[0] = obj2;
            objArray[1] = " offset ";
            if ((((uint) flag) | 0x80000000) != 0)
            {
                objArray[2] = data.xfe758c7684820895() - 1;
                objArray[3] = " rows";
                if (((uint) flag) > uint.MaxValue)
                {
                    goto Label_00D9;
                }
            }
            if (0 == 0)
            {
                str = string.Concat(objArray);
                flag = data.PagingItemsPerPage <= 0;
                goto Label_0032;
            }
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                goto Label_0085;
            }
            goto Label_003D;
        Label_015F:
            if (!flag)
            {
                goto Label_01AD;
            }
        Label_0162:
            flag = data.PagingItemsPerPage <= 0;
            if (0 != 0)
            {
                if (15 == 0)
                {
                    goto Label_0199;
                }
                goto Label_015F;
            }
            if (flag)
            {
                return str;
            }
            obj2 = str;
            if ((((uint) flag) & 0) == 0)
            {
                goto Label_00D9;
            }
            if ((((uint) flag) | 2) == 0)
            {
            }
            goto Label_023A;
        Label_0199:
            flag = data.OrderBy.Length <= 0;
            goto Label_015F;
        Label_01AD:
            str = str + " order by " + data.OrderBy;
            if ((((uint) flag) & 0) == 0)
            {
                goto Label_0162;
            }
        Label_01D3:
            if ((((uint) flag) + ((uint) flag)) < 0)
            {
                goto Label_024C;
            }
            if ((((uint) flag) | 15) != 0)
            {
                if (((uint) flag) < 0)
                {
                    goto Label_01AD;
                }
                goto Label_0199;
            }
            goto Label_0162;
        Label_023A:
            flag = data.GroupBy.Length <= 0;
        Label_024C:
            if (!flag)
            {
                str = str + " group by " + data.GroupBy;
            }
            flag = data.Having.Length <= 0;
            if (!flag)
            {
                str = str + " having " + data.Having;
                goto Label_01D3;
            }
            goto Label_0199;
        Label_028E:
            if (flag)
            {
                goto Label_023A;
            }
        Label_029D:
            str = str + " where " + data.WhereSql;
            if (0 == 0)
            {
                goto Label_023A;
            }
            return str2;
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
            object obj2;
            T local2;
            bool flag;
            int num = xfd6dd6e53b1a26d5.Data.InnerCommand.ExecuteNonQuery();
            if ((((uint) flag) - ((uint) num)) >= 0)
            {
                goto Label_00B7;
            }
            goto Label_0082;
        Label_006C:
            local2 = local;
            if (((uint) flag) <= uint.MaxValue)
            {
                if ((((uint) num) & 0) == 0)
                {
                    if ((((uint) num) & 0) == 0)
                    {
                        return local2;
                    }
                    goto Label_00B7;
                }
                goto Label_00A3;
            }
            return local2;
        Label_0082:
            if (num > 0)
            {
                xfd6dd6e53b1a26d5.Data.InnerCommand.CommandText = "select cast(@@identity as int)";
            }
            else
            {
                goto Label_006C;
            }
        Label_00A3:
            obj2 = xfd6dd6e53b1a26d5.Data.InnerCommand.ExecuteScalar();
            local = (T) obj2;
            goto Label_006C;
        Label_00B7:
            local = default(T);
            goto Label_0082;
        }

        public string ProviderName
        {
            get
            {
                return "System.Data.SqlServerCe.4.0";
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


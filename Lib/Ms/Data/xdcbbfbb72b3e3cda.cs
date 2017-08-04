namespace Ms.Data
{
    using Ms.Data.Common;
    using mscorlib;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Dynamic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class xdcbbfbb72b3e3cda : Ms.Data.IDbCommand, IDisposable
    {
        [CompilerGenerated]
        private DbCommandData x51db2148b67c32e9;

        public xdcbbfbb72b3e3cda(DbContext dbContext, System.Data.IDbCommand innerCommand)
        {
            this.Data = new DbCommandData(dbContext, innerCommand);
            this.Data.x876bc5bb5331d9cc = new x876bc5bb5331d9cc(this);
        }

        public Ms.Data.IDbCommand CommandType(DbCommandTypes dbCommandType)
        {
            this.Data.InnerCommand.CommandType = (System.Data.CommandType) dbCommandType;
            return this;
        }

        public void Dispose()
        {
            bool flag = this.Data.Reader == null;
            if (!flag)
            {
                this.Data.Reader.Close();
            }
            else if (((uint) flag) > uint.MaxValue)
            {
                return;
            }
            this.x18aa82658e198527();
        }

        public int Execute()
        {
            if (0 == 0)
            {
            }
            int recordsAffected = 0;
            this.Data.x876bc5bb5331d9cc.xa266202b32508032(false, delegate {
                recordsAffected = new x7672eed2bf2227ed().x18dfca7c5fd2402f<int>(this.Data);
            });
            return recordsAffected;
        }

        public T ExecuteReturnLastId<T>(string identityColumnName = null)
        {
            bool flag;
            if (this.Data.Context.Data.Provider.SupportsExecuteReturnLastIdWithNoIdentityColumn)
            {
            }
        Label_0047:
            flag = (-2 != 0) || !string.IsNullOrEmpty(identityColumnName);
            if (2 != 0)
            {
                if (!flag)
                {
                    goto Label_0074;
                }
                T local = this.Data.Context.Data.Provider.ExecuteReturnLastId<T>(this, identityColumnName);
                goto Label_0047;
            }
            if ((((uint) flag) | 15) == 0)
            {
                T local2;
                return local2;
            }
        Label_0074:
            throw new Ms.Data.DataException("The selected database does not support this method.");
        }

        public Ms.Data.IDbCommand Parameter(string name, object value, DataTypes parameterType = 13, Ms.Data.ParameterDirection direction = 1, int size = 0)
        {
            bool flag = !x7927126fe5cc7aa8.x2e7a2ea5da15ce85(value);
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                do
                {
                    while (flag)
                    {
                        this.xdaeaf5c1cbb95119(name, value, parameterType, direction, size);
                        if (((uint) size) <= uint.MaxValue)
                        {
                            break;
                        }
                    }
                    this.x1ee2e4fb4b076915(name, value);
                }
                while ((((uint) size) - ((uint) flag)) > uint.MaxValue);
            }
            return this;
        }

        public Ms.Data.IDbCommand ParameterOut(string name, DataTypes parameterType, int size)
        {
            bool supportsOutputParameters = this.Data.Context.Data.Provider.SupportsOutputParameters;
            do
            {
                if (!supportsOutputParameters)
                {
                    throw new Ms.Data.DataException("The selected database does not support output parameters");
                }
                break;
            }
            while ((((uint) size) + ((uint) supportsOutputParameters)) < 0);
            this.Parameter(name, null, parameterType, Ms.Data.ParameterDirection.Output, size);
            return this;
        }

        public Ms.Data.IDbCommand Parameters(params Ms.Data.Common.Parameter[] parameters)
        {
            Ms.Data.Common.Parameter[] parameterArray;
            int num;
            bool flag = parameters == null;
            if (8 == 0)
            {
                goto Label_00B6;
            }
        Label_0022:
            if (!flag)
            {
                goto Label_00B6;
            }
        Label_0028:
            return this;
        Label_004A:
            num++;
        Label_0051:
            flag = num < parameterArray.Length;
            if (flag)
            {
                Ms.Data.Common.Parameter parameter = parameterArray[num];
                flag = !x7927126fe5cc7aa8.x2e7a2ea5da15ce85(parameter.Value);
                if (flag)
                {
                    this.xdaeaf5c1cbb95119(parameter.ParameterName, parameter.Value, parameter.DataTypes, Ms.Data.ParameterDirection.Input, 0);
                }
                else
                {
                    this.x1ee2e4fb4b076915(parameter.ParameterName, parameter.Value);
                }
                goto Label_004A;
            }
            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                if ((((uint) flag) & 0) != 0)
                {
                    Ms.Data.IDbCommand command;
                    return command;
                }
                if (0 != 0)
                {
                    if ((((uint) num) & 0) != 0)
                    {
                        goto Label_004A;
                    }
                    goto Label_0022;
                }
                goto Label_0028;
            }
        Label_008E:
            num = 0;
            goto Label_0051;
        Label_00B6:
            parameterArray = parameters;
            goto Label_008E;
        }

        public TParameterType ParameterValue<TParameterType>(string outputParameterName)
        {
            outputParameterName = this.Data.Context.Data.Provider.GetParameterName(outputParameterName);
            while (true)
            {
                object obj2;
                bool flag = this.Data.InnerCommand.Parameters.Contains(outputParameterName);
                if (flag)
                {
                    obj2 = (this.Data.InnerCommand.Parameters[outputParameterName] as IDataParameter).Value;
                    flag = obj2 != null;
                    if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                    {
                    }
                }
                else if (1 != 0)
                {
                    throw new Ms.Data.DataException(string.Format("Parameter {0} not found", outputParameterName));
                }
                if (flag)
                {
                    if ((((uint) flag) | 1) != 0)
                    {
                        TParameterType local;
                        if (((uint) flag) >= 0)
                        {
                            flag = !(obj2.GetType() == typeof(TParameterType));
                            if (!flag)
                            {
                                return (TParameterType) obj2;
                            }
                            return (TParameterType) Convert.ChangeType(obj2, typeof(TParameterType));
                        }
                        return local;
                    }
                }
                else
                {
                    return default(TParameterType);
                }
            }
        }

        [return: Dynamic(new bool[] { false, true })]
        public List<object> Query()
        {
            List<object> items;
            do
            {
                items = null;
            }
            while (8 == 0);
            this.Data.x876bc5bb5331d9cc.xa266202b32508032(true, delegate {
                items = new x1d5abada91d291d6().x8d7d879bea89ae19(this.Data);
            });
            return items;
        }

        public List<TEntity> Query<TEntity>(Action<TEntity, Ms.Data.IDataReader> customMapper)
        {
            return this.Query<TEntity, List<TEntity>>(customMapper);
        }

        public TList Query<TEntity, TList>(Action<TEntity, Ms.Data.IDataReader> customMapper = null) where TList: IList<TEntity>
        {
            TList items;
            while (true)
            {
                items = default(TList);
                this.Data.x876bc5bb5331d9cc.xa266202b32508032(true, delegate {
                    items = new x1fae094ccbce7a92<TEntity>().x775c5827e65df2da<TList>(this.Data, customMapper);
                });
                if (2 != 0)
                {
                    return items;
                }
            }
        }

        [return: Dynamic]
        public object QueryAndFeild()
        {
            if (0 == 0)
            {
            }
            object data = new ExpandoObject();
            this.Data.x876bc5bb5331d9cc.xa266202b32508032(true, delegate {
                data = new x1d5abada91d291d6().xc8029fa677c82cd1(this.Data);
            });
            return data;
        }

        public void QueryComplex<TEntity>(IList<TEntity> list, Action<IList<TEntity>, Ms.Data.IDataReader> customMapper)
        {
            this.Data.x876bc5bb5331d9cc.xa266202b32508032(true, delegate {
                while (this.Data.Reader.Read())
                {
                    customMapper(list, this.Data.Reader);
                }
            });
        }

        public TEntity QueryComplexSingle<TEntity>(Func<Ms.Data.IDataReader, TEntity> customMapper)
        {
            TEntity local;
            TEntity item;
            if ((2 == 0) || (-1 != 0))
            {
                item = default(TEntity);
                if (0 == 0)
                {
                    this.Data.x876bc5bb5331d9cc.xa266202b32508032(true, delegate {
                        item = new xf3c4d42106b1fb48<TEntity>().x900701397bf06c11(this.Data, customMapper);
                    });
                    local = item;
                }
            }
            return local;
        }

        public DataTable QueryDataTable()
        {
            do
            {
            }
            while (4 == 0);
            DataTable dataTable = new DataTable();
            this.Data.x876bc5bb5331d9cc.xa266202b32508032(true, delegate {
                dataTable.Load(this.Data.Reader.InnerReader, LoadOption.OverwriteChanges);
            });
            return dataTable;
        }

        [return: Dynamic]
        public object QuerySingle()
        {
            object item;
            do
            {
                item = null;
            }
            while (2 == 0);
            this.Data.x876bc5bb5331d9cc.xa266202b32508032(true, delegate {
                item = new x1d5abada91d291d6().xadaedfe74982380c(this.Data);
            });
            return item;
        }

        public TEntity QuerySingle<TEntity>(Action<TEntity, Ms.Data.IDataReader> customMapper)
        {
            if (-2 != 0)
            {
            }
            TEntity item = default(TEntity);
            this.Data.x876bc5bb5331d9cc.xa266202b32508032(true, delegate {
                item = new x1fae094ccbce7a92<TEntity>().xadaedfe74982380c(this.Data, customMapper);
            });
            return item;
        }

        public Ms.Data.IDbCommand Sql(string sql)
        {
            System.Data.IDbCommand innerCommand = this.Data.InnerCommand;
            innerCommand.CommandText = innerCommand.CommandText + sql;
            return this;
        }

        public TList x02b56011810c316c<TEntity, TList>() where TList: IList<TEntity>
        {
            return this.Query<TEntity, TList>(null);
        }

        internal void x18aa82658e198527()
        {
            System.Boolean ReflectorVariable0;
            if (this.Data.Context.Data.UseTransaction)
            {
                ReflectorVariable0 = false;
            }
            else
            {
                ReflectorVariable0 = true;
            }
            bool flag = ReflectorVariable0 ? this.Data.Context.Data.UseSharedConnection : true;
            if ((0 != 0) || !flag)
            {
                this.Data.InnerCommand.Connection.Close();
                flag = this.Data.Context.Data.OnConnectionClosed == null;
                if ((((uint) flag) - ((uint) flag)) < 0)
                {
                }
                if (!flag)
                {
                    goto Label_0066;
                }
            }
            else
            {
                return;
            }
        Label_0023:
            if (((((uint) flag) + ((uint) flag)) < 0) || ((((uint) flag) | 0x7fffffff) != 0))
            {
                return;
            }
        Label_0066:
            this.Data.Context.Data.OnConnectionClosed(new OnConnectionClosedEventArgs(this.Data.InnerCommand.Connection));
            goto Label_0023;
        }

        private void x1ee2e4fb4b076915(string xc15bd84e01929885, object xbcea506a33cf9111)
        {
            <>c__DisplayClassa classa;
            bool flag;
            IEnumerable enumerable = (IEnumerable) xbcea506a33cf9111;
            StringBuilder newInStatement = new StringBuilder();
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
            }
            int num = -1;
            using (IEnumerator enumerator = enumerable.GetEnumerator())
            {
                object obj2;
                IDbDataParameter parameter;
                goto Label_00F0;
            Label_00A7:
                newInStatement.Append(",");
            Label_00B9:
                parameter = this.xdaeaf5c1cbb95119("p" + xc15bd84e01929885 + "p" + num.ToString(), obj2, DataTypes.Object, Ms.Data.ParameterDirection.Input, 0);
                newInStatement.Append(parameter.ParameterName);
            Label_00F0:
                flag = enumerator.MoveNext();
                if (flag)
                {
                    goto Label_016B;
                }
                if (((uint) num) >= 0)
                {
                    goto Label_0199;
                }
                if (0 == 0)
                {
                    goto Label_012D;
                }
            Label_0115:
                if (!flag)
                {
                    goto Label_0139;
                }
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_00A7;
                }
            Label_012D:
                flag = num != 0;
                if (0 == 0)
                {
                    goto Label_0115;
                }
            Label_0139:
                newInStatement.Append(" in(");
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_012D;
                }
                goto Label_00B9;
            Label_016B:
                obj2 = enumerator.Current;
                num++;
                goto Label_012D;
            }
        Label_0199:
            newInStatement.Append(")");
            string pattern = string.Format(@" in\({0}\)|in\s+\({0}\)", this.Data.Context.Data.Provider.GetParameterName(xc15bd84e01929885));
            string commandText = this.Data.InnerCommand.CommandText;
            this.Data.InnerCommand.CommandText = Regex.Replace(commandText, pattern, new MatchEvaluator(classa.<AddListParameterToInnerCommand>b__9), RegexOptions.IgnoreCase);
        }

        public TEntity x5efa827b36dbb858<TEntity>()
        {
            return this.QuerySingle<TEntity>(null);
        }

        private IDbDataParameter xdaeaf5c1cbb95119(string xc15bd84e01929885, object xbcea506a33cf9111, DataTypes x5fa349731ac3ba80 = 13, Ms.Data.ParameterDirection x23e85093ba3a7d1d = 1, int x0ceec69a97f73617 = 0)
        {
            IDbDataParameter parameter;
            string str;
            bool flag = xbcea506a33cf9111 != null;
            goto Label_0305;
        Label_002A:
            parameter.Size = x0ceec69a97f73617;
            goto Label_0038;
        Label_0035:
            if (!flag)
            {
                goto Label_002A;
            }
        Label_0038:
            this.Data.InnerCommand.Parameters.Add(parameter);
            if (0xff == 0)
            {
                goto Label_0229;
            }
            if (8 == 0)
            {
                goto Label_01E7;
            }
            IDbDataParameter parameter2 = parameter;
            if (0 == 0)
            {
                return parameter2;
            }
            goto Label_00D0;
        Label_0072:
            if ((((uint) flag) & 0) != 0)
            {
                goto Label_002A;
            }
            if (0x7fffffff != 0)
            {
                parameter.Value = xbcea506a33cf9111;
                flag = x0ceec69a97f73617 <= 0;
                goto Label_0035;
            }
        Label_00A4:
            parameter.ParameterName = this.Data.Context.Data.Provider.GetParameterName(xc15bd84e01929885);
            parameter.Direction = (System.Data.ParameterDirection) x23e85093ba3a7d1d;
            if ((((uint) flag) & 0) != 0)
            {
                goto Label_0035;
            }
            goto Label_0072;
        Label_00D0:
            if (!flag)
            {
                goto Label_0236;
            }
            parameter.DbType = (DbType) x5fa349731ac3ba80;
            goto Label_00A4;
        Label_00ED:
            parameter.DbType = (DbType) this.Data.Context.Data.Provider.GetDbTypeForClrType(xbcea506a33cf9111.GetType());
            if ((((uint) flag) - ((uint) x0ceec69a97f73617)) < 0)
            {
                goto Label_0072;
            }
            if ((((uint) flag) - ((uint) x0ceec69a97f73617)) >= 0)
            {
                goto Label_00A4;
            }
        Label_0147:
            if (!flag)
            {
                goto Label_021C;
            }
            while ((((uint) flag) + ((uint) flag)) < 0)
            {
                if ((((uint) flag) & 0) != 0)
                {
                    goto Label_0147;
                }
                goto Label_00ED;
            }
            if ((((uint) flag) - ((uint) x0ceec69a97f73617)) <= uint.MaxValue)
            {
                goto Label_00ED;
            }
            goto Label_00A4;
        Label_01AB:
            parameter.DbType = (DbType) this.Data.Context.Data.Provider.GetDbTypeForClrType(xbcea506a33cf9111.GetType());
            goto Label_00A4;
        Label_01E7:
            if (str == "Guid")
            {
                parameter.DbType = DbType.String;
                goto Label_00A4;
            }
            goto Label_01AB;
        Label_021C:
            str = xbcea506a33cf9111.GetType().Name;
        Label_0229:
            switch (str)
            {
                case null:
                    goto Label_01AB;

                case "Boolean":
                    parameter.DbType = DbType.Int32;
                    goto Label_00A4;

                default:
                    goto Label_01E7;
            }
        Label_0236:
            flag = this.Data.Context.Data.ProviderType != DbProviderTypes.Oracle;
            if ((((uint) flag) - ((uint) x0ceec69a97f73617)) >= 0)
            {
                goto Label_0339;
            }
            goto Label_0305;
        Label_02BC:
            xbcea506a33cf9111 = (int) xbcea506a33cf9111;
        Label_02E9:
            parameter = this.Data.InnerCommand.CreateParameter();
            flag = x5fa349731ac3ba80 != DataTypes.Object;
            if (15 != 0)
            {
                if ((((uint) flag) + ((uint) x0ceec69a97f73617)) >= 0)
                {
                    goto Label_00D0;
                }
                if (((uint) flag) < 0)
                {
                    if ((((uint) x0ceec69a97f73617) >= 0) || (2 != 0))
                    {
                        goto Label_0305;
                    }
                    goto Label_02BC;
                }
            }
            if (0 == 0)
            {
                goto Label_0236;
            }
            goto Label_0339;
        Label_0305:
            while (!flag)
            {
                xbcea506a33cf9111 = DBNull.Value;
                if (0 == 0)
                {
                    break;
                }
            }
            flag = !xbcea506a33cf9111.GetType().IsEnum;
            if (!flag)
            {
                goto Label_02BC;
            }
            if ((((uint) flag) + ((uint) flag)) < 0)
            {
                goto Label_01E7;
            }
            goto Label_02E9;
        Label_0339:
            if ((((uint) x0ceec69a97f73617) - ((uint) flag)) >= 0)
            {
                if ((((uint) x0ceec69a97f73617) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_0147;
                }
                goto Label_021C;
            }
            goto Label_00D0;
        }

        public DbCommandData Data
        {
            [CompilerGenerated]
            get
            {
                return this.x51db2148b67c32e9;
            }
            [CompilerGenerated]
            private set
            {
                this.x51db2148b67c32e9 = value;
            }
        }

        public Ms.Data.IDbCommand x752fa651a1424d9d
        {
            get
            {
                if (!this.Data.Context.Data.Provider.SupportsMultipleResultset)
                {
                    throw new Ms.Data.DataException("The selected database does not support multiple resultset");
                    if (0 != 0)
                    {
                    }
                }
                this.Data.UseMultipleResultsets = true;
                return this;
            }
        }
    }
}


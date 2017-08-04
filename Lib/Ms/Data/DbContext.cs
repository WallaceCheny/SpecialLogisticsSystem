namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Configuration;
    using System.Dynamic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class DbContext : IDbContext, IDisposable
    {
        [CompilerGenerated]
        private DbContextData x51db2148b67c32e9;

        public DbContext()
        {
            this.Data = new DbContextData();
        }

        public IDbContext CommandTimeout(int timeout)
        {
            this.Data.CommandTimeout = timeout;
            return this;
        }

        public IDbContext Commit()
        {
            this.xa8e906fe362fe704(new Action(this.x0c57490c066ac17d));
            return this;
        }

        public IDbContext ConnectionString(string connectionString, DbProviderTypes dbProviderType)
        {
            this.xe6bfc0d601246e9e(connectionString, dbProviderType, new DbProviderFactory().GetDbProvider(dbProviderType));
            return this;
        }

        public IDbContext ConnectionString(string connectionString, IDbProvider dbProvider)
        {
            this.xe6bfc0d601246e9e(connectionString, DbProviderTypes.Custom, dbProvider);
            return this;
        }

        public IDbContext ConnectionStringName(string connectionstringName, DbProviderTypes dbProviderType)
        {
            this.xe6bfc0d601246e9e(this.xb470c845529d1dd5(connectionstringName), dbProviderType, new DbProviderFactory().GetDbProvider(dbProviderType));
            return this;
        }

        public IDbContext ConnectionStringName(string connectionstringName, IDbProvider dbProvider)
        {
            this.xe6bfc0d601246e9e(this.xb470c845529d1dd5(connectionstringName), DbProviderTypes.Custom, dbProvider);
            return this;
        }

        public IDeleteBuilder Delete(string tableName)
        {
            return new x7e9f16120f42ee43(this.x43ee399fedec3396, tableName);
        }

        public IDeleteBuilder<T> Delete<T>(string tableName, T item)
        {
            return new x325e977a1713db84<T>(this.x43ee399fedec3396, tableName, item);
        }

        public void Dispose()
        {
            this.x20842211e363c9b2();
        }

        public IDbContext EntityFactory(IEntityFactory entityFactory)
        {
            this.Data.EntityFactory = entityFactory;
            return this;
        }

        public IInsertBuilder Insert(string tableName)
        {
            return new x68e123d035d99be8(this.x43ee399fedec3396, tableName);
        }

        public IInsertBuilder<T> Insert<T>(string tableName, T item)
        {
            return new x7516dee69c394cd3<T>(this.x43ee399fedec3396, tableName, item);
        }

        public IInsertBuilderDynamic Insert(string tableName, ExpandoObject item)
        {
            return new x2e8857009b3c3834(this.x43ee399fedec3396, tableName, item);
        }

        public IDbContext IsolationLevel(Ms.Data.IsolationLevel isolationLevel)
        {
            this.Data.IsolationLevel = isolationLevel;
            return this;
        }

        public IDbCommand MultiResultSql(string sql = "", params object[] parameters)
        {
            int num;
            IDbCommand command = this.x43ee399fedec3396.x752fa651a1424d9d.Sql(sql);
            bool flag = parameters == null;
            if ((((uint) flag) & 0) != 0)
            {
                goto Label_0020;
            }
            if (flag)
            {
                return command;
            }
            if (((uint) flag) >= 0)
            {
                goto Label_0020;
            }
        Label_0015:
            if (flag)
            {
                command.Parameter(num.ToString(), parameters[num], DataTypes.Object, ParameterDirection.Input, 0);
                if (((uint) flag) <= uint.MaxValue)
                {
                }
                num++;
                goto Label_0050;
            }
            return command;
        Label_0020:
            num = 0;
        Label_0050:
            flag = num < parameters.Count<object>();
            goto Label_0015;
        }

        public IStoredProcedureBuilder MultiResultStoredProcedure(string storedProcedureName)
        {
            this.x28bfa53bd5a42c46();
            return new xad085146f9c57cc2(this.x43ee399fedec3396.x752fa651a1424d9d, storedProcedureName);
        }

        public IStoredProcedureBuilder<T> MultiResultStoredProcedure<T>(string storedProcedureName, T item)
        {
            this.x28bfa53bd5a42c46();
            return new xac680fb937640290<T>(this.x43ee399fedec3396.x752fa651a1424d9d, storedProcedureName, item);
        }

        public IStoredProcedureBuilderDynamic MultiResultStoredProcedure(string storedProcedureName, ExpandoObject item)
        {
            this.x28bfa53bd5a42c46();
            return new x1b7999cdaf7f05c9(this.Data.Provider, this.x43ee399fedec3396.x752fa651a1424d9d, storedProcedureName, item);
        }

        public IDbContext OnConnectionClosed(Action<OnConnectionClosedEventArgs> action)
        {
            this.Data.OnConnectionClosed = action;
            return this;
        }

        public IDbContext OnConnectionOpened(Action<OnConnectionOpenedEventArgs> action)
        {
            this.Data.OnConnectionOpened = action;
            return this;
        }

        public IDbContext OnConnectionOpening(Action<OnConnectionOpeningEventArgs> action)
        {
            this.Data.OnConnectionOpening = action;
            return this;
        }

        public IDbContext OnError(Action<OnErrorEventArgs> action)
        {
            this.Data.OnError = action;
            return this;
        }

        public IDbContext OnExecuted(Action<OnExecutedEventArgs> action)
        {
            this.Data.OnExecuted = action;
            return this;
        }

        public IDbContext OnExecuting(Action<OnExecutingEventArgs> action)
        {
            this.Data.OnExecuting = action;
            return this;
        }

        public IDbContext Rollback()
        {
            this.xa8e906fe362fe704(new Action(this.x17faf562711bea62));
            return this;
        }

        public ISelectBuilder<TEntity> Select<TEntity>(string sql)
        {
            return new x67fcadd56269c193<TEntity>(this.x43ee399fedec3396).Select(sql);
        }

        public ISelectBuilder<TEntity> Select<TEntity>(string sql, Expression<Func<TEntity, object>> mapToProperty)
        {
            return new x67fcadd56269c193<TEntity>(this.x43ee399fedec3396).Select(sql, mapToProperty);
        }

        public IDbCommand Sql(string sql, params object[] parameters)
        {
            IDbCommand command = this.x43ee399fedec3396.Sql(sql);
            if (parameters == null)
            {
                return command;
            }
            int index = 0;
            while (true)
            {
                if (index < parameters.Count<object>())
                {
                    command.Parameter(index.ToString(), parameters[index], DataTypes.Object, ParameterDirection.Input, 0);
                    do
                    {
                        index++;
                    }
                    while (0xff == 0);
                }
                else
                {
                    return command;
                }
                if (((uint) index) <= uint.MaxValue)
                {
                }
            }
        }

        public IStoredProcedureBuilder StoredProcedure(string storedProcedureName)
        {
            this.x28bfa53bd5a42c46();
            return new xad085146f9c57cc2(this.x43ee399fedec3396, storedProcedureName);
        }

        public IStoredProcedureBuilderDynamic StoredProcedure(string storedProcedureName, ExpandoObject item)
        {
            this.x28bfa53bd5a42c46();
            return new x1b7999cdaf7f05c9(this.Data.Provider, this.x43ee399fedec3396, storedProcedureName, item);
        }

        public IStoredProcedureBuilder<T> StoredProcedure<T>(string storedProcedureName, T item)
        {
            this.x28bfa53bd5a42c46();
            return new xac680fb937640290<T>(this.x43ee399fedec3396, storedProcedureName, item);
        }

        public IUpdateBuilder Update(string tableName)
        {
            return new xdf8bb929b6dc0786(this.Data.Provider, this.x43ee399fedec3396, tableName);
        }

        public IUpdateBuilder<T> Update<T>(string tableName, T item)
        {
            return new x9e4b3a611cb04b16<T>(this.Data.Provider, this.x43ee399fedec3396, tableName, item);
        }

        public IUpdateBuilderDynamic Update(string tableName, ExpandoObject item)
        {
            return new x23c92ba31a996ed6(this.Data.Provider, this.x43ee399fedec3396, tableName, item);
        }

        public IDbContext UseSharedConnection(bool useSharedConnection)
        {
            this.Data.UseSharedConnection = useSharedConnection;
            return this;
        }

        public IDbContext UseTransaction(bool useTransaction)
        {
            this.Data.UseTransaction = useTransaction;
            return this;
        }

        [CompilerGenerated]
        private void x0c57490c066ac17d()
        {
            this.Data.Transaction.Commit();
        }

        [CompilerGenerated]
        private void x17faf562711bea62()
        {
            this.Data.Transaction.Rollback();
        }

        internal void x20842211e363c9b2()
        {
            // This item is obfuscated and can not be translated.
            bool flag = this.Data.Connection != null;
            goto Label_009E;
        Label_0018:
            this.Data.Connection.Close();
            flag = this.Data.OnConnectionClosed == null;
            if (flag)
            {
                return;
            }
            if (0 != 0)
            {
                goto Label_0089;
            }
            this.Data.OnConnectionClosed(new OnConnectionClosedEventArgs(this.Data.Connection));
            if ((((uint) flag) & 0) == 0)
            {
                return;
            }
        Label_009E:
            while (flag)
            {
                if (!this.Data.UseTransaction)
                {
                }
            Label_0089:
                flag = true;
                while (!flag)
                {
                    this.Rollback();
                    goto Label_0018;
                }
                if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_0018;
                }
                break;
            }
        }

        private void x28bfa53bd5a42c46()
        {
            bool supportsStoredProcedures = this.Data.Provider.SupportsStoredProcedures;
            while (!supportsStoredProcedures)
            {
                throw new DataException("The selected database does not support stored procedures.");
            }
        }

        private void xa8e906fe362fe704(Action xab8fe3cd8c5556fb)
        {
            bool useTransaction = this.Data.Transaction != null;
            goto Label_007C;
        Label_0018:
            this.Data.UseTransaction = false;
            return;
        Label_0077:
            if (!useTransaction)
            {
                goto Label_007F;
            }
            useTransaction = this.Data.UseTransaction;
            if (!useTransaction)
            {
                throw new DataException("Transaction support has not been enabled.");
            }
            xab8fe3cd8c5556fb();
            this.Data.Transaction = null;
            if (((uint) useTransaction) <= uint.MaxValue)
            {
                if (0 != 0)
                {
                    return;
                }
                goto Label_0018;
            }
        Label_007C:
            if (0 == 0)
            {
                goto Label_0077;
            }
        Label_007F:
            this.Data.UseTransaction = false;
            if ((((uint) useTransaction) & 0) == 0)
            {
                return;
            }
            if (0 != 0)
            {
                goto Label_0018;
            }
            goto Label_0077;
        }

        private string xb470c845529d1dd5(string x7a5d2625a8bbfbd4)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[x7a5d2625a8bbfbd4];
            bool flag = settings != null;
            while (true)
            {
                if (!flag)
                {
                    throw new DataException("A connectionstring with the specified name was not found in the .config file");
                }
                do
                {
                    return settings.ConnectionString;
                }
                while ((((uint) flag) - ((uint) flag)) >= 0);
            }
        }

        private void xe6bfc0d601246e9e(string x916ab12f6e6518fc, DbProviderTypes x6c4c7df1035313a9, IDbProvider x4088313242703400)
        {
            this.Data.ConnectionString = x916ab12f6e6518fc;
            this.Data.ProviderType = x6c4c7df1035313a9;
            this.Data.Provider = x4088313242703400;
        }

        public DbContextData Data
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

        public IDbContext IgnoreIfAutoMapFails
        {
            get
            {
                this.Data.IgnoreIfAutoMapFails = true;
                return this;
            }
        }

        private xdcbbfbb72b3e3cda x43ee399fedec3396
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
        }
    }
}


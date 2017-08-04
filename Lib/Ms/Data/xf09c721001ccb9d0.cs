namespace Ms.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal abstract class xf09c721001ccb9d0
    {
        [CompilerGenerated]
        private BuilderData x51db2148b67c32e9;
        [CompilerGenerated]
        private x6447be342da7459f xe27a5a9e4c69d8f5;

        public xf09c721001ccb9d0(Ms.Data.IDbCommand command, string name)
        {
            this.x6b73aa01aa019d3a = new BuilderData(command, name);
            this.xcd08eddb14ea4239 = new x6447be342da7459f(this.x6b73aa01aa019d3a);
        }

        public void Dispose()
        {
            this.x7a274f60ab25f2b9.Dispose();
        }

        public int Execute()
        {
            return this.x7a274f60ab25f2b9.Execute();
        }

        public TParameterType ParameterValue<TParameterType>(string outputParameterName)
        {
            return this.x7a274f60ab25f2b9.ParameterValue<TParameterType>(outputParameterName);
        }

        [return: Dynamic(new bool[] { false, true })]
        public List<object> Query()
        {
            return this.x7a274f60ab25f2b9.Query();
        }

        public List<TEntity> Query<TEntity>(Action<TEntity, Ms.Data.IDataReader> customMapper = null)
        {
            return this.x7a274f60ab25f2b9.Query<TEntity>(customMapper);
        }

        public TList Query<TEntity, TList>(Action<TEntity, Ms.Data.IDataReader> customMapper = null) where TList: IList<TEntity>
        {
            return this.x7a274f60ab25f2b9.Query<TEntity, TList>(customMapper);
        }

        [return: Dynamic]
        public object QueryAndFeild()
        {
            return this.x7a274f60ab25f2b9.QueryAndFeild();
        }

        public void QueryComplex<TEntity>(IList<TEntity> list, Action<IList<TEntity>, Ms.Data.IDataReader> customMapper)
        {
            this.x7a274f60ab25f2b9.QueryComplex<TEntity>(list, customMapper);
        }

        public TEntity QueryComplexSingle<TEntity>(Func<Ms.Data.IDataReader, TEntity> customMapper)
        {
            return this.x7a274f60ab25f2b9.QueryComplexSingle<TEntity>(customMapper);
        }

        [return: Dynamic]
        public object QuerySingle()
        {
            return this.x7a274f60ab25f2b9.QuerySingle();
        }

        public TEntity QuerySingle<TEntity>(Action<TEntity, Ms.Data.IDataReader> customMapper = null)
        {
            return this.x7a274f60ab25f2b9.QuerySingle<TEntity>(customMapper);
        }

        public DataTable x41e0e2218d6bc2dd()
        {
            return this.x7a274f60ab25f2b9.QueryDataTable();
        }

        protected BuilderData x6b73aa01aa019d3a
        {
            [CompilerGenerated]
            get
            {
                return this.x51db2148b67c32e9;
            }
            [CompilerGenerated]
            set
            {
                this.x51db2148b67c32e9 = value;
            }
        }

        private Ms.Data.IDbCommand x7a274f60ab25f2b9
        {
            get
            {
                this.x6b73aa01aa019d3a.Command.CommandType(DbCommandTypes.StoredProcedure);
                this.x6b73aa01aa019d3a.Command.Sql(this.x6b73aa01aa019d3a.Command.Data.Context.Data.Provider.GetSqlForStoredProcedureBuilder(this.x6b73aa01aa019d3a));
                return this.x6b73aa01aa019d3a.Command;
            }
        }

        protected x6447be342da7459f xcd08eddb14ea4239
        {
            [CompilerGenerated]
            get
            {
                return this.xe27a5a9e4c69d8f5;
            }
            [CompilerGenerated]
            set
            {
                this.xe27a5a9e4c69d8f5 = value;
            }
        }
    }
}


namespace Ms.Data
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal abstract class xf3a9e3bf108b45a7
    {
        [CompilerGenerated]
        private BuilderData x51db2148b67c32e9;
        [CompilerGenerated]
        private x6447be342da7459f xe27a5a9e4c69d8f5;

        public xf3a9e3bf108b45a7(IDbCommand command, string name)
        {
            this.x6b73aa01aa019d3a = new BuilderData(command, name);
            this.xcd08eddb14ea4239 = new x6447be342da7459f(this.x6b73aa01aa019d3a);
        }

        public int Execute()
        {
            return this.x7a274f60ab25f2b9.Execute();
        }

        public T ExecuteReturnLastId<T>(string identityColumnName = null)
        {
            return this.x7a274f60ab25f2b9.ExecuteReturnLastId<T>(identityColumnName);
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

        private IDbCommand x7a274f60ab25f2b9
        {
            get
            {
                this.x6b73aa01aa019d3a.Command.Sql(this.x6b73aa01aa019d3a.Command.Data.Context.Data.Provider.GetSqlForInsertBuilder(this.x6b73aa01aa019d3a));
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


namespace Ms.Data
{
    using mscorlib;
    using System;
    using System.Runtime.CompilerServices;

    internal abstract class x820de93bc2090b75
    {
        [CompilerGenerated]
        private BuilderData x51db2148b67c32e9;
        [CompilerGenerated]
        private x6447be342da7459f xe27a5a9e4c69d8f5;

        public x820de93bc2090b75(IDbProvider provider, IDbCommand command, string name)
        {
            this.x6b73aa01aa019d3a = new BuilderData(command, name);
            this.xcd08eddb14ea4239 = new x6447be342da7459f(this.x6b73aa01aa019d3a);
        }

        public int Execute()
        {
            return this.x7a274f60ab25f2b9.Execute();
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
                System.Boolean ReflectorVariable0;
                if (this.x6b73aa01aa019d3a.Columns.Count == 0)
                {
                    ReflectorVariable0 = false;
                }
                else
                {
                    ReflectorVariable0 = true;
                }
                bool flag = ReflectorVariable0 ? (this.x6b73aa01aa019d3a.Where.Count != 0) : false;
                if (((((uint) flag) + ((uint) flag)) < 0) || !flag)
                {
                    throw new DataException("Columns or where filter have not yet been added.");
                }
                this.x6b73aa01aa019d3a.Command.Sql(this.x6b73aa01aa019d3a.Command.Data.Context.Data.Provider.GetSqlForUpdateBuilder(this.x6b73aa01aa019d3a));
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


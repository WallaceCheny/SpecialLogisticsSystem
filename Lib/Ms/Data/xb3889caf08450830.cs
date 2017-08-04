namespace Ms.Data
{
    using System;
    using System.Runtime.CompilerServices;

    internal abstract class xb3889caf08450830
    {
        [CompilerGenerated]
        private BuilderData x51db2148b67c32e9;
        [CompilerGenerated]
        private x6447be342da7459f xe27a5a9e4c69d8f5;

        public xb3889caf08450830(IDbCommand command, string name)
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
                this.x6b73aa01aa019d3a.Command.Sql(this.x6b73aa01aa019d3a.Command.Data.Context.Data.Provider.GetSqlForDeleteBuilder(this.x6b73aa01aa019d3a));
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


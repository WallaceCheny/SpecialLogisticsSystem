namespace Ms.Data
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    public class DbCommandData
    {
        [CompilerGenerated]
        private bool x550df9dde7f4e6b3;
        [CompilerGenerated]
        private Ms.Data.IDataReader x6f5d796712128749;
        internal Ms.Data.x876bc5bb5331d9cc x876bc5bb5331d9cc;
        [CompilerGenerated]
        private System.Data.IDbCommand xbc50203e6607c8dc;
        [CompilerGenerated]
        private DbContext xc76e5f91e3b5be40;

        public DbCommandData(DbContext context, System.Data.IDbCommand innerCommand)
        {
            this.Context = context;
            this.InnerCommand = innerCommand;
            this.InnerCommand.CommandType = CommandType.Text;
        }

        public DbContext Context
        {
            [CompilerGenerated]
            get
            {
                return this.xc76e5f91e3b5be40;
            }
            [CompilerGenerated]
            private set
            {
                this.xc76e5f91e3b5be40 = value;
            }
        }

        public System.Data.IDbCommand InnerCommand
        {
            [CompilerGenerated]
            get
            {
                return this.xbc50203e6607c8dc;
            }
            [CompilerGenerated]
            private set
            {
                this.xbc50203e6607c8dc = value;
            }
        }

        public Ms.Data.IDataReader Reader
        {
            [CompilerGenerated]
            get
            {
                return this.x6f5d796712128749;
            }
            [CompilerGenerated]
            set
            {
                this.x6f5d796712128749 = value;
            }
        }

        public bool UseMultipleResultsets
        {
            [CompilerGenerated]
            get
            {
                return this.x550df9dde7f4e6b3;
            }
            [CompilerGenerated]
            set
            {
                this.x550df9dde7f4e6b3 = value;
            }
        }
    }
}


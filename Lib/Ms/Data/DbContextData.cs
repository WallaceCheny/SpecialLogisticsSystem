namespace Ms.Data
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    public class DbContextData
    {
        [CompilerGenerated]
        private IDbTransaction x0abfd9c64c4b1663;
        [CompilerGenerated]
        private bool x0bb558b8c721226c;
        [CompilerGenerated]
        private IDbProvider x13141ac30d5126a0;
        [CompilerGenerated]
        private Ms.Data.IsolationLevel x1d43bad78d4a93d6;
        [CompilerGenerated]
        private DbProviderTypes x3ef9c0fea7f42398;
        [CompilerGenerated]
        private string x4f659807c0196ad9;
        [CompilerGenerated]
        private Action<OnConnectionOpeningEventArgs> x5c38dafb5c31fcf4;
        [CompilerGenerated]
        private Action<OnConnectionOpenedEventArgs> xac6d2d3cb9b08886;
        [CompilerGenerated]
        private Action<OnErrorEventArgs> xb34b2a25e03c1657;
        [CompilerGenerated]
        private IEntityFactory xbd99e92be9528563;
        [CompilerGenerated]
        private int xbdf2d09899f1a9fc;
        [CompilerGenerated]
        private bool xc444231889df1420;
        [CompilerGenerated]
        private Action<OnExecutingEventArgs> xd1b3d528cbe32c73;
        [CompilerGenerated]
        private IDbConnection xd32352bb2a21c4d7;
        [CompilerGenerated]
        private bool xd76eee1ae3b9afb9;
        [CompilerGenerated]
        private Action<OnConnectionClosedEventArgs> xd7e77c9d88e4cf86;
        [CompilerGenerated]
        private Action<OnExecutedEventArgs> xf57b5d2f0e382325;

        public DbContextData()
        {
            this.IgnoreIfAutoMapFails = false;
            this.UseTransaction = false;
            if (-2 != 0)
            {
                this.IsolationLevel = Ms.Data.IsolationLevel.ReadCommitted;
            }
            this.EntityFactory = new Ms.Data.EntityFactory();
            this.CommandTimeout = -2147483648;
        }

        public int CommandTimeout
        {
            [CompilerGenerated]
            get
            {
                return this.xbdf2d09899f1a9fc;
            }
            [CompilerGenerated]
            set
            {
                this.xbdf2d09899f1a9fc = value;
            }
        }

        public IDbConnection Connection
        {
            [CompilerGenerated]
            get
            {
                return this.xd32352bb2a21c4d7;
            }
            [CompilerGenerated]
            set
            {
                this.xd32352bb2a21c4d7 = value;
            }
        }

        public string ConnectionString
        {
            [CompilerGenerated]
            get
            {
                return this.x4f659807c0196ad9;
            }
            [CompilerGenerated]
            set
            {
                this.x4f659807c0196ad9 = value;
            }
        }

        public IEntityFactory EntityFactory
        {
            [CompilerGenerated]
            get
            {
                return this.xbd99e92be9528563;
            }
            [CompilerGenerated]
            set
            {
                this.xbd99e92be9528563 = value;
            }
        }

        public bool IgnoreIfAutoMapFails
        {
            [CompilerGenerated]
            get
            {
                return this.x0bb558b8c721226c;
            }
            [CompilerGenerated]
            set
            {
                this.x0bb558b8c721226c = value;
            }
        }

        public Ms.Data.IsolationLevel IsolationLevel
        {
            [CompilerGenerated]
            get
            {
                return this.x1d43bad78d4a93d6;
            }
            [CompilerGenerated]
            set
            {
                this.x1d43bad78d4a93d6 = value;
            }
        }

        public Action<OnConnectionClosedEventArgs> OnConnectionClosed
        {
            [CompilerGenerated]
            get
            {
                return this.xd7e77c9d88e4cf86;
            }
            [CompilerGenerated]
            set
            {
                this.xd7e77c9d88e4cf86 = value;
            }
        }

        public Action<OnConnectionOpenedEventArgs> OnConnectionOpened
        {
            [CompilerGenerated]
            get
            {
                return this.xac6d2d3cb9b08886;
            }
            [CompilerGenerated]
            set
            {
                this.xac6d2d3cb9b08886 = value;
            }
        }

        public Action<OnConnectionOpeningEventArgs> OnConnectionOpening
        {
            [CompilerGenerated]
            get
            {
                return this.x5c38dafb5c31fcf4;
            }
            [CompilerGenerated]
            set
            {
                this.x5c38dafb5c31fcf4 = value;
            }
        }

        public Action<OnErrorEventArgs> OnError
        {
            [CompilerGenerated]
            get
            {
                return this.xb34b2a25e03c1657;
            }
            [CompilerGenerated]
            set
            {
                this.xb34b2a25e03c1657 = value;
            }
        }

        public Action<OnExecutedEventArgs> OnExecuted
        {
            [CompilerGenerated]
            get
            {
                return this.xf57b5d2f0e382325;
            }
            [CompilerGenerated]
            set
            {
                this.xf57b5d2f0e382325 = value;
            }
        }

        public Action<OnExecutingEventArgs> OnExecuting
        {
            [CompilerGenerated]
            get
            {
                return this.xd1b3d528cbe32c73;
            }
            [CompilerGenerated]
            set
            {
                this.xd1b3d528cbe32c73 = value;
            }
        }

        public IDbProvider Provider
        {
            [CompilerGenerated]
            get
            {
                return this.x13141ac30d5126a0;
            }
            [CompilerGenerated]
            set
            {
                this.x13141ac30d5126a0 = value;
            }
        }

        public DbProviderTypes ProviderType
        {
            [CompilerGenerated]
            get
            {
                return this.x3ef9c0fea7f42398;
            }
            [CompilerGenerated]
            set
            {
                this.x3ef9c0fea7f42398 = value;
            }
        }

        public IDbTransaction Transaction
        {
            [CompilerGenerated]
            get
            {
                return this.x0abfd9c64c4b1663;
            }
            [CompilerGenerated]
            set
            {
                this.x0abfd9c64c4b1663 = value;
            }
        }

        public bool UseSharedConnection
        {
            [CompilerGenerated]
            get
            {
                return this.xc444231889df1420;
            }
            [CompilerGenerated]
            set
            {
                this.xc444231889df1420 = value;
            }
        }

        public bool UseTransaction
        {
            [CompilerGenerated]
            get
            {
                return this.xd76eee1ae3b9afb9;
            }
            [CompilerGenerated]
            set
            {
                this.xd76eee1ae3b9afb9 = value;
            }
        }
    }
}


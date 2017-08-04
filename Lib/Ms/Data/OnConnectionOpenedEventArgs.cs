﻿namespace Ms.Data
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    public class OnConnectionOpenedEventArgs : EventArgs
    {
        [CompilerGenerated]
        private IDbConnection xd32352bb2a21c4d7;

        public OnConnectionOpenedEventArgs(IDbConnection connection)
        {
            this.Connection = connection;
        }

        public IDbConnection Connection
        {
            [CompilerGenerated]
            get
            {
                return this.xd32352bb2a21c4d7;
            }
            [CompilerGenerated]
            private set
            {
                this.xd32352bb2a21c4d7 = value;
            }
        }
    }
}

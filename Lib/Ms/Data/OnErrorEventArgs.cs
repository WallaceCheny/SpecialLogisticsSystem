namespace Ms.Data
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    public class OnErrorEventArgs : EventArgs
    {
        [CompilerGenerated]
        private System.Data.IDbCommand x3cb3452425149a1a;
        [CompilerGenerated]
        private System.Exception x8ec6de36d6ae1a66;

        public OnErrorEventArgs(System.Data.IDbCommand command, System.Exception exception)
        {
            this.Command = command;
            this.Exception = exception;
        }

        public System.Data.IDbCommand Command
        {
            [CompilerGenerated]
            get
            {
                return this.x3cb3452425149a1a;
            }
            [CompilerGenerated]
            private set
            {
                this.x3cb3452425149a1a = value;
            }
        }

        public System.Exception Exception
        {
            [CompilerGenerated]
            get
            {
                return this.x8ec6de36d6ae1a66;
            }
            [CompilerGenerated]
            set
            {
                this.x8ec6de36d6ae1a66 = value;
            }
        }
    }
}


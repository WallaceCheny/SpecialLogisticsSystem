namespace Ms.Data
{
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;

    public class OnExecutingEventArgs : EventArgs
    {
        [CompilerGenerated]
        private System.Data.IDbCommand x3cb3452425149a1a;

        public OnExecutingEventArgs(System.Data.IDbCommand command)
        {
            this.Command = command;
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
    }
}


namespace Ms.Data
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    internal class x4a37bdfb56acb0d7
    {
        private readonly int _x290b74774c0e8b0d;
        private readonly string[] _x594111ac38a96ac9;
        [CompilerGenerated]
        private int x2c232604070cc09d;
        [CompilerGenerated]
        private string x35b9a94250058afe;
        [CompilerGenerated]
        private Type xe0bd931f5d48821f;
        [CompilerGenerated]
        private string xf5f2e0467156fe54;

        public x4a37bdfb56acb0d7(int index, string name, Type type)
        {
            if ((((uint) index) - ((uint) index)) >= 0)
            {
                this.xd1bdf42207dd3638 = index;
                this.x759aa16c2016a289 = name;
                if (-2 == 0)
                {
                    goto Label_002B;
                }
            }
            this.x8c225d0cd57e028e = name.ToLower();
        Label_002B:
            this.x3146d638ec378671 = type;
            this._x594111ac38a96ac9 = this.x8c225d0cd57e028e.Split(new char[] { '_' });
            this._x290b74774c0e8b0d = this._x594111ac38a96ac9.Count<string>() - 1;
        }

        public string x0cd10fbfebb3c22e(int x66bbd7ed8c65740d)
        {
            return this._x594111ac38a96ac9[x66bbd7ed8c65740d];
        }

        public Type x3146d638ec378671
        {
            [CompilerGenerated]
            get
            {
                return this.xe0bd931f5d48821f;
            }
            [CompilerGenerated]
            private set
            {
                this.xe0bd931f5d48821f = value;
            }
        }

        public string x759aa16c2016a289
        {
            [CompilerGenerated]
            get
            {
                return this.x35b9a94250058afe;
            }
            [CompilerGenerated]
            private set
            {
                this.x35b9a94250058afe = value;
            }
        }

        public string x8c225d0cd57e028e
        {
            [CompilerGenerated]
            get
            {
                return this.xf5f2e0467156fe54;
            }
            [CompilerGenerated]
            private set
            {
                this.xf5f2e0467156fe54 = value;
            }
        }

        public bool x8e7bb903caaeab6e
        {
            get
            {
                return (this.x759aa16c2016a289.IndexOf("Ms_Data_") > -1);
            }
        }

        public int x9343790b5b7c2452
        {
            get
            {
                return this._x290b74774c0e8b0d;
            }
        }

        public int xd1bdf42207dd3638
        {
            [CompilerGenerated]
            get
            {
                return this.x2c232604070cc09d;
            }
            [CompilerGenerated]
            private set
            {
                this.x2c232604070cc09d = value;
            }
        }
    }
}


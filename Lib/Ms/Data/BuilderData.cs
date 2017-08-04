namespace Ms.Data
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class BuilderData
    {
        [CompilerGenerated]
        private int x2f1464dea7b6c562;
        [CompilerGenerated]
        private string x32f86994ea37ac21;
        [CompilerGenerated]
        private IDbCommand x3cb3452425149a1a;
        [CompilerGenerated]
        private string x41386dcaea115417;
        [CompilerGenerated]
        private object x4a5ade090ff06e7e;
        [CompilerGenerated]
        private List<TableColumn> x60939e36e8d838c6;
        [CompilerGenerated]
        private string x7083c235cbfd150e;
        [CompilerGenerated]
        private int x93b231d4570423cf;
        [CompilerGenerated]
        private string xa44c5cd3b8d74611;
        [CompilerGenerated]
        private string xab0af4cd6a495db4;
        [CompilerGenerated]
        private string xc5ae14525e08cf4a;
        [CompilerGenerated]
        private string xd38c30c05eab6283;
        [CompilerGenerated]
        private List<TableColumn> xeb82b939f1c228c9;

        public BuilderData(IDbCommand command, string objectName)
        {
            this.ObjectName = objectName;
            this.Command = command;
            this.Columns = new List<TableColumn>();
            if (-1 != 0)
            {
                this.Where = new List<TableColumn>();
                this.Having = "";
                this.GroupBy = "";
            }
            this.OrderBy = "";
            this.From = "";
            this.Select = "";
            if (0 == 0)
            {
                this.WhereSql = "";
                this.PagingCurrentPage = 1;
                this.PagingItemsPerPage = 0;
            }
        }

        internal int xf4393586de9748ad()
        {
            return (this.PagingCurrentPage * this.PagingItemsPerPage);
        }

        internal int xfe758c7684820895()
        {
            return ((this.xf4393586de9748ad() - this.PagingItemsPerPage) + 1);
        }

        public List<TableColumn> Columns
        {
            [CompilerGenerated]
            get
            {
                return this.xeb82b939f1c228c9;
            }
            [CompilerGenerated]
            set
            {
                this.xeb82b939f1c228c9 = value;
            }
        }

        public IDbCommand Command
        {
            [CompilerGenerated]
            get
            {
                return this.x3cb3452425149a1a;
            }
            [CompilerGenerated]
            set
            {
                this.x3cb3452425149a1a = value;
            }
        }

        public string From
        {
            [CompilerGenerated]
            get
            {
                return this.xab0af4cd6a495db4;
            }
            [CompilerGenerated]
            set
            {
                this.xab0af4cd6a495db4 = value;
            }
        }

        public string GroupBy
        {
            [CompilerGenerated]
            get
            {
                return this.x7083c235cbfd150e;
            }
            [CompilerGenerated]
            set
            {
                this.x7083c235cbfd150e = value;
            }
        }

        public string Having
        {
            [CompilerGenerated]
            get
            {
                return this.xc5ae14525e08cf4a;
            }
            [CompilerGenerated]
            set
            {
                this.xc5ae14525e08cf4a = value;
            }
        }

        public object Item
        {
            [CompilerGenerated]
            get
            {
                return this.x4a5ade090ff06e7e;
            }
            [CompilerGenerated]
            set
            {
                this.x4a5ade090ff06e7e = value;
            }
        }

        public string ObjectName
        {
            [CompilerGenerated]
            get
            {
                return this.x32f86994ea37ac21;
            }
            [CompilerGenerated]
            set
            {
                this.x32f86994ea37ac21 = value;
            }
        }

        public string OrderBy
        {
            [CompilerGenerated]
            get
            {
                return this.x41386dcaea115417;
            }
            [CompilerGenerated]
            set
            {
                this.x41386dcaea115417 = value;
            }
        }

        public int PagingCurrentPage
        {
            [CompilerGenerated]
            get
            {
                return this.x2f1464dea7b6c562;
            }
            [CompilerGenerated]
            set
            {
                this.x2f1464dea7b6c562 = value;
            }
        }

        public int PagingItemsPerPage
        {
            [CompilerGenerated]
            get
            {
                return this.x93b231d4570423cf;
            }
            [CompilerGenerated]
            set
            {
                this.x93b231d4570423cf = value;
            }
        }

        public string Select
        {
            [CompilerGenerated]
            get
            {
                return this.xa44c5cd3b8d74611;
            }
            [CompilerGenerated]
            set
            {
                this.xa44c5cd3b8d74611 = value;
            }
        }

        public List<TableColumn> Where
        {
            [CompilerGenerated]
            get
            {
                return this.x60939e36e8d838c6;
            }
            [CompilerGenerated]
            set
            {
                this.x60939e36e8d838c6 = value;
            }
        }

        public string WhereSql
        {
            [CompilerGenerated]
            get
            {
                return this.xd38c30c05eab6283;
            }
            [CompilerGenerated]
            set
            {
                this.xd38c30c05eab6283 = value;
            }
        }
    }
}


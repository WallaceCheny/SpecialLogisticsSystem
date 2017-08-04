namespace Ms.Data
{
    using System;
    using System.Runtime.CompilerServices;

    public class TableColumn
    {
        [CompilerGenerated]
        private object x2ce4340e980ebb2e;
        [CompilerGenerated]
        private string x6850b5518d430b33;
        [CompilerGenerated]
        private string xee2194079fcfa76f;

        public TableColumn(string columnName, object value, string parameterName)
        {
            this.ColumnName = columnName;
            this.Value = value;
            this.ParameterName = parameterName;
        }

        public string ColumnName
        {
            [CompilerGenerated]
            get
            {
                return this.xee2194079fcfa76f;
            }
            [CompilerGenerated]
            set
            {
                this.xee2194079fcfa76f = value;
            }
        }

        public string ParameterName
        {
            [CompilerGenerated]
            get
            {
                return this.x6850b5518d430b33;
            }
            [CompilerGenerated]
            set
            {
                this.x6850b5518d430b33 = value;
            }
        }

        public object Value
        {
            [CompilerGenerated]
            get
            {
                return this.x2ce4340e980ebb2e;
            }
            [CompilerGenerated]
            set
            {
                this.x2ce4340e980ebb2e = value;
            }
        }
    }
}


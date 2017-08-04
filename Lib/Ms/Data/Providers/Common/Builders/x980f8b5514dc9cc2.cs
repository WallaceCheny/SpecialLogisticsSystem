namespace Ms.Data.Providers.Common.Builders
{
    using Ms.Data;
    using System;
    using System.Collections.Generic;

    internal class x980f8b5514dc9cc2
    {
        public string x66e80d2fc6a5c50e(IDbProvider x83d0c26038874b92, string x8c73b7619e51103e, BuilderData x4a3f0a05c02f235f)
        {
            TableColumn column;
            string str2;
            List<TableColumn>.Enumerator enumerator;
            bool flag;
            string str = "";
            using (enumerator = x4a3f0a05c02f235f.Columns.GetEnumerator())
            {
                goto Label_0061;
            Label_003C:
                str = str + string.Format("{0} = {1}{2}", x83d0c26038874b92.EscapeColumnName(column.ColumnName), x8c73b7619e51103e, column.ParameterName);
            Label_0061:
                if (enumerator.MoveNext())
                {
                    goto Label_007D;
                }
                goto Label_00D7;
            Label_0072:
                if (!flag)
                {
                    goto Label_00B3;
                }
                if (1 != 0)
                {
                    goto Label_003C;
                }
            Label_007D:
                column = enumerator.Current;
                if (3 == 0)
                {
                    goto Label_0061;
                }
                flag = str.Length <= 0;
                if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_0072;
                }
            Label_00B3:
                str = str + ", ";
                goto Label_003C;
            }
        Label_00D7:
            str2 = "";
            using (enumerator = x4a3f0a05c02f235f.Where.GetEnumerator())
            {
                goto Label_0117;
            Label_00EE:
                if (!flag)
                {
                    goto Label_0126;
                }
            Label_00F2:
                str2 = str2 + string.Format("{0} = {1}{2}", x83d0c26038874b92.EscapeColumnName(column.ColumnName), x8c73b7619e51103e, column.ParameterName);
            Label_0117:
                if (enumerator.MoveNext())
                {
                    goto Label_0136;
                }
                return string.Format("update {0} set {1} where {2}", x4a3f0a05c02f235f.ObjectName, str, str2);
            Label_0126:
                str2 = str2 + " and ";
                goto Label_00F2;
            Label_0136:
                column = enumerator.Current;
                flag = str2.Length <= 0;
                if (0 != 0)
                {
                    goto Label_00F2;
                }
                goto Label_00EE;
            }
        }
    }
}


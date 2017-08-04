namespace Ms.Data.Providers.Common.Builders
{
    using Ms.Data;
    using System;
    using System.Collections.Generic;

    internal class x9e2a6e01e374cc32
    {
        public string x66e80d2fc6a5c50e(IDbProvider x83d0c26038874b92, string x8c73b7619e51103e, BuilderData x4a3f0a05c02f235f)
        {
            string str2;
            string str4;
            string str = "";
        Label_0007:
            str2 = "";
            using (List<TableColumn>.Enumerator enumerator = x4a3f0a05c02f235f.Columns.GetEnumerator())
            {
                TableColumn column;
                bool flag;
            Label_001D:
                flag = enumerator.MoveNext();
            Label_0026:
                if (-1 == 0)
                {
                    goto Label_0062;
                }
                if (flag)
                {
                    goto Label_005A;
                }
                goto Label_00AF;
            Label_0033:
                str2 = str2 + x8c73b7619e51103e + column.ParameterName;
                goto Label_001D;
            Label_0045:
                str = str + x83d0c26038874b92.EscapeColumnName(column.ColumnName);
                goto Label_0033;
            Label_005A:
                column = enumerator.Current;
            Label_0062:
                if (str.Length > 0)
                {
                    if (0x7fffffff == 0)
                    {
                        goto Label_0026;
                    }
                    str = str + ",";
                    str2 = str2 + ",";
                }
                goto Label_0045;
            }
        Label_00AF:
            str4 = string.Format("insert into {0}({1}) values({2})", x4a3f0a05c02f235f.ObjectName, str, str2);
            if (0 != 0)
            {
                goto Label_0007;
            }
            return str4;
        }
    }
}


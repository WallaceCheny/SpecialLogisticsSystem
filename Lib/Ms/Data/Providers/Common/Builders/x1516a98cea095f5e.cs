namespace Ms.Data.Providers.Common.Builders
{
    using Ms.Data;
    using System;
    using System.Collections.Generic;

    internal class x1516a98cea095f5e
    {
        public string x66e80d2fc6a5c50e(IDbProvider x83d0c26038874b92, string x8c73b7619e51103e, BuilderData x4a3f0a05c02f235f)
        {
            string str = "";
            using (List<TableColumn>.Enumerator enumerator = x4a3f0a05c02f235f.Columns.GetEnumerator())
            {
                TableColumn current;
                goto Label_003C;
            Label_0017:
                str = str + string.Format("{0} = {1}{2}", x83d0c26038874b92.EscapeColumnName(current.ColumnName), x8c73b7619e51103e, current.ParameterName);
            Label_003C:
                if (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if ((str.Length > 0) && (0 == 0))
                    {
                        str = str + " and ";
                    }
                    goto Label_0017;
                }
            }
            return string.Format("delete from {0} where {1}", x4a3f0a05c02f235f.ObjectName, str);
        }
    }
}


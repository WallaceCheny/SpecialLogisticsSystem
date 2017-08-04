using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class GridViewExport
    {
        public GridViewExport()
        {
        }

        public int GetDataCount(string filter)
        {
            return 100;
        }

        public StringCollection GetData(string filter, int startRow, int maxRows)
        {
            StringCollection data = new StringCollection();

            for (int i = startRow; i < (startRow + maxRows); i++)
            {
                data.Add(String.Concat("new value ", i.ToString()));
            }

            return data;
        }
    }
}
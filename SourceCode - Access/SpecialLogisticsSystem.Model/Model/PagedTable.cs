using System;
using System.Data;

namespace SpecialLogisticsSystem.Model
{
    [Serializable]
    public class PagedTable
    {
        public PagedTable(int _total, DataTable _rows)
        {
            total = _total;
            rows = _rows;
        }
        public PagedTable(int _total, DataTable _rows, int _pageIndex, int _pageSize)
        {
            total = _total;
            rows = _rows;
            pageIndex = _pageIndex;
            pageSize = _pageSize;
        }
        public int total { get; set; }
        public DataTable rows { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}

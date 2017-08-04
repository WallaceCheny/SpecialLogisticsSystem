using System;
using System.Collections.Generic;

namespace SpecialLogisticsSystem.Model
{
    [Serializable]
    public class PagedList<T> where T : new()
    {
        public PagedList(int _total, IList<T> _rows, int _pageIndex, int _pageSize)
        {
            total = _total;
            rows = _rows;
            pageIndex = _pageIndex;
            pageSize = _pageSize;
        }
        public int total { get; set; }
        public IList<T> rows { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}

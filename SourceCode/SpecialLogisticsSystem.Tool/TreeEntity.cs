using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialLogisticsSystem.Tool
{
    public class TreeEntity
    {
        public string id { get; set; }
        public string text { get; set; }
        public string tip { get; set; }
        public string iconCls { get; set; }
        public bool @checked { get; set; }
        public string state { get; set; }
        public Dictionary<string, object> attributes { get; set; }
        public List<TreeEntity> children { get; set; }
    }
}

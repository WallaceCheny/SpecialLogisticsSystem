using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialLogisticsSystem.Dal
{
    public class MappingModel
    {
        public MappingModel()
        {
            Select = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            Insert = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            Update = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            Delete = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            Procedure = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }
        //public string ConnectionName { get; set; }
        //public string ConnectionString { get; set; }
        //public string ProviderName { get; set; }
        public IDictionary<string, string> Select { get; set; }
        public IDictionary<string, string> Insert { get; set; }
        public IDictionary<string, string> Update { get; set; }
        public IDictionary<string, string> Delete { get; set; }
        public IDictionary<string, string> Procedure { get; set; }
    }
}

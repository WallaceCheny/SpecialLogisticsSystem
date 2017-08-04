using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialLogisticsSystem.Tool
{
    [Serializable]
    public class AjaxActionResult
    {
        public bool IsSuccessfully { get; set; }
        public object Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}

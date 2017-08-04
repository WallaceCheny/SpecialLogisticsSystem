using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SpecialLogisticsSystem.AppPortal
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hyError.Target = "_blank";
                //string path = System.AppDomain.CurrentDomain.BaseDirectory;
                //string currentFilePath = Path.Combine(path, string.Format(@"Log\LogError\{0}.htm", DateTime.Today.ToString("yyyyMMdd")));
                hyError.NavigateUrl = string.Format("/Log/LogError/{0}.htm", DateTime.Today.ToString("yyyyMMdd"));//currentFilePath;
            }
        }
    }
}
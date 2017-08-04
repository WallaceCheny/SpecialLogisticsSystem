using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.AppPortal.UIHelpers.Import;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.UserControl;
using System.IO;
using SpecialLogisticsSystem.Tool;
using Newtonsoft.Json;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class Import : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 数据导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbk_Import_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            IDNameDescription idName = JsonConvert.DeserializeObject<IDNameDescription>(e.Parameter);
            ImportType improtType = (ImportType)Enum.Parse(typeof(ImportType), idName.Description);
            string result = ImportBase.Import(improtType, idName.Name);
            e.Result = result;
        }
    }
}
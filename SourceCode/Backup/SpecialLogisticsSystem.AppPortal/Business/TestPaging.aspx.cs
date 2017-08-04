using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpecialLogisticsSystem.AppPortal.Business
{
    public partial class TestPaging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存运单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbk_input_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse();
            //<ClientSideEvents Click="function(s, e) { alert(1);cbk_input.PerformCallback('1'); }" />
        }
        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            ASPxGridViewExporter1.WriteXlsToResponse();
        }

        protected void wayDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (ASPxGridView1.IsCallback || !IsPostBack)
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(ASPxGridView1.FilterExpression) ? ASPxGridView1.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            //if (ASPxGridView1.IsCallback || !IsPostBack)
            //{
                e.InputParameters["filter"] = !string.IsNullOrEmpty(ASPxGridView1.FilterExpression) ? ASPxGridView1.FilterExpression : string.Empty;
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }
        
    }
}
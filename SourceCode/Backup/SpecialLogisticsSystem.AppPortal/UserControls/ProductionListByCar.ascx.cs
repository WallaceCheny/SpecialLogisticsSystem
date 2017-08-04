using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class ProductionListByCar : BaseUserControl
    {
        string selectMasterID = "selectMasterID";
        public void Refresh()
        {
            this.gridStowage.DataBind();
        }
        public string ClosingJs
        {
            set
            {
                PopupProductList.ClientSideEvents.Closing = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gridWayDetail_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            //Session[selectMasterID] = e.Parameters;
            //stowageDataSource.Select();
            //gridWayDetail.DataBind();

            var grid = sender as DevExpress.Web.ASPxGridView.ASPxGridView;
            var id = grid.GetMasterRowKeyValue();
            QueryInfo<T_Stowage_Detail> queryInfo = new QueryInfo<T_Stowage_Detail>();
            queryInfo.SetQuery("main_id", e.Parameters);
            queryInfo.SetXml("SelectWay");
            IStowageDetailDal _stowaye_detail = UIHelper.Resolve<IStowageDetailDal>();
            grid.DataSource = _stowaye_detail.Select(queryInfo);
            grid.DataBind();

        }

        protected void stowageDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridStowage.FilterExpression))
            {
                e.InputParameters["filter"] = !string.IsNullOrEmpty(gridStowage.FilterExpression) ? gridStowage.FilterExpression : string.Empty;
            }
            else
            {
                e.Cancel = true;
            }
        }
        //protected void wayDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        //{
        //    if (null != Session[selectMasterID])
        //    {
        //        e.InputParameters["filter"] = Session[selectMasterID].ToString();
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}
    }
}
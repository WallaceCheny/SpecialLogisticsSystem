using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraCharts;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using DevExpress.XtraCharts.Web;
using SpecialLogisticsSystem.AppPortal.UIHelpers;
using Newtonsoft.Json;

namespace SpecialLogisticsSystem.AppPortal.Analyze
{
    public partial class FinanceGraphic : BasePage<FinanceGraphic>
    {
        [Dependency]
        public IFinanceDailyDal _finance_daily { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["cp_filter"] = null;
                var master = this.Master as MenuMaster;
                if (null != master)
                {
                    master.MenuToolBar.PageToolBar = PageType.Code;
                }
                BindData();
            }
        }

        private void BindData()
        {
            chtFinance.Series.Clear();
            ChartSearchType searchType = (ChartSearchType)Enum.Parse(typeof(ChartSearchType), comSystem.GetValue());
            ViewType viewtype = ViewType.Bar;
            if (chb_Bar.Checked) viewtype = ViewType.Bar;
            else if (chb_Line.Checked) viewtype = ViewType.Line;
            Series seriesInput = new Series("收入", viewtype);
            Series seriesOutput = new Series("支出", viewtype);
            var queryInfo = new QueryInfo<T_Finance_Daily>();
            if (Session["cp_filter"] != null)
            {
                Dictionary<string, object> query = JsonConvert.DeserializeObject<Dictionary<string, object>>(Session["cp_filter"].ToString());
                queryInfo.SetQuery(query.Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString())).ToDictionary(x => x.Key, y => y.Value));
                //if (queryInfo.Query.ContainsKey("shop_id")) queryInfo.Query["shop_id"] = queryInfo.Query["shop_id"].ToString().Split(',');
            }
            queryInfo.SetXml(string.Format("Chart{0}", searchType.ToString()));
            var data = _finance_daily.Select(queryInfo);
            foreach (dynamic dyn in data)
            {
                SeriesPoint pointInput = new SeriesPoint(dyn.input_date1, dyn.input_money1);
                seriesInput.Points.Add(pointInput);
                SeriesPoint pointOutput = new SeriesPoint(dyn.input_date1, dyn.output_money1);
                seriesOutput.Points.Add(pointOutput);
            }
            seriesInput.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesOutput.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            chtFinance.Series.Add(seriesInput);
            chtFinance.Series.Add(seriesOutput);
            ChartHelper.SetChartStyle(chtFinance, searchType);
        }

        protected void chtFinance_CustomCallback(object sender, CustomCallbackEventArgs e)
        {
            //string[] p = e.Parameter.Split(new string[] { "$wh$" }, StringSplitOptions.RemoveEmptyEntries);
            //string[] pwh = p[1].Split('|');
            //if (pwh.Length > 1 && ConvertHelper.ObjectToInt(pwh[0]) > 0)
            //{
            //    cht_Select.Width = new Unit(pwh[0]);
            //    cht_Select.Height = new Unit(pwh[1]);
            //}
            Session.Add("cp_filter", e.Parameter);
            BindData();
        }
    }
}
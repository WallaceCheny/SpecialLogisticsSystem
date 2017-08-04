using System;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Web;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.Analyze
{
    public partial class CarGrossGraphic : BasePage<CarGrossGraphic>
    {
        [Dependency]
        public IStowageMainDal _stowage { get; set; }

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
            chtStowageGross.Series.Clear();
            var queryInfo = new QueryInfo<T_Stowage_Main>();
            if (Session["cp_filter"] != null)
            {
                Dictionary<string, object> query = JsonConvert.DeserializeObject<Dictionary<string, object>>(Session["cp_filter"].ToString());
                queryInfo.SetQuery(query.Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString())).ToDictionary(x => x.Key, y => y.Value));
                //if (queryInfo.Query.ContainsKey("shop_id")) queryInfo.Query["shop_id"] = queryInfo.Query["shop_id"].ToString().Split(',');
            }
            ViewType viewtype = ViewType.Bar;
            if (chb_Bar.Checked) viewtype = ViewType.Bar;
            else if (chb_Line.Checked) viewtype = ViewType.Line;
            Series seriesInput = new Series("单车收入", viewtype);
            Series seriesOutput = new Series("单车支出", viewtype);
            Series seriesGross = new Series("单车毛利", viewtype);
            queryInfo.SetXml("Chart");
            var data = _stowage.Select(queryInfo);
            foreach (dynamic dyn in data)
            {
                SeriesPoint pointInput = new SeriesPoint(dyn.departure_time ,ConvertHelper.ObjectToDouble(dyn.total_payment));
                seriesInput.Points.Add(pointInput);
                SeriesPoint pointOutput = new SeriesPoint(dyn.departure_time, ConvertHelper.ObjectToDouble(dyn.out_payment));
                seriesOutput.Points.Add(pointOutput);
                SeriesPoint pointGross = new SeriesPoint(dyn.departure_time, ConvertHelper.ObjectToDouble(dyn.gross));
                seriesGross.Points.Add(pointGross);
            }
            seriesInput.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesOutput.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesGross.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            chtStowageGross.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
            chtStowageGross.Series.Add(seriesInput);
            chtStowageGross.Series.Add(seriesOutput);
            chtStowageGross.Series.Add(seriesGross);
        }

        protected void chtStowageGross_CustomCallback(object sender, CustomCallbackEventArgs e)
        {
            Session.Add("cp_filter", e.Parameter);
            BindData();
        }
    }
}
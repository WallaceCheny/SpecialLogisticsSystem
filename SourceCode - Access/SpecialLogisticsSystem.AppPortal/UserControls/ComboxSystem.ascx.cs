using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;
using SpecialLogisticsSystem.UserControl;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class ComboxSystem : BaseUserControl
    {
        public string ClientSideJs
        {
            set
            {
                this.cmbSystem.ClientSideEvents.ValueChanged = value;
            }
        }
        public string codeType
        {
            get;
            set;
        }

        public int Width
        {
            set
            {
                this.cmbSystem.Width = Unit.Pixel(value);
            }
        }

        public int DefaultIndex
        {
            set
            {
                if (cmbSystem.DataSource == null) BindData();
                cmbSystem.SelectedIndex = value;
            }
        }
        public bool IsRequired
        {
            set
            {
                CommonSetting.SetRequired(cmbSystem.ValidationSettings, false);
            }
        }
        public void SetValue(string strCode)
        {
            if (cmbSystem.DataSource == null) BindData();
            var defaultItem = cmbSystem.Items.FindByValue(strCode);
            if (defaultItem != null) defaultItem.Selected = true;
        }
        public string GetValue()
        {
            return ConvertHelper.ObjectToString(cmbSystem.Value);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            if (cmbSystem.DataSource != null) return;
            List<IDNameDescription> listSystem = new List<IDNameDescription>();
            switch (codeType)
            {
                case "SearchType":
                    listSystem = ConvertHelper.EnumnToNameDescription(typeof(SearchType));
                    break;
                case "ChartSearchType":
                    listSystem = ConvertHelper.EnumnToNameDescription(typeof(ChartSearchType));
                    break;
                case "StowageSettleType":
                    listSystem = ConvertHelper.EnumnToNameDescription(typeof(StowageSettleType));
                    break;
                default:
                    break;
            }
            cmbSystem.DataSource = listSystem;
            cmbSystem.DataBind();
        }
    }
}
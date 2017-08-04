using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class LinkMan : BaseUserControl
    {
        public Guid LinkId { get; set; }
        /// <summary>
        /// 是否设置默认值
        /// </summary>
        public bool IsDefault
        {
            set {
                CityLookUp1.IsStartCity = value;
            }
        }

        /// <summary>
        /// 是否是目的的
        /// </summary>
        public bool IsEndCity
        {
            set
            {
                CityLookUp1.IsEndCity = value;
            }
        }

        public string Index
        {
            get
            {
                return ConvertHelper.ObjectToString(ViewState["Index"]);
            }
            set
            {
                ViewState["Index"] = value;
            }
        }

        public bool IsSubRequired
        {
            set
            {
                txtLink.IsSubRequired = value;
                txtMobilePhone.IsSubRequired = value;
                //txtAddress.IsSubRequired = value;
                CityLookUp1.IsSubRequired = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtLink.ID = txtLink.ID + Index;
            CityLookUp1.Index = Index;
            txtMobilePhone.ID = txtMobilePhone.ID + Index;
            txtAddress.ID = txtAddress.ID + Index;
            txtTelephone.ID = txtTelephone.ID + Index;
            txtMemo.ID = txtMemo.ID + Index;
            if (!IsPostBack)
            {
                SetData(LinkId);
            }
        }

        public void SetData(Guid? linkID)
        {
            if (!linkID.HasValue || linkID.Value == null) return;
            var _link = UIHelper.Resolve<ICmLinkDal>();
            T_Cm_Link model = _link.GetSingle(linkID);
            SetData(model);
        }

        public void SetData(T_Cm_Link model)
        {
            if (model == null) return;
            this.LinkId = model.id;
            txtAddress.Text = model.link_address;
            txtLink.Text = model.link_name;
            txtMemo.Text = model.link_memo;
            txtMobilePhone.Text = model.link_mobilephone;
            txtTelephone.Text = model.link_telephone;
            CityLookUp1.SetCityValue(model.link_area);
        }

        public T_Cm_Link GetLink()
        {
            T_Cm_Link model = new T_Cm_Link();
            model.id = (LinkId != null && LinkId!= Guid.Empty) ? LinkId : Guid.NewGuid();
            model.link_address = txtAddress.Text;
            model.link_name = txtLink.Text;
            model.link_memo = txtMemo.Text;
            model.link_mobilephone = txtMobilePhone.Text;
            model.link_telephone = txtTelephone.Text;
            model.link_area = CityLookUp1.GetCityValue();
            return model;
        }
    }
}
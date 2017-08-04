using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Web.ASPxGridView;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UserControls
{
    public partial class CustomerLookUp : BaseLookUp
    {
        private string _strSessionName = "SessionID";
        
        public string ClientSideJs
        {
            set
            {
                this.customer_customelookup.ClientSideEvents.ValueChanged = value;
            }
        }
       
        public string LostFocusJs
        {
            set
            {
                this.customer_customelookup.ClientSideEvents.LostFocus = value;
            }
        }
        private CustomerType _customerEnum;
        public CustomerType CustomerEnum
        {
            get
            {
                return _customerEnum;
            }
            set
            {
                _customerEnum = value;
                if (_customerEnum == CustomerType.Consignee)
                {
                    customer_customelookup.GridView.CustomCallback +=
                        new DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventHandler(grdView_GridViewCustomCallback);
                }
                hideText.ID = hideText.ID + value.ToString();
            }
        }
        private Guid? _sendID;
        public Guid? SendID
        {
            get { return _sendID; }
            set
            {
                _sendID = value;
                if (Session[_strSessionName] == null)
                    Session[_strSessionName] = value;
            }
        }

        public void BindConsigneeData()
        {
            BindData();
        }

        protected override void BindData()
        {
            if (CustomerEnum == CustomerType.Consignee && (Session[_strSessionName] == null || string.IsNullOrEmpty(Session[_strSessionName].ToString()))) return; 
            ICmCustomerDal _customer = UIHelper.Resolve<ICmCustomerDal>();
            QueryInfo<T_Cm_Customer> queryInfo = new QueryInfo<T_Cm_Customer>();       
            if (CustomerEnum == CustomerType.Consignee && Session[_strSessionName] != null)
            {
                queryInfo.SetQuery(T_Cm_Customer.SenderIdColumnName, Session[_strSessionName].ToString());
            }
            else
            {
                 queryInfo.SetQuery(T_Cm_Customer.CustomerTypeColumnName, CustomerEnum.ToString());
            }
            List<dynamic> results = _customer.Select(queryInfo).ToList();
            //if (!string.IsNullOrEmpty(hideText.Value) &&
            //    results.Count(prop => prop.link_name == hideText.Value) == 0)
            //{
            //    //如果没有找到对应的值，添加一条
            //    Guid newID = Guid.NewGuid();
            //    if (CustomerEnum == CustomerType.Deliver) Session[_strSessionName] = newID;
            //    //添加到数据库
            //    T_Cm_Link _link = new T_Cm_Link()
            //    {
            //        id = Guid.NewGuid(),
            //        link_name = hideText.Value,
            //        link_mobilephone = string.Empty,
            //        link_telephone = string.Empty,
            //        link_area = string.Empty,
            //        link_address = string.Empty,
            //    };
            //    T_Cm_Customer newCustomer = new T_Cm_Customer()
            //    {
            //        id = newID,
            //        customer_name = hideText.Value,
            //        link = _link,
            //        customer_type = CustomerEnum.ToString(),
            //    };
            //    if (Session[_strSessionName] != null
            //        && CustomerEnum == CustomerType.Consignee)
            //    {
            //        newCustomer.sender_id = ConvertHelper.ObjectToGuid(Session[_strSessionName].ToString()).Value;
            //    }
            //    _customer.Insert(newCustomer);
            //    results = _customer.Select(queryInfo).ToList();
            //}
            customer_customelookup.DataSource = results;
            customer_customelookup.DataBind();
        }

        protected override UserControl.ASPxGridLookup _lookUp
        {
            get { return this.customer_customelookup; }
        }

        private void grdView_GridViewCustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                //string valueParameter = e.Parameters;
                //string[] strParameters = valueParameter.Split(';');
                //if (strParameters.Length > 1) valueParameter = strParameters[strParameters.Length - 1];
                Guid? id = ConvertHelper.ObjectToGuid(e.Parameters);
                if (id.HasValue)
                {
                    Session[_strSessionName] = id;
                }
                BindData();
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(string.Empty, ex);
            }
        }
    }
}
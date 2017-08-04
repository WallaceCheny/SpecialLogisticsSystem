using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using System.Text;
using SpecialLogisticsSystem.Tool;
using System.Web.Script.Serialization;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class Ajax
    {
        [JsonView]
        public string GetMenu(string action)
        {
            string url = action;
            QueryInfo<T_Cm_Menu> queryInfo = new QueryInfo<T_Cm_Menu>();
            queryInfo.SetQuery(T_Cm_Menu.ActionColumnName, action);
            List<T_Cm_Menu> menuList = UIHelper.Resolve<ICmMenuDal>().GetList(queryInfo).ToList();
            string id = string.Empty;
            string name = string.Empty;
            if (menuList.Count > 0)
            {
                T_Cm_Menu menu = menuList.FirstOrDefault();
                id = menu.id.ToString();
                name = menu.name;
                return url + string.Format("?menu_id={0}&menu_name={1}", id, DEncrypt.Escape(name));
            }
            return url;
        }
        [JsonView]
        public string InsertToDetail(string ids, string typeName)
        {
            AjaxActionResult result = new AjaxActionResult();
            result.IsSuccessfully = false;
            string[] idItems = ids.Split(',');
            switch (typeName)
            {
                case "Stowage":
                    StowageDetailTemporary _detailStowage = new StowageDetailTemporary();
                    foreach (var item in idItems)
                    {
                        _detailStowage.Insert(item);
                    }
                    break;
                case "Transfer":
                    TransferDetailTemporary _detailTransfer = new TransferDetailTemporary();
                    foreach (var item in idItems)
                    {
                        _detailTransfer.Insert(item);
                    }
                    break;
                case "Deliver":
                    DeliverDetailTemporary _detailDeliver = new DeliverDetailTemporary();
                    foreach (var item in idItems)
                    {
                        _detailDeliver.Insert(item);
                    }
                    break;
                default:
                    break;
            }

            result.IsSuccessfully = true;
            string jsonResult = new JavaScriptSerializer().Serialize(result);
            return jsonResult;
        }

        [JsonView]
        public string InsertedCustomer(string value)
        {
            AjaxActionResult result = new AjaxActionResult();
            result.IsSuccessfully = false;
            ICmCustomerDal _customer = UIHelper.Resolve<ICmCustomerDal>();
            //switch (type)
            //{
            //    case "/Cm/Customer.aspx":
                    //如果没有找到对应的值，添加一条到数据库
                    T_Cm_Link _link = new T_Cm_Link()
                    {
                        id = Guid.NewGuid(),
                        link_name = value,
                        link_mobilephone = string.Empty,
                        link_telephone = string.Empty,
                        link_area = string.Empty,
                        link_address = string.Empty,
                    };
                    T_Cm_Customer newCustomer = new T_Cm_Customer()
                    {
                        id = Guid.NewGuid(),
                        customer_name = value,
                        link = _link,
                        customer_type = CustomerType.Deliver.ToString(),
                    };
                    //if (Session[_strSessionName] != null
                    //    && CustomerEnum == CustomerType.Consignee)
                    //{
                    //    newCustomer.sender_id = ConvertHelper.ObjectToGuid(Session[_strSessionName].ToString()).Value;
                    //}
                    _customer.Insert(newCustomer);
            //        break;
            //    default:
            //        break;
            //}

            result.IsSuccessfully = true;
            string jsonResult = new JavaScriptSerializer().Serialize(result);
            return jsonResult;
        }

        [JsonView]
        public string CalculateTotalPrice(string freight, string premium,
            string receive_expenses, string other_expenses)
        {
            AjaxActionResult result = new AjaxActionResult();
            decimal dFreight = ConvertHelper.ObjectToDecimal(freight);
            decimal dPremium = ConvertHelper.ObjectToDecimal(premium);
            decimal dReceive_expenses = ConvertHelper.ObjectToDecimal(receive_expenses);
            decimal dOther_expenses = ConvertHelper.ObjectToDecimal(other_expenses);
            result.IsSuccessfully = false;
            decimal total = decimal.Zero;
            CodeHelper codeHelper= new CodeHelper();
            bool isFreeGet = codeHelper.GetConfigResult(ConfigType.IsFreeGet);
            //bool isFreeSet = codeHelper.GetConfigResult(ConfigType.IsFreeSet);
            bool isFreeOther = codeHelper.GetConfigResult(ConfigType.OtherIsFree);
            total = dPremium + dFreight;
            if (!isFreeGet)//接货费不免费的话，计入总运费
            {
                total += dReceive_expenses;
            }
            if (!isFreeOther)
            {
                total += dOther_expenses;
            }
            result.Data = total;
            result.IsSuccessfully = true;
            string jsonResult = new JavaScriptSerializer().Serialize(result);
            return jsonResult;
        }
    }


    [AttributeUsage(AttributeTargets.Method)]
    public class JsonViewAttribute : Attribute
    {
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.Cells;
using System.Text;
using SpecialLogisticsSystem.Dal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers.Import
{
    public class ImportCustomer : ImportBase
    {
        protected override string Import(Cells cells)
        {
            string result = string.Empty;
            int dataRow = cells.MaxDataRow + 1;

            StringBuilder sbErr = new StringBuilder();
            string currentArea = UserProvide.GetCurrentArea();
            ICmCustomerDal _customer = UIHelper.Resolve<ICmCustomerDal>();
            List<T_Cm_Customer> customerList = _customer.GetList(new QueryInfo<T_Cm_Customer>()).ToList();
            int currentRow = 0;
            try
            {
                for (int row = 1; row < dataRow; row++)
                {
                    currentRow = row;
                    // 1. 获取数据
                    //客户名称	联系人	发货人电话	收货单位	收货人电话	收货人所在城市	送货地址
                    //0          1       2             3             4          5                 6
                    string sender_name = cells[row, 0].StringValue;//客户名称
                    string sender_linker = cells[row, 1].StringValue;//联系人
                    string sender_telephone = cells[row, 2].StringValue;//发货人电话
                    string receiver_name = cells[row, 3].StringValue;//收货单位
                    string receiver_mobilephone = cells[row, 4].StringValue;
                    string receiver_city = cells[row, 5].StringValue;//收货人所在城市
                    string receiver_address = cells[row, 6].StringValue;//送货地址

                    //1. 检查是否有发货人信息。
                    T_Cm_Customer sender = customerList.FirstOrDefault(p => p.customer_name == sender_name && p.customer_type == CustomerType.Deliver.ToString()); // .GetSingleByName(sender_name, CustomerType.Deliver);
                    if (sender == null)
                    {
                        //新建
                        sender = new T_Cm_Customer
                        {
                            id = Guid.NewGuid(),
                            customer_name = sender_name,
                            customer_type = CustomerType.Deliver.ToString(),
                        };
                        T_Cm_Link sender_link = new T_Cm_Link
                        {
                            id = Guid.NewGuid(),
                            link_name = sender_linker,
                            link_mobilephone = sender_telephone,
                            link_telephone = sender_telephone,
                            link_area = currentArea,
                        };
                        sender.link = sender_link;
                        _customer.Insert(sender);
                        customerList.Add(sender);
                    }
                    else //更新
                    {
                        T_Cm_Link sender_link = sender.link;
                        sender_link.link_name = sender_linker;
                        sender_link.link_mobilephone = sender_telephone;
                        sender_link.link_telephone = sender_telephone;
                        sender_link.link_area = currentArea;
                        sender.link = sender_link;
                        _customer.Update(sender);
                        customerList.Add(sender);
                    }

                    //2. 检查是否后收货人信息
                    T_Cm_Customer receiver = customerList.FirstOrDefault(p => p.customer_name == receiver_name && p.customer_type == CustomerType.Consignee.ToString());//_customer.GetSingleByName(receiver_name, CustomerType.Consignee);
                    if (receiver == null)
                    {
                        receiver = new T_Cm_Customer
                        {
                            id = Guid.NewGuid(),
                            customer_name = receiver_name,
                            sender_id = sender.id,
                            customer_type = CustomerType.Consignee.ToString(),
                        };
                        T_Cm_Link receiver_link = new T_Cm_Link
                        {
                            id = Guid.NewGuid(),
                            link_name = receiver_name,
                            link_mobilephone = receiver_mobilephone,
                            link_area = receiver_city + " - " + receiver_address,
                            link_address = receiver_address,
                        };
                        receiver.link = receiver_link;
                        _customer.Insert(receiver);
                        customerList.Add(receiver);
                    }
                    else//更新
                    {
                        receiver.customer_name = receiver_name;
                        receiver.sender_id = sender.id;

                        T_Cm_Link receiver_link = receiver.link;
                        receiver_link.link_name = receiver_name;
                        receiver_link.link_mobilephone = receiver_mobilephone;
                        receiver_link.link_area = receiver_city + " - " + receiver_address;
                        receiver_link.link_address = receiver_address;
                        receiver.link = receiver_link;
                        _customer.Update(receiver);
                        customerList.Add(receiver);
                    }

                }
            }
            catch (Exception ex)
            {
                string current = string.Format("第{0}行,导入出错。", currentRow);
                LogHelper.WriteLog(current, ex);
                sbErr.AppendFormat(current);
            }
            if (sbErr.Length < 1)
                result = "导入成功";
            else
                result = sbErr.ToString();
            return result;
        }
    }
}
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
    public class ImportWay : ImportBase
    {
        protected override string Import(Cells cells)
        {

            string result = string.Empty;
            int dataRow = cells.MaxDataRow + 1;

            StringBuilder sbErr = new StringBuilder();
            long currentProvinceID = UserProvide.GetCurrentProvinceID();
            long currentCityID = UserProvide.GetCurrentCityID();
            long? currentDistrictID = UserProvide.GetCurrentDistrictaID();
            string currentArea = UserProvide.GetCurrentCityName();
            IWayBillDal _way = UIHelper.Resolve<IWayBillDal>();
            IWayProductionDal _way_production = UIHelper.Resolve<IWayProductionDal>();
            ICmCustomerDal _customer = UIHelper.Resolve<ICmCustomerDal>();
            ICmLinkDal _link = UIHelper.Resolve<ICmLinkDal>();
            ICmCityDal _city = UIHelper.Resolve<ICmCityDal>();
            ICmDistrictDal _district = UIHelper.Resolve<ICmDistrictDal>();
            List<T_Cm_Customer> customerList = _customer.GetList(new QueryInfo<T_Cm_Customer>()).ToList();
            List<T_Way_Bill> wayList = _way.GetList(new QueryInfo<T_Way_Bill>()).ToList();
            List<T_Cm_City> cityList = _city.GetList(new QueryInfo<T_Cm_City>()).ToList();
            List<T_Cm_District> districtList = _district.GetList(new QueryInfo<T_Cm_District>()).ToList();
            int currentRow = 0;
            try
            {
                for (int row = 1; row < dataRow; row++)
                {
                    currentRow = row;
                    // 1. 获取数据
                    //印刷号	发货日期	到站	发货单位	收货单位	收货人电话	货物名称	件数	重量	体积	已付	提付	回付	回扣	票税	接货费	是否中转	送货费	其他费用	备注送货地址
                    //0          1          2             3        4          5            6         7       8      9       10      11      12      13       14      15       16          17      18           19
                    string way_number = cells[row, 0].StringValue;
                    DateTime? receive_date = ConvertHelper.ObjectToDateTime(cells[row, 1].StringValue);
                    string end_city = cells[row, 2].StringValue;
                    string deliver_name = cells[row, 3].StringValue;
                    string consignee_name = cells[row, 4].StringValue; //没有的话需要新建
                    string consignee_mobile = cells[row, 5].StringValue;
                    decimal spot_payment = ConvertHelper.ObjectToDecimal(cells[row, 10].StringValue);//现付-已付
                    decimal pick_payment = ConvertHelper.ObjectToDecimal(cells[row, 11].StringValue);
                    decimal back_payment = ConvertHelper.ObjectToDecimal(cells[row, 12].StringValue);
                    decimal bill_rebate = ConvertHelper.ObjectToDecimal(cells[row, 13].StringValue);
                    decimal ticket_taxes = ConvertHelper.ObjectToDecimal(cells[row, 14].StringValue);
                    string bill_memo = cells[row, 18].StringValue;
                    WayType way_type = cells[row, 16].StringValue == "是" ? WayType.Transfer : WayType.Special;

                    //货物
                    string production_name = cells[row, 6].StringValue;
                    int production_number = ConvertHelper.ObjectToInt(cells[row, 7].StringValue);
                    decimal production_weight = ConvertHelper.ObjectToDecimal(cells[row, 8].StringValue);
                    decimal production_size = ConvertHelper.ObjectToDecimal(cells[row, 9].StringValue);
                    decimal delivery_expense = ConvertHelper.ObjectToDecimal(cells[row, 15].StringValue);
                    decimal receive_expenses = ConvertHelper.ObjectToDecimal(cells[row, 17].StringValue);
                    decimal other_expenses = ConvertHelper.ObjectToDecimal(cells[row, 18].StringValue);
                    //运费=现付+提付+回付
                    decimal freight = spot_payment + pick_payment + back_payment;


                    //1. 检查是否有运单信息。
                    T_Way_Bill way = wayList.FirstOrDefault(p => p.way_number == way_number);
                    if (way == null)
                    {
                        //2. 检查是否有客户信息。
                        T_Cm_Customer customer = customerList.FirstOrDefault(p => p.customer_name == deliver_name
                            && p.customer_type == CustomerType.Deliver.ToString());
                        if (null == customer)
                        {
                            //新建
                            customer = new T_Cm_Customer
                            {
                                id = Guid.NewGuid(),
                                customer_name = deliver_name,
                                customer_type = CustomerType.Deliver.ToString(),
                            };
                            T_Cm_Link sender_link = new T_Cm_Link
                            {
                                id = Guid.NewGuid(),
                                link_name = deliver_name,
                                link_mobilephone = Constants.strNoMessage,
                                link_province = currentProvinceID,
                                link_city = currentCityID,
                                link_district = currentDistrictID.HasValue? currentDistrictID.Value:0,
                                link_area = currentArea,
                            };
                            customer.link = sender_link;
                            _customer.Insert(customer);
                            customerList.Add(customer);
                        }
                        if (customer.link == null) customer.link = _link.GetSingle(customer.link_id);
                        //3. 检查是否有收货人信息。
                        T_Cm_Customer receiver = customerList.FirstOrDefault(p => p.customer_name == consignee_name
                            && p.customer_type == CustomerType.Consignee.ToString());
                        if (null == receiver)
                        {
                            receiver = new T_Cm_Customer
                            {
                                id = Guid.NewGuid(),
                                customer_name = consignee_name,
                                sender_id = customer.id,
                                customer_type = CustomerType.Consignee.ToString(),
                            };
                            T_Cm_Link receiver_link = new T_Cm_Link
                            {
                                id = Guid.NewGuid(),
                                link_name = consignee_name,
                                link_mobilephone = consignee_mobile,
                                link_address = bill_memo,
                            };
                            T_Cm_City city = cityList.FirstOrDefault(p => p.CityName.Contains(end_city));
                            if (null != city)
                            {
                                receiver_link.link_city = city.CityID;
                                receiver_link.link_province = city.ProvinceID;
                            }
                            else
                            {
                                T_Cm_District district = districtList.FirstOrDefault(p => p.DistrictName.Contains(end_city));
                                if (null != district)
                                {
                                    receiver_link.link_city = district.CityID;
                                    receiver_link.link_district = district.DistrictID;
                                }
                            }
                            receiver_link.link_area = end_city;
                            receiver.link = receiver_link;
                            _customer.Insert(receiver);
                            customerList.Add(receiver);
                        }
                        if (receiver.link == null) receiver.link = _link.GetSingle(receiver.link_id);

                        //4.新建运单信息
                        way = new T_Way_Bill
                        {
                            id = Guid.NewGuid(),
                            start_city = currentArea,
                            end_city = end_city,
                            way_number = way_number,
                            way_type = ((int)way_type).ToString(),
                            bill_memo = bill_memo,
                            bill_statue = WayStatue.Sended.ToString(),
                            deliver_id = customer.id,
                            deliver_address = customer.link.link_address,
                            deliver_area = customer.link.link_area,
                            deliver_mobile = customer.link.link_mobilephone,
                            consignee_address = receiver.link.link_address,
                            consignee_area = receiver.link.link_area,
                            consignee_id = receiver.id,
                            consignee_mobile = consignee_mobile,
                            spot_payment = spot_payment,
                            pick_payment = pick_payment,
                            back_payment = back_payment,
                            bill_rebate = bill_rebate,
                            ticket_taxes = ticket_taxes,
                            receive_date = receive_date.Value,
                        };
                        _way.Insert(way);
                        wayList.Add(way);

                        //5.新建货物信息
                        T_Way_Production production = new T_Way_Production
                        {
                            id = Guid.NewGuid(),
                            bill_id = way.id,
                            production_name = production_name,
                            production_number = production_number,
                            production_size = production_size,
                            production_weight = production_weight,
                            delivery_expense = delivery_expense,
                            receive_expenses=receive_expenses,
                            other_expenses = other_expenses,
                            freight = freight,
                        };
                        _way_production.Insert(production);
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
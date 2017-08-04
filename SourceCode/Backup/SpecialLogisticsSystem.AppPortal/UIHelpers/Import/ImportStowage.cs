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
    public class ImportStowage : ImportBase
    {
        protected override string Import(Aspose.Cells.Cells cells)
        {
            //发货日期	发车日期	车牌号码	司机	随车电话	印刷号	到站	发货单位	收货单位	收货人电话	货物名称	件数	重量	体积	已付	提付	签单	回扣	票税	接货费	中转费	送货费	遇缘宝安路价格	是否送货	备注送货地址	回单签收	其他	


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

            ICmCarDal _car = UIHelper.Resolve<ICmCarDal>();
            List<T_Cm_Car> carList = _car.GetList(new QueryInfo<T_Cm_Car>()).ToList();

            IStowageMainDal _stowage = UIHelper.Resolve<IStowageMainDal>();
            List<T_Stowage_Main> stowageList = _stowage.GetList(new QueryInfo<T_Stowage_Main>()).ToList();
            IStowageDetailDal _stowage_detail = UIHelper.Resolve<IStowageDetailDal>();

            List<T_Way_Production> productionList = _way_production.GetList(new QueryInfo<T_Way_Production>()).ToList();

            int currentRow = 0;
            try
            {
                for (int row = 1; row < dataRow; row++)
                {
                    currentRow = row;
                    // 1. 获取数据
                    // 发货日期	发车日期	车牌号码	司机	随车电话	印刷号	到站	发货单位	收货单位	收货人电话	货物名称	件数	重量	体积	已付	提付	签单	回扣	票税	接货费	中转费	送货费	遇缘宝安路价格	是否送货	备注送货地址	回单签收	其他
                    // 0          1          2           3        4          5        6         7       8               9       10          11      12      13       14      15     16      17      18       19

                    DateTime? departure_time = ConvertHelper.ObjectToDateTime(cells[row, 1].StringValue);
                    string car_no = cells[row, 2].StringValue;
                    string deliver_name = cells[row, 3].StringValue;
                    string deliver_mobile = cells[row, 4].StringValue;
                    string way_number = cells[row, 5].StringValue;


                    //1. 检查是否有司机车辆信息。
                    T_Cm_Car car = carList.FirstOrDefault(p => p.car_no == car_no);
                    if (car == null)
                    {
                        car = new T_Cm_Car
                        {
                            id = Guid.NewGuid(),
                            car_no = car_no,
                        };
                        T_Cm_Link deliver_link = new T_Cm_Link
                        {
                            id = Guid.NewGuid(),
                            link_name = deliver_name,
                            link_mobilephone = deliver_mobile,
                            link_province = currentProvinceID,
                            link_city = currentCityID,
                            link_district = currentDistrictID.HasValue ? currentDistrictID.Value : 0,
                            link_area = currentArea,
                        };
                        car.link = deliver_link;
                        _car.Insert(car);
                        carList.Add(car);
                    }

                    //2. 检查是否有运单信息。
                    T_Way_Bill way = wayList.FirstOrDefault(p => p.way_number == way_number);
                    if (way == null)
                    {
                        //TODO 添加托运单
                        continue;
                    }

                    //3. 检查是否有发车信息。
                    T_Stowage_Main stowage = stowageList.FirstOrDefault(p => p.car_id == car.id && p.departure_time.Date == departure_time.Value.Date);
                    if (stowage == null)
                    {
                        stowage = new T_Stowage_Main
                        {
                            id = Guid.NewGuid(),
                            stowage_number=UIHelper.Resolve<ICmSequenceNumberDal>().GetNumber(CodeTable.Stowage),
                            departure_time = departure_time.Value,
                            car_id = car.id,
                            stowage_statue=StowageStatue.Sended.ToString()
                        };
                        _stowage.Insert(stowage);
                        stowageList.Add(stowage);
                    }

                    //4. 检查是否有发车详细货物信息。
                    T_Way_Production production = productionList.FirstOrDefault(p => p.bill_id == way.id);
                    if (production != null)
                    {
                        T_Stowage_Detail stowage_detail = new T_Stowage_Detail
                        {
                            id = Guid.NewGuid(),
                            main_id = stowage.id,
                            production_id = production.id,
                            production_number = production.production_number,
                        };
                        _stowage_detail.Insert(stowage_detail);
                        //stowageList.Add(_stowage);
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
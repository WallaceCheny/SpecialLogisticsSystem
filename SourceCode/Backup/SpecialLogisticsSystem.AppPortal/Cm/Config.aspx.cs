using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using SpecialLogisticsSystem.IDal;
using SpecialLogisticsSystem.Model;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.AppPortal.Cm
{
    public partial class Config : BasePage<Config>
    {
        [Dependency]
        public ICmConfigDal _config { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QueryInfo<T_Cm_Config> queryInfo = new QueryInfo<T_Cm_Config>();
                List<T_Cm_Config> configList = _config.GetList(queryInfo).ToList();
                string[] names = Enum.GetNames(typeof(ConfigType));
                foreach (var item in configList)
                {
                    ConfigType type = (ConfigType)Enum.Parse(typeof(ConfigType), item.parameter_name);
                    switch (type)
                    {
                        case ConfigType.Theme:
                            break;
                        case ConfigType.StartCity:
                            start_city.SetCityValue(item.parameter_value);
                            break;
                        case ConfigType.EndCity:
                            end_city.SetCityValue(item.parameter_value);
                            break;
                        case ConfigType.IsFreeGet:
                            get_free.Checked = ConvertHelper.ObjectToBool(item.parameter_value);
                            break;
                        case ConfigType.IsFreeSet:
                            set_free.Checked = ConvertHelper.ObjectToBool(item.parameter_value);
                            break;
                        case ConfigType.OtherIsFree:
                            other_free.Checked = ConvertHelper.ObjectToBool(item.parameter_value);
                            break;
                        case ConfigType.SearchType:
                            search_type.SetValue(item.parameter_value);
                            break;
                        case ConfigType.SmsAccountName:
                            txt_account_name.Text = item.parameter_value;
                            break;
                        case ConfigType.SmsAccountPassword:
                            txt_account_password.Attributes.Add("Value", item.parameter_value);
                            break;
                        case ConfigType.SmsSigned:
                            txt_sms_singer.Text = item.parameter_value;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// 保存参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbk_input_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            QueryInfo<T_Cm_Config> queryInfo = new QueryInfo<T_Cm_Config>();
            List<T_Cm_Config> configList = _config.GetList(queryInfo).ToList();

            InsertOrUpdate(configList, ConfigType.StartCity, start_city.GetCityValue());
            InsertOrUpdate(configList, ConfigType.EndCity, end_city.GetCityValue());
            InsertOrUpdate(configList, ConfigType.IsFreeGet, get_free.Checked.ToString());
            InsertOrUpdate(configList, ConfigType.IsFreeSet, set_free.Checked.ToString());
            InsertOrUpdate(configList, ConfigType.OtherIsFree, other_free.Checked.ToString());
            InsertOrUpdate(configList, ConfigType.SearchType, search_type.GetValue());
            InsertOrUpdate(configList, ConfigType.SmsAccountName, txt_account_name.Text);
            InsertOrUpdate(configList, ConfigType.SmsAccountPassword, txt_account_password.Text);
            InsertOrUpdate(configList, ConfigType.SmsSigned, txt_sms_singer.Text);

            e.Result = Newtonsoft.Json.JsonConvert.SerializeObject(new { success = true, msg = "保存成功" });
        }

        private void InsertOrUpdate(List<T_Cm_Config> configList, ConfigType type, string value)
        {
            T_Cm_Config config = configList.FirstOrDefault(p => p.parameter_name == type.ToString());
            if (config != null)
            {
                //更新
                config.parameter_value = value;
                _config.Update(config);
            }
            else
            {
                //插入
                config = new T_Cm_Config();
                config.id = Guid.NewGuid();
                config.parameter_name = type.ToString();
                config.parameter_description = ConvertHelper.GetEnumAttribute(type.ToString(), typeof(ConfigType));
                config.parameter_value = value;
                _config.Insert(config);
            }
        }
    }
}
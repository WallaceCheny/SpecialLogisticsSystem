using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Common
{
    public static class ConfigurationHelper
    {
        public static string GetAppSettingsKeyValue(string keyName)
        {
            return ConfigurationManager.AppSettings.Get(keyName) ?? string.Empty;
        }

        public static string GetConnectionStringsElementValue(string connectionName)
        {
            string result = string.Empty;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connectionName];
            if (null != settings)
            {
                result = settings.ConnectionString;
            }
            return result;
        }

        public static bool IsAppSettingsKeyExist(string keyName)
        {
            foreach (string str in ConfigurationManager.AppSettings.AllKeys)
            {
                if (str == keyName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

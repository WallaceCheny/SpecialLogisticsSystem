using System;
using System.IO;
using System.Reflection;

namespace SpecialLogisticsSystem.Tool
{
    public class LogHelper
    {
        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

        public static void WriteLog(string info)
        {
            if (!loginfo.IsInfoEnabled) return;
            loginfo.Info(info);
        }


        public static void WriteLog(string info, Exception se)
        {
            if (!logerror.IsErrorEnabled) return;
            logerror.Error(info, se);
        }

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
    }
}

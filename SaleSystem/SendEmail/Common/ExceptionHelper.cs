using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Common
{
    public class ExceptionHelper
    {
        private const string appSetting = "ExceptionLog";
        private const string appTraceSetting = "TraceLog";

        public ExceptionHelper()
        {
        }

        public static void WriteLog(string message, string fileName)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                XmlElement xRoot = xmlDoc.DocumentElement;

                XmlElement node = xmlDoc.CreateElement("node");

                XmlElement time = xmlDoc.CreateElement("time");
                time.InnerText = System.DateTime.Now.ToString();
                node.AppendChild(time);
                XmlElement xmlMessage = xmlDoc.CreateElement("message");
                xmlMessage.InnerText = ConvertHelper.ToXml(message);
                node.AppendChild(xmlMessage);
                xRoot.InsertBefore(node, xRoot.FirstChild);
                File.SetAttributes(fileName, FileAttributes.Normal);
                xmlDoc.Save(fileName);
            }
            catch
            {

            }
        }

        public static void WriteLog(Exception exp, string fileName)
        {
            string message = ToString(exp);
            WriteLog(message, fileName);
        }

        public static void WriteTraceLog(string message)
        {
            string logFile = ConvertHelper.ToString(ConfigurationManager.AppSettings[appTraceSetting]);
            try
            {
                WriteLog(message, System.Web.HttpContext.Current.Server.MapPath(logFile));
            }
            catch { }
        }


        public static void WriteLog(string message)
        {
            string logFile = ConvertHelper.ToString(ConfigurationManager.AppSettings[appSetting]);
            try
            {
                WriteLog(message, System.Web.HttpContext.Current.Server.MapPath(logFile));
            }
            catch { }
        }

        public static void WriteLog(Exception exp)
        {
            if (null != exp)
            {
                WriteLog(ToString(exp));
            }
        }

        private static string ToString(Exception exp)
        {
            string result = string.Empty;
            try
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(exp, true);
                int line = st.GetFrame(st.FrameCount - 1).GetFileLineNumber();
                string filename = st.GetFrame(st.FrameCount - 1).GetFileName() == null ? ""
                    : st.GetFrame(st.FrameCount - 1).GetFileName();
                if (exp.InnerException == null)
                {
                    result = string.Format(@"
                                Source:{0},
                                Message:{1},
                                Source File:{2},
                                Line:{3}"
                        , exp.Source, exp.Message, filename, line);
                }
                else
                {
                    string InnerMessage = exp.InnerException.Message;
                    InnerMessage = InnerMessage == null ? "" : InnerMessage;
                    result = string.Format(@"
                                Source:{0},
                                Message:{1},
                                InnerMessage:{2},
                                Source File:{3},
                                Line:{4}"
                        , exp.Source, exp.Message, InnerMessage, filename, line);
                }
            }
            catch { }

            return result;
        }
    }
}
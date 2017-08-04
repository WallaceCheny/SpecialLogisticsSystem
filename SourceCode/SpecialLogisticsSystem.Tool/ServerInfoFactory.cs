using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace SpecialLogisticsSystem.Tool
{
    public class ServerInfoFactory
    {
        public ServerInfo Factory()
        {
            ServerInfo serverInfo = new ServerInfo();
            ServerInfoEnum type = ServerInfoEnum.Web;
            HttpContext context = HttpContext.Current;
            string path = string.Empty;
            if (context == null)
            {
                type = ServerInfoEnum.Winform;
                path = Application.StartupPath;
            }
            else
                path = HttpContext.Current.Server.MapPath("~");
            serverInfo.ServerInfoType = type;
            serverInfo.Path = path;
            return serverInfo;
        }
    }
    public class ServerInfo
    {
        public string Path { get; set; }
        public ServerInfoEnum ServerInfoType { get; set; }
    }
    public enum ServerInfoEnum
    {
        Web,
        Winform
    }
}

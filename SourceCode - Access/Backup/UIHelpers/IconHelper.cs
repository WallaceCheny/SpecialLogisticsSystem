using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;

namespace SpecialLogisticsSystem.AppPortal.UIHelpers
{
    public class IconInfo
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FilePath32 { get; set; }
        public string Content { get; set; }
    }
    public class IconHelper
    {
        public List<IconInfo> GetIcons()
        {
            string path = HttpContext.Current.Server.MapPath("/scripts/themes/icon.css");
            List<IconInfo> files = new List<IconInfo>();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                    string item;
                    while ((item = sr.ReadLine()) != null)
                    {
                        string content = item;
                        item = item.TrimStart('.');
                        string name = item.Substring(0, item.IndexOf('{')).Trim();
                        if (name == "icon" || name.Contains("_32X32")) continue;
                        string t = item.Split('(')[1];
                        string filepath = t.Substring(0, t.IndexOf(')')).Trim();
                        string file32 = "/scripts/themes/icons/32X32/application.png";
                        var icon = filepath.Substring(0, filepath.LastIndexOf('/') + 1) + "32X32" + filepath.Substring(filepath.LastIndexOf('/'));
                        if (File.Exists(HttpContext.Current.Server.MapPath(icon)))
                            file32 = icon;
                        files.Add(new IconInfo { Content = content, Name = name, FilePath = filepath, FilePath32 = file32 });
                    }
                }
            }

            files = files.OrderBy(p => p.Name).ToList();
            return files;
        }
        public string Get32Icon(string name)
        {
            string file = "/scripts/themes/icons/32X32/application.png";
            var item = GetIcons().SingleOrDefault(p => p.Name == name);
            if (item != null)
            {
                var icon = item.FilePath.Substring(0, item.FilePath.LastIndexOf('/') + 1) + "32X32" + item.FilePath.Substring(item.FilePath.LastIndexOf('/'));
                if (File.Exists(HttpContext.Current.Server.MapPath(icon)))
                    file = icon;
            }
            return file;
        }
    }
}
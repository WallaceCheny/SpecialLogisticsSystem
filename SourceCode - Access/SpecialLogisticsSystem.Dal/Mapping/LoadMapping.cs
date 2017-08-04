using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.IO;
using System.Configuration;
using System.Reflection;
using SpecialLogisticsSystem.Tool;

namespace SpecialLogisticsSystem.Dal
{
    public class LoadMapping
    {
        public LoadMapping() { }
        public void SetMappingModel()
        {
            if (CacheHelper.Current.Get("mapping") == null)
            {
                Dictionary<string, MappingModel> cacheData = new Dictionary<string, MappingModel>(StringComparer.OrdinalIgnoreCase);
                Assembly assembly = GetType().Assembly;
                string[] arrFiles = assembly.GetManifestResourceNames();
                List<string> files = new List<string>();
                foreach (string file in arrFiles)
                {
                    if (!file.Contains("Mapping")) continue;
                    files.Add(file);
                    using (StreamReader sr = new StreamReader(assembly.GetManifestResourceStream(file)))
                    {
                        dynamic dx = new DynamicXml(sr.ReadToEnd());
                        MappingModel mm = new MappingModel();
                        //mm.ConnectionName = "ConnectionString";
                        //var config = ConfigurationManager.ConnectionStrings[mm.ConnectionName];
                        //mm.ConnectionString = config.ConnectionString;
                        //mm.ProviderName = config.ProviderName;
                        if (dx.select != null)
                            foreach (dynamic item in dx.select)
                                mm.Select.Add(item.id, item.Value);
                        if (dx.insert != null)
                            foreach (dynamic item in dx.insert)
                                mm.Insert.Add(item.id, item.Value);
                        if (dx.update != null)
                            foreach (dynamic item in dx.update)
                                mm.Update.Add(item.id, item.Value);
                        if (dx.delete != null)
                            foreach (dynamic item in dx.delete)
                                mm.Delete.Add(item.id, item.Value);
                        if (dx.procedure != null)
                            foreach (dynamic item in dx.procedure)
                                mm.Procedure.Add(item.id, item.Value);
                        string key = file.Replace(".xml", string.Empty);
                        cacheData.Add(key.Substring(key.LastIndexOf('.') + 1), mm);
                    }
                }
                CacheHelper.Current.Set("mapping", cacheData);
            }
        }
        public Dictionary<string, MappingModel> GetMappingModel()
        {
            if (CacheHelper.Current.Get("mapping") == null) SetMappingModel();
            return (Dictionary<string, MappingModel>)CacheHelper.Current.Get("mapping");
        }
    }
}

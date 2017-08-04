using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace SpecialLogisticsSystem.Tool
{
    /// <summary>
    /// 缓存类
    /// </summary>
    public class CacheHelper
    {
        private static object syncRoot = new object();
        private static CacheHelper instance;
        public static CacheHelper Current
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CacheHelper();
                            instance.cache = MemoryCache.Default;
                        }
                    }
                }
                return instance;
            }
        }
        private ObjectCache cache;
        public void Set(string key, object value)
        {
            Set(key, value, DateTimeOffset.MaxValue, null);
        }
        public void Set(string key, object value, DateTimeOffset offset)
        {
            Set(key, value, offset, null);
        }
        public void Set(string key, object value, string file)
        {
            Set(key, value, DateTimeOffset.MaxValue, new List<string> { file });
        }
        public void Set(string key, object value, List<string> files)
        {
            Set(key, value, DateTimeOffset.MaxValue, files);
        }
        public void Set(string key, object value, DateTimeOffset? offset, List<string> files)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            if (offset.HasValue)
                policy.AbsoluteExpiration = offset.Value;
            if (files != null)
                policy.ChangeMonitors.Add(new HostFileChangeMonitor(files));
            cache.Set(key, value, policy);
        }
        public object Get(string key)
        {
            return cache.Get(key);
        }
        public T Get<T>(string key)
        {
            object obj = Get(key);
            return obj == null ? default(T) : (T)obj;
        }
        public void Remove(string key)
        {
            cache.Remove(key);
        }
        public void RemoveAll(string key)
        {
            var removeNum = cache.ToList().FindAll((m) => { return m.Key.Contains(key); });
            foreach (var item in removeNum)
                cache.Remove(item.Key);
        }
    }
}

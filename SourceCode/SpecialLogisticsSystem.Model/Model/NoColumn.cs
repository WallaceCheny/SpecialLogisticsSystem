using System;

namespace SpecialLogisticsSystem.Model
{
    public class NoColumn : Attribute
    {
    }
    public class CustomAttribute : Attribute
    {
        public CustomAttribute()
        {
        }
        public CustomAttribute(string description)
        {
            Description = description;
            After = true;
        }
        public string Description { get; set; }
        /// <summary>
        /// 是否记录方法执行前
        /// </summary>
        public bool Begin { get; set; }
        /// <summary>
        /// 是否记录方法执行后
        /// </summary>
        public bool After { get; set; }
    }
}

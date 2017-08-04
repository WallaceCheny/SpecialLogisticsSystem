using System;

namespace SpecialLogisticsSystem.Model
{
    public class PrimaryKey : Attribute
    {
        public bool IsAuto = false;
        public PrimaryKey()
        {
        }
        public PrimaryKey(bool isAuto)
        {
            IsAuto = isAuto;
        }
    }
}

using System;
using System.Linq;
using System.Reflection;

namespace SpecialLogisticsSystem.Model
{
    [Serializable]
    public enum EntityState
    {
        None = 0,
        Added = 1,
        Modified = 2,
        Deleted = 3
    }
    [Serializable]
    public class Entity
    {
        private string _connectionName;
        private string _XmlID;
        private EntityState _state = EntityState.None;
        private Type _t;
        public virtual Type MappingType()
        {
            return _t;
        }
        public virtual string ConnectionName()
        {
            return _connectionName;
        }
        public virtual void SetConnectionName(string connectionName)
        {
            _connectionName = connectionName;
        }
        public virtual string GetXmlID()
        {
            return _XmlID;
        }
        public virtual Entity SetXmlID(string xmlID)
        {
            _XmlID = xmlID;
            return this;
        }
        public virtual EntityState GetState()
        {
            return _state;
        }
        public virtual Entity SetState(EntityState es)
        {
            _state = es;
            return this;
        }
        public Entity()
        {
            if (_t == null)
                _t = this.GetType();
            _XmlID = string.Empty;
        }
        public Entity(string xmlID)
        {
            if (_t == null)
                _t = this.GetType();
            _XmlID = xmlID;
        }
        private bool _isAutoPrimaryKey;
        private PropertyInfo _pkPropertyInfo;
        public virtual PropertyInfo GetPkPropertyInfo()
        {
            if (_pkPropertyInfo == null)
                _pkPropertyInfo = GetPropertyInfo(typeof(PrimaryKey));
            return _pkPropertyInfo;
        }
        public virtual bool GetIsAutoPrimaryKey()
        {
            if (_pkPropertyInfo == null)
                _pkPropertyInfo = GetPropertyInfo(typeof(PrimaryKey));
            _isAutoPrimaryKey = ((PrimaryKey)_pkPropertyInfo.GetCustomAttributes(true).First()).IsAuto;
            return _isAutoPrimaryKey;
        }
        private PropertyInfo GetPropertyInfo(Type type)
        {
            return (from properties in _t.GetProperties()
                    where properties.GetCustomAttributes(type, false).Length >= 1
                    select properties).FirstOrDefault();
        }
    }
}

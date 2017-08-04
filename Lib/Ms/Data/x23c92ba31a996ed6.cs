namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Dynamic;

    internal class x23c92ba31a996ed6 : x820de93bc2090b75, IUpdateBuilderDynamic, IInsertUpdateBuilderDynamic
    {
        internal x23c92ba31a996ed6(IDbProvider dbProvider, IDbCommand command, string name, ExpandoObject item) : base(dbProvider, command, name)
        {
            base.x6b73aa01aa019d3a.Item = item;
        }

        public IUpdateBuilderDynamic AutoMap(params string[] ignoreProperties)
        {
            base.xcd08eddb14ea4239.x102778f7a6dca84c(ignoreProperties);
            return this;
        }

        public IUpdateBuilderDynamic Column(string propertyName, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.xbb4ee78ca371cf6a((ExpandoObject) base.x6b73aa01aa019d3a.Item, propertyName, parameterType, size);
            return this;
        }

        public IUpdateBuilderDynamic Column(string columnName, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(columnName, value, parameterType, size);
            return this;
        }

        IInsertUpdateBuilderDynamic IInsertUpdateBuilderDynamic.Column(string propertyName, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.xbb4ee78ca371cf6a((ExpandoObject) base.x6b73aa01aa019d3a.Item, propertyName, parameterType, size);
            return this;
        }

        IInsertUpdateBuilderDynamic IInsertUpdateBuilderDynamic.Column(string columnName, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x4fe829ca2eecf51e(columnName, value, parameterType, size);
            return this;
        }

        public IUpdateBuilderDynamic Where(string name, DataTypes parameterType, int size)
        {
            object obj2 = x7927126fe5cc7aa8.x5d2ca24278753411(base.x6b73aa01aa019d3a.Item, name);
            this.Where(name, obj2, parameterType, size);
            return this;
        }

        public virtual IUpdateBuilderDynamic Where(string columnName, object value, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.x7f921c9ab27d105d(columnName, value, parameterType, size);
            return this;
        }
    }
}


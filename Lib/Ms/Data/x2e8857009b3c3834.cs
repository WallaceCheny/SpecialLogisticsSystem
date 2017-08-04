namespace Ms.Data
{
    using Ms.Data.Common;
    using System;
    using System.Dynamic;

    internal class x2e8857009b3c3834 : xf3a9e3bf108b45a7, IInsertBuilderDynamic, IInsertUpdateBuilderDynamic
    {
        internal x2e8857009b3c3834(IDbCommand command, string name, ExpandoObject item) : base(command, name)
        {
            base.x6b73aa01aa019d3a.Item = item;
        }

        public IInsertBuilderDynamic AutoMap(params string[] ignoreProperties)
        {
            base.xcd08eddb14ea4239.x102778f7a6dca84c(ignoreProperties);
            return this;
        }

        public IInsertBuilderDynamic Column(string propertyName, DataTypes parameterType, int size)
        {
            base.xcd08eddb14ea4239.xbb4ee78ca371cf6a((ExpandoObject) base.x6b73aa01aa019d3a.Item, propertyName, parameterType, size);
            return this;
        }

        public IInsertBuilderDynamic Column(string columnName, object value, DataTypes parameterType, int size)
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
    }
}


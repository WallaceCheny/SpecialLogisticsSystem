namespace Ms.Data
{
    using System;

    public class EntityFactory : IEntityFactory
    {
        public virtual object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}


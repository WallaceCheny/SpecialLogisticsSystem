namespace Ms.Data
{
    using System;

    public interface IEntityFactory
    {
        object Create(Type type);
    }
}


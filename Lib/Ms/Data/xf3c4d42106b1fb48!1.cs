namespace Ms.Data
{
    using System;

    internal class xf3c4d42106b1fb48<TEntity>
    {
        internal TEntity x900701397bf06c11(DbCommandData x4a3f0a05c02f235f, Func<IDataReader, TEntity> xb4c68d3daf262308)
        {
            TEntity local = default(TEntity);
            if ((1 != 0) && x4a3f0a05c02f235f.Reader.Read())
            {
                return xb4c68d3daf262308(x4a3f0a05c02f235f.Reader);
            }
            return local;
        }
    }
}


namespace Ms.Data.Providers.Common
{
    using System;
    using System.Data;
    using System.Data.Common;

    internal class xff59563c1b935d7a
    {
        public static IDbConnection xac31a164577610bd(string x30faf23779022f6f, string x916ab12f6e6518fc)
        {
            DbConnection connection = DbProviderFactories.GetFactory(x30faf23779022f6f).CreateConnection();
            connection.ConnectionString = x916ab12f6e6518fc;
            return connection;
        }
    }
}


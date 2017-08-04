namespace Ms.Data
{
    using Ms.Data.Providers.Access;
    using Ms.Data.Providers.DB2Provider;
    using Ms.Data.Providers.MySql;
    using Ms.Data.Providers.Oracle;
    using Ms.Data.Providers.PostgreSql;
    using Ms.Data.Providers.Sqlite;
    using Ms.Data.Providers.SqlServer;
    using Ms.Data.Providers.SqlServerCompact;
    using System;

    public class DbProviderFactory
    {
        public virtual IDbProvider GetDbProvider(DbProviderTypes dbProvider)
        {
            IDbProvider provider = null;
            DbProviderTypes types;
        Label_008C:
            types = dbProvider;
            if (0x7fffffff != 0)
            {
                switch (types)
                {
                    case DbProviderTypes.SqlServer:
                    case DbProviderTypes.SqlAzure:
                        return new xb41ee2fa4b36daf9();

                    case DbProviderTypes.SqlServerCompact40:
                        return new x5a504537ae2f4c91();

                    case DbProviderTypes.Oracle:
                        provider = new x82a2d569ac32b6b8();
                        if (0 != 0)
                        {
                            goto Label_008C;
                        }
                        return provider;

                    case DbProviderTypes.MySql:
                        return new xf31b6dba58427e49();

                    case DbProviderTypes.Access:
                        goto Label_001F;

                    case DbProviderTypes.Sqlite:
                        return new x5fc4aec3fec9428d();

                    case DbProviderTypes.PostgreSql:
                        return new xd77ea1a8e5e056c6();

                    case DbProviderTypes.DB2:
                        return new x0c17e5843232952f();
                }
                return provider;
            }
            if (0 != 0)
            {
                IDbProvider provider2;
                return provider2;
            }
        Label_001F:
            provider = new x0048b3d0cfd2b5d3();
            if (0 != 0)
            {
                goto Label_001F;
            }
            return provider;
        }
    }
}


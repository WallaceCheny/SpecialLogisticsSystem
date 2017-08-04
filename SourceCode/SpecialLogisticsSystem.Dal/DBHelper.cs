using System;
using System.Configuration;
using Ms.Data;
using SpecialLogisticsSystem.Tool;


namespace SpecialLogisticsSystem.Dal
{
    public class DbProvider
    {
        public IDbContext IContext { get; set; }
        public DbProviderTypes ProviderTypes { get; set; }
        public IDbProvider IProvider { get; set; }
    }
    public class DBHelperBase<TContext> : DbProvider where TContext : DBHelperBase<TContext>, new()
    {
        private static object syncRoot = new object();
        private static TContext instance;
        private ServerInfo _serverInfo;
        public static TContext Current
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new TContext();
                            instance._serverInfo = new ServerInfoFactory().Factory();
                            instance.CreateSession();
                        }
                    }
                }
                return instance;
            }
        }
        public void CreateSession()
        {
            ConnectionStringSettings conn = ConfigurationManager.ConnectionStrings["ConnectionString"];
            string provider = string.Empty;
            string connectionString = conn.ConnectionString;
            switch (conn.ProviderName)
            {
                case "System.Data.SqlClient":
                    provider = "SqlServer";
                    break;
                case "Oracle.DataAccess.Client":
                case "System.Data.OracleClient":
                    provider = "Oracle";
                    break;
                case "System.Data.OleDb":
                    provider = "Access";
                    connectionString = GetConn(connectionString);
                    break;
                case "MySql.Data.MySqlClient":
                    provider = "MySql";
                    break;
                case "System.Data.SQLite":
                    provider = "Sqlite";
                    connectionString = GetConn(connectionString);
                    break;
                case "System.Data.SqlServerCe.4.0":
                    provider = "SqlServerCompact40";
                    break;
                case "Npgsql":
                    provider = "PostgreSql";
                    break;
                case "IBM.data.DB2":
                    provider = "DB2";
                    break;
                default:
                    provider = conn.ProviderName;
                    break;
            }
            instance.ProviderTypes = (DbProviderTypes)Enum.Parse(typeof(DbProviderTypes), provider);
            instance.IProvider = new DbProviderFactory().GetDbProvider(instance.ProviderTypes);
            instance.IContext = new DbContext().ConnectionString(connectionString, instance.ProviderTypes);
        }
        private string GetConn(string connectionString)
        {
            string oldConn = connectionString.ToLower();
            oldConn = oldConn.Substring(oldConn.IndexOf("data source=") + 12);
            oldConn = oldConn.Substring(0, oldConn.IndexOf(';'));
            string formatConn = oldConn.TrimStart('/').TrimStart('\\').Replace("/", "\\");
            if (!System.IO.Path.IsPathRooted(formatConn))
            {
                string newConn = _serverInfo.Path + formatConn;
                return connectionString.ToLower().Replace(oldConn, newConn);
            }
            return connectionString;
        }
    }
    public class DBHelper : DBHelperBase<DBHelper>
    {
    }
}

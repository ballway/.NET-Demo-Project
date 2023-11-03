using NHibernate;
using NHibernate.Cfg;

namespace BookProject.Persistence.NHibernate.Utility
{
    public class SessionFactoryProvider
    {
        /// <summary>
        /// 依照 nhibernate.cfg.xml 的連線設定產生 SessionFactory。
        /// </summary>
        /// <param name="nHibernateConfigPath">nhibernate.cfg.xml 的路徑。</param>
        public static ISessionFactory GetSessionFactory(DatabaseType databaseType, string connectionString)
        {
            // 讀取 nhibernate.cfg.xml 的設定內容
            Configuration nhibernateConfig = new Configuration();
            nhibernateConfig.Configure(@"Configuration/nhibernate.cfg.xml");
            nhibernateConfig.SetProperty(Environment.ConnectionString, connectionString);

            switch (databaseType)
            {
                case DatabaseType.SQLite:
                    nhibernateConfig.SetProperty(Environment.ConnectionDriver, "NHibernate.Driver.SQLite20Driver");
                    nhibernateConfig.SetProperty(Environment.Dialect, "NHibernate.Dialect.SQLiteDialect");
                    break;

                case DatabaseType.MySQL:
                    nhibernateConfig.SetProperty(Environment.ConnectionDriver, "NHibernate.Driver.MySqlDataDriver");
                    nhibernateConfig.SetProperty(Environment.Dialect, "NHibernate.Dialect.MySQLDialect");
                    nhibernateConfig.SetProperty(Environment.Isolation, "ReadUncommitted");
                    break;

                case DatabaseType.MSSQL:
                    nhibernateConfig.SetProperty(Environment.ConnectionDriver, "NHibernate.Driver.SqlClientDriver");
                    nhibernateConfig.SetProperty(Environment.Dialect, "NHibernate.Dialect.MsSql2012Dialect");
                    nhibernateConfig.SetProperty(Environment.Isolation, "ReadUncommitted");
                    break;

                default:
                    break;
            }

            return nhibernateConfig.BuildSessionFactory();
        }
    }

    public enum DatabaseType
    {
        SQLite = 1,
        MySQL = 2,
        MSSQL = 3
    }
}

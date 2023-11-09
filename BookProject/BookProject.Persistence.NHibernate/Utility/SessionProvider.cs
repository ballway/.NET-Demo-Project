using NHibernate;
using NHibernate.Cfg;

namespace BookProject.Persistence.NHibernate.Utility
{
    public class SessionProvider
    {
        /// <summary>
        /// nhibernate.cfg.xml 設定檔路徑。
        /// </summary>
        public string ConfigurationPath { get; set; }

        /// <summary>
        /// 要連線的資料庫類型。
        /// </summary>
        public DatabaseType DatabaseType { get; set; }

        /// <summary>
        /// 建立 Session 的連線字串。
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 各 NHibernate Dao 共用的 Session。
        /// </summary>
        private ISession Session { get; set; }

        public ISession GetSession()
        {
            if (Session == null)
            {
                ISessionFactory sessionFactory = GetSessionFactory();
                Session = sessionFactory.OpenSession();
            }
            return Session;
        }

        /// <summary>
        /// 依照 nhibernate.cfg.xml 的連線設定產生 SessionFactory。
        /// </summary>
        /// <param name="nHibernateConfigPath">nhibernate.cfg.xml 的路徑。</param>
        private ISessionFactory GetSessionFactory()
        {
            // 讀取 nhibernate.cfg.xml 的設定內容
            Configuration nhibernateConfig = new Configuration();
            nhibernateConfig.Configure(ConfigurationPath);
            nhibernateConfig.SetProperty(Environment.ConnectionString, this.ConnectionString);

            switch (this.DatabaseType)
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

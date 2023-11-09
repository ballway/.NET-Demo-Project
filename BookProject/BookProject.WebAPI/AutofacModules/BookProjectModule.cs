using Autofac;
using BookProject.Contract.Persistence;
using BookProject.Contract.Service;
using BookProject.Persistence.Dummy;
using BookProject.Persistence.NHibernate;
using BookProject.Persistence.NHibernate.Utility;
using BookProject.Service;

namespace BookProject.WebAPI.AutofacModules
{
    public class BookProjectModule : Module
    {
        private readonly DatabaseType _databaseType;
        private readonly string _connectionString;
        private readonly PersistenceType _persistenceType;

        public BookProjectModule(string databaseType, string connectionString, string persistenceType) 
        {
            Enum.TryParse(databaseType, out _databaseType);
            _connectionString = connectionString;
            Enum.TryParse(persistenceType, out _persistenceType);
        }

        protected override void Load(ContainerBuilder builder)
        {
            // 註冊 Dao 層
            RegisterDao(builder);

            // 註冊 Service 層
            RegisterService(builder);
        }

        /// <summary>
        /// 註冊 BookProject.Persistence。
        /// </summary>
        private void RegisterDao(ContainerBuilder builder)
        {
            // 註冊 DummyBookDao
            builder.Register(c => new DummyBookDao()).Keyed<IBookDao>(PersistenceType.Dummy);

            // 註冊 NHibernateBookDao
            builder.Register(c => new NHibernateBookDao()
            {
                SessionProvider = new SessionProvider()
                {
                    ConnectionString = _connectionString,
                    DatabaseType = _databaseType,
                    ConfigurationPath = Path.GetFullPath(@"Configuration\\nhibernate.cfg.xml")
                }
            })
            .Keyed<IBookDao>(PersistenceType.NHibernate);
        }

        /// <summary>
        /// 註冊 BookProject.Service。
        /// </summary>
        private void RegisterService(ContainerBuilder builder)
        {
            // 註冊 BookService
            builder.Register(c => new BookService()
            {
                BookDao = c.ResolveKeyed<IBookDao>(_persistenceType)
            })
            .As<IBookService>();
        }

        /// <summary>
        /// 選用的 Dao 類型。
        /// </summary>
        private enum PersistenceType
        {
            Dummy = 1,
            NHibernate = 2
        }
    }
}

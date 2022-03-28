using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using FinalChatApp.Mappings;

namespace FinalChatApp
{
    class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory _sessionFactory;
        static NHibernateHelper()
        {
            _sessionFactory = FluentConfigure();
        }
        public static NHibernate.ISession GetCurrentSession()
        {
            return _sessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            _sessionFactory.Close();
        }
        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }

        public static ISessionFactory FluentConfigure()
        {

            var PostgreSQLDBConnection = "Server=localhost;Port=5432;Database=ReactChatApp;User Id=postgres;Password=postgres;";

            return Fluently.Configure()

                .Database(
                    PostgreSQLConfiguration.PostgreSQL82
                        .ConnectionString(
                            cs => cs.Is(PostgreSQLDBConnection))
                            .Raw("hbm2ddl.keywords", "none")
                            .ShowSql()
                        )
                //2nd level cache
                .Cache(
                    c => c.UseQueryCache()
                        .UseSecondLevelCache()
                        .ProviderClass<NHibernate.Cache.HashtableCacheProvider>())
                
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ChatMessagesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ChatConversationsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}

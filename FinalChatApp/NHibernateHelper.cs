using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ReactChatApp.Mappings;

namespace ReactChatApp
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
            return Fluently.Configure()

                .Database(
                    PostgreSQLConfiguration.PostgreSQL82
                        .ConnectionString(
                            cs => cs.Is("PostgreSQLDBConnection"))
                            .Raw("hbm2ddl.keywords", "none")
                            .ShowSql()
                        )
                //2nd level cache
                .Cache(
                    c => c.UseQueryCache()
                        .UseSecondLevelCache()
                        .ProviderClass<NHibernate.Cache.HashtableCacheProvider>())
                
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ChatUsersMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ChatMessagesMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ChatConversationsMap>())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}

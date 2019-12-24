using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using AllMark.Config;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Options;
using NHibernate;
using NHibernate.Context;

namespace AllMark.DAL
{
    public class AppSessionFactory
    {
        private readonly DatabaseConfig _databaseConfig;
        private ISessionFactory _sessionFactory;
        private readonly object _lock = new object();

        public AppSessionFactory(IOptions<DatabaseConfig> databaseConfig)
        {
            _databaseConfig = databaseConfig.Value;
        }

        public ISession OpenSession()
        {
            var factory = GetSessionFactory();
            var session = factory.OpenSession();
            session.BeginTransaction();
            return session;

        }

        private ISessionFactory GetSessionFactory()
        {
            lock (_lock)
            {
                if (_sessionFactory == null)
                    CreateSessionFactory();
            }

            return _sessionFactory;
        }

        public void CreateSessionFactory()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var mappingAssembly = assemblies.FirstOrDefault(i => i.FullName.StartsWith("AllMark.Core"));
            var configuration = GetConfiguration(_databaseConfig.MySql);
            _sessionFactory = BuildSessionFactory(configuration, mappingAssembly);
        }

        private ISessionFactory BuildSessionFactory(FluentConfiguration config, Assembly mappingAssembly)
        {
            var cfg = config
                     .Mappings(m => m.FluentMappings.AddFromAssembly(mappingAssembly))
                     .BuildConfiguration();

            return cfg.BuildSessionFactory();
        }

        private static FluentConfiguration GetConfiguration(string connectionKey)
        {
            var cfg = Fluently.Configure()
                              .Database(MySQLConfiguration
                                       .Standard
                                       .ConnectionString(e => e.Is(connectionKey))
                                       .UseReflectionOptimizer()
                                       .Raw(NHibernate.Cfg.Environment.CommandTimeout, TimeSpan.FromMinutes(5)
                                                                                .TotalSeconds.ToString(CultureInfo.InvariantCulture))
                                       .AdoNetBatchSize(100))
                              //.Cache(c => c //TODO Пока без кэша
                              //           .UseQueryCache()
                              //           .UseSecondLevelCache()
                              //           .ProviderClass<CoreMemoryCacheProvider>())
                              .CurrentSessionContext<AsyncLocalSessionContext>();

            //if (_config.ShowSQL || _config.UseProfiler)
            //{
            cfg.Database(MySQLConfiguration
                        .Standard
                        .FormatSql()
                        .ShowSql()
                        .Raw(NHibernate.Cfg.Environment.GenerateStatistics, "true"));
            //}

            return cfg;
        }


    }
}

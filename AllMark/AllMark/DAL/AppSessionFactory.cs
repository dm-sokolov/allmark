using AllMark.Config;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NHibernate;
using NHibernate.Context;
using System;
using System.Globalization;
using System.Reflection;

namespace AllMark.DAL
{
    public class AppSessionFactory
    {
        private readonly DatabaseConfig _databaseConfig;
        private ISessionFactory _sessionFactory;

        public AppSessionFactory(IOptions<DatabaseConfig> databaseConfig)
        {
            _databaseConfig = databaseConfig.Value;
        }

        public void CreateSessionFactory(IServiceCollection services)
        {
            var mappingAssembly = Assembly.Load("AllMakr.Models");
            var configuration = GetConfiguration(_databaseConfig.MySql);
            _sessionFactory = BuildSessionFactory(configuration, mappingAssembly);
        }

        private static ISessionFactory BuildSessionFactory(FluentConfiguration config, Assembly mappingAssembly)
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

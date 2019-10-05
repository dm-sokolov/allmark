using AllMark.Helpers;
using Autofac;
using System;

namespace AllMark.Repository
{
    public static class RepositoryConfig
    {
        public static ContainerBuilder AddRepositories(this ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentException(nameof(builder));

            builder.RegisterGeneric(typeof(Repository<>))
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces();

            return builder;
        }
    }
}

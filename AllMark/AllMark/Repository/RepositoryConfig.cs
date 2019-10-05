using AllMark.Helpers;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllMark.Repository
{
    public static class RepositoryConfig
    {
        public static ContainerBuilder AddRepositories(this ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentException(nameof(builder));

            builder.RegisterGeneric(typeof(Repository<>))
                .InstancePerRequest()
                .AsImplementedInterfaces();

            return builder;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace AllMark.HostedServices
{
    public static class HostedServiceConfig
    {
        public static void AddHostedServices(this IServiceCollection services) => services.AddHostedService<CategoryUpdate>();

    }
}

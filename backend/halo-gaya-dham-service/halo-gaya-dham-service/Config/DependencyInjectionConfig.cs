using Microsoft.Extensions.DependencyInjection;
using Business.Authorization;

namespace halo_gaya_dham_service.Config
{
    public static class DependencyInjectionConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHelper, AuthorizationHelper>();
        }
    }
}
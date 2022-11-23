using Microsoft.Extensions.DependencyInjection;
using Skinet.API.Helpers;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Repositories;

namespace Skinet.API
{
    public static class APIServicesInjection
    {
        public static IServiceCollection AddSkinetServices(this IServiceCollection services)
        {
            return
                services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                        .AddAutoMapper(typeof(MappingProfiles));
                ;
        }
    }
}

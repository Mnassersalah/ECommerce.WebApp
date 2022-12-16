using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Skinet.API.Helpers;
using Skinet.API.Middlewares;
using Skinet.Core.Interfaces;
using Skinet.Infrastructure.Repositories;

namespace Skinet.API.Extensions
{
    public static class APIExtentions
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

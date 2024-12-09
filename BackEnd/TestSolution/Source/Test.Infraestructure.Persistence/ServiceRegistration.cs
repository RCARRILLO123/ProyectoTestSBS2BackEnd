//using Test.Application.Interfaces.Repositories;
//using Test.Application.Interfaces.Service;
using Test.Infraestructure.Persistence.Data;
//using Test.Infraestructure.Persistence.Externo;
using Test.Infraestructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Application.Interfaces.Repositories;

namespace Test.Infraestructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IEntidadGubernamentalRepositoryAsync, EntidadGubernamentalRepositoryAsync>();
            #endregion Repositories
        }
    }
}

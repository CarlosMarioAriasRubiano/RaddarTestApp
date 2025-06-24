using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RaddarTestApp.Domain.Ports;
using RaddarTestApp.Infrastructure.Adapters;
using System.Data;

namespace RaddarTestApp.Infrastructure.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IQueryDapper), typeof(QueryDapper));
            services.AddTransient(typeof(IJwtGenerator), typeof(JwtGenerator));
            services.AddTransient<IDbConnection>(_ => new SqlConnection(configuration.GetConnectionString("DevConnection")));

            return services;
        }
    }
}

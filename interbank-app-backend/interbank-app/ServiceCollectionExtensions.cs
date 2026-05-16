using interbank_data.Auth.Repository;
using interbank_data.Auth.Service;
using interbank_domain.Auth.Repositories;
using interbank_domain.Auth.Services;

namespace interbank_app
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {

            services.AddScoped<IAuthenticationService, AuthenticationServiceDbImpl>();

            services.AddScoped<IAuthenticationRepository, AuthenticationRepositoryImpl>();

            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Repository;

namespace ProjectManagement.BusinessLogic
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProjectSectorCore, ProjectSectorCore>();
            return services;
        }
    }
}
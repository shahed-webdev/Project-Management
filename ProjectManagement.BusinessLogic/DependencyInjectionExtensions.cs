using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Repository;

namespace ProjectManagement.BusinessLogic
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDonorCore, DonorCore>();
            services.AddTransient<IProjectBeneficiaryTypeCore, ProjectBeneficiaryTypeCore>();
            services.AddTransient<IProjectSectorCore, ProjectSectorCore>();
            services.AddTransient<IProjectStatusCore, ProjectStatusCore>();
            return services;
        }
    }
}
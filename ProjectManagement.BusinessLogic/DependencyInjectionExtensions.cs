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
            services.AddTransient<IProjectCore, ProjectCore>();
            services.AddTransient<IProjectBeneficiaryTypeCore, ProjectBeneficiaryTypeCore>();
            services.AddTransient<IProjectSectorCore, ProjectSectorCore>();
            services.AddTransient<IProjectStatusCore, ProjectStatusCore>();
            services.AddTransient<ILocationCore, LocationCore>();
            services.AddTransient<IReportTypeCore, ReportTypeCore>();
            services.AddTransient<ILogFrameCore, LogFrameCore>();
            services.AddTransient<ILogFrame1stStepCore, LogFrame1stStepCore>();
            services.AddTransient<ILogFrame2ndStepOutputCore, LogFrame2ndStepOutputCore>();
            services.AddTransient<ILogFrame3rdStepActivityCore, LogFrame3rdStepActivityCore>();

            return services;
        }
    }
}
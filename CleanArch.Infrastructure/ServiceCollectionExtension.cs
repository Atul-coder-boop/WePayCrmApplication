using CleanArch.Application.Interfaces;
using CleanArch.Application.UseCaseoperations;
using CleanArch.Infrastructure.BussinessOperation;
using CleanArch.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IFreshLeadsRepository, LeadsRepsitory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

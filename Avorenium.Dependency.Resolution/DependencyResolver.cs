using System;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Application.Services;
using Avorenium.Core.Interfaces.Mapper;
using Avorenium.Infrastructure.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Avorenium.Dependency.Resolution
{
    public static class DependencyResolver
    {
        public static void Register(IServiceCollection services)
        {
            InitializeLibraries();

            RegisterApplicationServices(services);
            RegisterDomainServices(services);
            RegisterInfrastructureServices(services);
            RegisterData(services);
        }

        private static void InitializeLibraries()
        {
            MapperService.Initialize();
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IIssuesApplicationService, IssuesApplicationService>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
        }

        private static void RegisterInfrastructureServices(IServiceCollection services)
        {
            services.AddScoped<IMapperService, MapperService>();
        }

        private static void RegisterData(IServiceCollection services)
        {

        }
    }
}

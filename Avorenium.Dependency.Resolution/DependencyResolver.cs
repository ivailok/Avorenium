using System;
using Avorenium.Core.Application.Interfaces;
using Avorenium.Core.Application.Services;
using Avorenium.Core.Interfaces.Mapper;
using Avorenium.Infrastructure.Data;
using Avorenium.Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Avorenium.Core.Domain.Interfaces;
using Avorenium.Core.Domain.Services;
using Avorenium.Core.Interfaces.Data;
using Avorenium.Core.Interfaces.Data.Repositories.Dbo;
using Avorenium.Infrastructure.Data.Repositories.Dbo;

namespace Avorenium.Dependency.Resolution
{
    public static class DependencyResolver
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            InitializeLibraries();

            services.AddDbContext<AvoreniumDbContext>(opts => opts.UseNpgsql(configuration.GetConnectionString(nameof(AvoreniumDbContext))));

            RegisterData(services);
            RegisterDomainServices(services);
            RegisterInfrastructureServices(services);
            RegisterApplicationServices(services);
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
            services.AddScoped<IIssuesDomainService, IssuesDomainService>();
        }

        private static void RegisterInfrastructureServices(IServiceCollection services)
        {
            services.AddScoped<IMapperService, MapperService>();
        }

        private static void RegisterData(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIssuesRepository, IssuesRepository>();
        }
    }
}

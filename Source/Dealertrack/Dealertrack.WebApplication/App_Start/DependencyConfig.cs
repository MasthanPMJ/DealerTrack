using Dealertrack.Domain.Service;
using Dealertrack.Domain.Service.Core;
using Dealertrack.Infrastructure;
using Dealertrack.Infrastructure.Core.DataRepository;
using Dealertrack.Infrastructure.Core.DataRepository.Repository;
using Dealertrack.Infrastructure.Core.Service;
using Dealertrack.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DealerTrack.App_Start
{
    public class DependencyConfig
    {
        public static void RegisterTypes(IServiceCollection services)
        {
            services.AddScoped<IDealerDataContext>(_ => new JsonDataContext(@"Data.json"));
            services.AddScoped<IDealsDataRepository, DealsDataRepositoy>();
            services.AddScoped<IDealsInfrastructureService, DealsInfrastructureService>();
            services.AddScoped<IDealsService,DealsService>();
        }
    }
}

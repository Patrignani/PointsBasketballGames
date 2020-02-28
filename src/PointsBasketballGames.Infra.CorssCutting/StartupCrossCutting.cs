using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointsBasketballGames.Infra.Data.Configuration;

namespace PointsBasketballGames.Infra.CorssCutting
{
    public static class StartupCrossCutting
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var configClient = new StartupData();
            configClient.ServiceData(services, configuration);

            return services;
        }

        public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
        {
            var configClient = new StartupData();
            configClient.InitializeData(app);

            return app;
        }
    }
}

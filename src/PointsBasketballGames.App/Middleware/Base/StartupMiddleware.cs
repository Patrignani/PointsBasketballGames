using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointsBasketballGames.Infra.CorssCutting;

namespace PointsBasketballGames.App.Middleware.Base
{
    public static class StartupMiddleware
    {
        public static IServiceCollection ConfigureApllicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .ConfigureServices(configuration)
                .RegisterServices(configuration)
                .AddCorsServices()
                .AddResponseCompression();

            return services;
        }
        public static IApplicationBuilder ConfigureApllication(this IApplicationBuilder app)
        {
            app.InitializeDatabase()
                .AddCorsApllication()
                .UseResponseCompression();

            return app;
        }
    }
}

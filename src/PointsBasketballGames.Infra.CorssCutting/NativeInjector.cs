using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointsBasketballGames.Domain.Core.DTOs;
using PointsBasketballGames.Domain.Core.Interfaces.Services;
using PointsBasketballGames.Domain.Services;

namespace PointsBasketballGames.Infra.CorssCutting
{
    public static class NativeInjector
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var autoMigration = configuration.GetValue<bool>("Configuration:AutoMigration");

            services.AddSingleton(new JsonConfiguration
            {
                AutoMigration = autoMigration
            });

            services.AddScoped<IScoreServices, ScoreServices>();

            return services;
        }
    }
}

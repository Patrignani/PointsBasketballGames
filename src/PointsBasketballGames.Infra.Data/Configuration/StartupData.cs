using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointsBasketballGames.Domain.Core.DTOs;
using PointsBasketballGames.Domain.Core.Interfaces;
using PointsBasketballGames.Infra.Data.Context;

namespace PointsBasketballGames.Infra.Data.Configuration
{
    public class StartupData
    {
        public  IServiceCollection ServiceData(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<PointsBasketballGameContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("PointsBasketballGame")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public  IApplicationBuilder InitializeData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var jsonConfiguration = scope.ServiceProvider.GetRequiredService<JsonConfiguration>();

                if (jsonConfiguration.AutoMigration)
                {
                    var context = scope.ServiceProvider.GetRequiredService<PointsBasketballGameContext>();
                    context.Database.Migrate();
                }

            }
            return app;
        }
    }
}

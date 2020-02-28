using Microsoft.EntityFrameworkCore;
using PointsBasketballGames.Domain.Core.Models;

namespace PointsBasketballGames.Infra.Data.Context
{
    internal class PointsBasketballGameContext : DbContext
    {
        public PointsBasketballGameContext(DbContextOptions<PointsBasketballGameContext> options)
        : base(options)
        {

        }

        public DbSet<Score> Score { get; set; }
        public DbSet<Record> Record { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}

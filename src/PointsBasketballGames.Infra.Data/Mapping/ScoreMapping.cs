using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointsBasketballGames.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointsBasketballGames.Infra.Data.Mapping
{
    internal partial class ScoreMapping
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.GameDate).IsRequired();
            builder.Property(x => x.Register).IsRequired();
            builder.Property(x => x.ScoreValue).IsRequired();
        }
    }
}

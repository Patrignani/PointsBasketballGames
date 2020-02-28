using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PointsBasketballGames.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PointsBasketballGames.Infra.Data.Mapping
{
    internal partial class RecordMapping
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ScoreId).IsRequired();
            builder.Property(x => x.Register).IsRequired();

            builder.HasOne(x => x.Score);
            builder.HasIndex(x => x.Current);
        }
    }
}

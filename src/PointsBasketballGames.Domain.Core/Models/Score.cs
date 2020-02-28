using System;

namespace PointsBasketballGames.Domain.Core.Models
{
    public class Score : Basic
    {
        public int ScoreValue { get; set; }
        public DateTime GameDate { get; set; }
    }
}

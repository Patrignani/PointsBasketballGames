using PointsBasketballGames.Domain.Core.DTOs.Object;
using System;

namespace PointsBasketballGames.Domain.Core.DTOs
{
    public class ScoreBasic
    {
        public int ScoreValue { get; set; }
        public DateTime? GameDate { get; set; }

        public ValidateModel IsValid()
        {
            var @return = new ValidateModel();
            if (ScoreValue < 0)
            {
                @return.NotValid("Pontuação não pode ser menor do que zero.");
            }
            else if (!GameDate.HasValue || GameDate == new DateTime())
            {
                @return.NotValid("Data inválida.");
            }
            else if (GameDate.Value.Ticks> DateTime.UtcNow.Ticks)
            {
                @return.NotValid("A data informada é maior que a data atual.");
            }

            return @return;
        }

    }

    public class ScoreResult
    {
        private decimal _pointsPerGame { get; set; }
        public DateTime? FirstDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int GamesPlayed { get; set; }
        public int TotalPointsScoredSeason { get; set; }
        public decimal AveragePointsPerGame
        {
            get { return _pointsPerGame; }
            set
            {
                _pointsPerGame = Decimal.Round(value, 2);
            }
        }
        
        public int HighestScoreGame { get; set; }
        public int LowestScoreGame { get; set; }
        public int TotalRecords { get; set; }
    }
}

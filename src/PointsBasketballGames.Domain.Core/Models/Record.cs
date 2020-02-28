namespace PointsBasketballGames.Domain.Core.Models
{
    public class Record : Basic
    {
        public bool Current { get; set; }
        public int ScoreId { get; set; }
        public Score Score { get; set; }
    }
}

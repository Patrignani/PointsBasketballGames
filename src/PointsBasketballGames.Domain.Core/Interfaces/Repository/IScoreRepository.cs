using PointsBasketballGames.Domain.Core.Models;
using System.Threading.Tasks;

namespace PointsBasketballGames.Domain.Core.Interfaces.Repository
{
    public interface IScoreRepository
    {
        Task AddAsync(Score score);
        Task<Score> GetFirstScoreAsync();
        Task<DTOs.ScoreResult> GetResult();
    }
}

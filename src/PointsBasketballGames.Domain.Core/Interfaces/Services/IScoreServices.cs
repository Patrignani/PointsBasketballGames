using PointsBasketballGames.Domain.Core.DTOs.Object;
using System.Threading.Tasks;

namespace PointsBasketballGames.Domain.Core.Interfaces.Services
{
    public interface IScoreServices
    {
        Task<ValidateModel> AddAsync(DTOs.ScoreBasic score);
        Task<ResultModel<DTOs.ScoreResult>> GetResult();
    }
}

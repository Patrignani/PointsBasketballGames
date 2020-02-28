using PointsBasketballGames.Domain.Core.Interfaces.Repository;
using System.Threading.Tasks;

namespace PointsBasketballGames.Domain.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IScoreRepository ScoreRepository { get; }
        IRecordRepository RecordRepository { get; }

        Task<int> CommitAsync();
    }
}

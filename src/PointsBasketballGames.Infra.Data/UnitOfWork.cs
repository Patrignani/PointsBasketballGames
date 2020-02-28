using PointsBasketballGames.Domain.Core.Interfaces;
using PointsBasketballGames.Domain.Core.Interfaces.Repository;
using PointsBasketballGames.Infra.Data.Context;
using PointsBasketballGames.Infra.Data.Repository;
using System.Threading.Tasks;

namespace PointsBasketballGames.Infra.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly PointsBasketballGameContext _context;
        private IScoreRepository _scoreRepository;
        private IRecordRepository _recordRepository;

        public UnitOfWork(PointsBasketballGameContext context)
        {
            _context = context;
        }

        public IScoreRepository ScoreRepository
        {
            get
            {
                if (_scoreRepository == null)
                    _scoreRepository = new ScoreRepository(_context);

                return _scoreRepository;
            }
        }

        public IRecordRepository RecordRepository
        {
            get
            {
                if (_recordRepository == null)
                    _recordRepository = new RecordRepository(_context);

                return _recordRepository;
            }
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

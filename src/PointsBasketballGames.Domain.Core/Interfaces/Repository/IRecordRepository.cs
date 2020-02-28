using PointsBasketballGames.Domain.Core.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointsBasketballGames.Domain.Core.Interfaces.Repository
{
    public interface IRecordRepository
    {
        Task AddAsync(Record record);
        void Update(Record record);
        Task<IEnumerable<Record>> GetAllAsync();
        Task<Record> GetCurrentRecordAsync();

    }
}

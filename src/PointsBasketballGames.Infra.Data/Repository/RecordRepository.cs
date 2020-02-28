using Microsoft.EntityFrameworkCore;
using PointsBasketballGames.Domain.Core.Interfaces.Repository;
using PointsBasketballGames.Domain.Core.Models;
using PointsBasketballGames.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace PointsBasketballGames.Infra.Data.Repository
{
    internal class RecordRepository : IRecordRepository
    {
        private readonly PointsBasketballGameContext _context;
        private readonly string _entitySql;
        public RecordRepository(PointsBasketballGameContext context)
        {
            _context = context;
            _entitySql = @"SELECT r.Id, r.[Current], r.ScoreId, r.Register, 
                                s.Id, s.ScoreValue, s.GameDate, s.Register FROM Record r
                                INNER JOIN Score s on r.ScoreId = s.Id";
        }

        public async Task AddAsync(Record record)
        {
            await _context.AddAsync(record);
        }

        public async Task<Record> GetCurrentRecordAsync()
        {
            var sql = $"{_entitySql} WHERE r.[Current] = 1";

            return (await _context.Database.GetDbConnection()
                .QueryAsync<Record, Score, Record>(sql, (recordQuery, score) =>
                {
                    recordQuery.Score = score;
                    return recordQuery;
                })).FirstOrDefault();
        }

        public async Task<IEnumerable<Record>> GetAllAsync()
        {
            IEnumerable<Record> record;

          
            record = await _context.Database.GetDbConnection()
                .QueryAsync<Record, Score, Record>(_entitySql,
                (recordQuery, score) =>
                {
                    recordQuery.Score = score;
                    return recordQuery;
                });

            return record;
        }
        public void Update(Record record)
        {
            _context.Entry(record).State = EntityState.Modified;
        }
    }
}

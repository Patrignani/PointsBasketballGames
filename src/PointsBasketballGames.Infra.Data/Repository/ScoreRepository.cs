using Dapper;
using Microsoft.EntityFrameworkCore;
using PointsBasketballGames.Domain.Core.DTOs;
using PointsBasketballGames.Domain.Core.Interfaces.Repository;
using PointsBasketballGames.Domain.Core.Models;
using PointsBasketballGames.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace PointsBasketballGames.Infra.Data.Repository
{
    internal class ScoreRepository : IScoreRepository
    {
        private readonly PointsBasketballGameContext _context;
     
        public ScoreRepository(PointsBasketballGameContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Score score)
        {
           await  _context.AddAsync(score);
        }

        public async Task<Score> GetFirstScoreAsync()
        {
            var sql = "SELECT TOP 1 Id, ScoreValue, GameDate, Register FROM Score order by Id";
            return await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<Score>(sql);
        }

        public async Task<ScoreResult> GetResult()
        {
            var sql = @"SELECT 
                            (SELECT TOP 1 GameDate FROM Score order by GameDate) as FirstDate,
                            (SELECT TOP 1 GameDate FROM Score order by GameDate DESC) as EndDate,
                            (SELECT COUNT(Id) FROM Score) as GamesPlayed,
                            (SELECT SUM(ScoreValue) FROM Score) as TotalPointsScoredSeason,
                            (SELECT AVG(Cast(ScoreValue as Float)) FROM Score) AS AveragePointsPerGame,
                            (SELECT TOP 1  ScoreValue FROM Score order by ScoreValue DESC) as HighestScoreGame,
                            (SELECT TOP 1  ScoreValue FROM Score order by ScoreValue) as LowestScoreGame,
                            (SELECT COUNT(Id) FROM Record) as TotalRecords";

            return await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<ScoreResult>(sql);

        }
    }
}

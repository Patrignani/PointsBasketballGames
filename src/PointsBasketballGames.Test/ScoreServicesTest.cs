using Moq;
using PointsBasketballGames.Domain.Core.DTOs;
using PointsBasketballGames.Domain.Core.Interfaces;
using PointsBasketballGames.Domain.Core.Interfaces.Services;
using PointsBasketballGames.Domain.Core.Models;
using PointsBasketballGames.Domain.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PointsBasketballGames.Test
{
    public class ScoreServicesTest
    {
        private Mock<IUnitOfWork> _uow;
        private IScoreServices _score;

        [Fact]
        public async Task AddNotRecordTest()
        {
            CreateMock(GetRecordValue());

            var score = new ScoreBasic
            {
                ScoreValue = 16,
                GameDate = DateTime.UtcNow
            };
            var @return = await _score.AddAsync(score);

            var result = score.IsValid();

            Assert.Equal((result.Success && result.Messages.Count == 0), (@return.Success && @return.Messages.Count == 0));
        }

        [Fact]
        public async Task AddNewRecordTest()
        {
            CreateMock(GetRecordValue());

            var score = new ScoreBasic
            {
                ScoreValue = 32,
                GameDate = DateTime.UtcNow
            };
            var @return = await _score.AddAsync(score);

            var result = score.IsValid();

            Assert.Equal((result.Success && result.Messages.Count == 0), (@return.Success && @return.Messages.Count == 0));
        }

        [Fact]
        public async Task AddNullRecordTest()
        {
            CreateMock();

            var score = new ScoreBasic
            {
                ScoreValue = 32,
                GameDate = DateTime.UtcNow
            };
            var @return = await _score.AddAsync(score);

            var result = score.IsValid();

            Assert.Equal((result.Success && result.Messages.Count == 0), (@return.Success && @return.Messages.Count == 0));
        }

        [Fact]
        public async Task AddFirstRecordTest()
        {
            CreateMock(null, GetScore());

            var score = new ScoreBasic
            {
                ScoreValue = 32,
                GameDate = DateTime.UtcNow
            };
            var @return = await _score.AddAsync(score);

            var result = score.IsValid();

            Assert.Equal((result.Success && result.Messages.Count == 0), (@return.Success && @return.Messages.Count == 0));
        }

        [Fact]
        public async Task AddNotFirstRecordTest()
        {
            CreateMock(null, GetScore());

            var score = new ScoreBasic
            {
                ScoreValue = 1,
                GameDate = DateTime.UtcNow
            };
            var @return = await _score.AddAsync(score);

            var result = score.IsValid();

            Assert.Equal((result.Success && result.Messages.Count == 0), (@return.Success && @return.Messages.Count == 0));
        }

        [Fact]
        public async Task AddTestError()
        {
            CreateMock(GetRecordValue());

            var score = new ScoreBasic
            {
                ScoreValue = -16,
                GameDate = new DateTime()
            };
            var @return = await _score.AddAsync(score);

            var result = score.IsValid();

            Assert.Equal((result.Success && result.Messages.Count == 2), (@return.Success && @return.Messages.Count == 2));
        }

        private void CreateMock(Domain.Core.Models.Record currentRecord = null, Score score = null)
        {
            _uow = new Mock<IUnitOfWork>();
            _uow.Setup(x => x.CommitAsync()).Returns(Task.FromResult(1));
            _uow.Setup(x => x.ScoreRepository.GetResult()).Returns(Task.FromResult(new ScoreResult
            {
                AveragePointsPerGame = 100,
                EndDate = DateTime.UtcNow,
                FirstDate = DateTime.UtcNow.AddDays(-2),
                GamesPlayed = 6,
                HighestScoreGame = 26,
                LowestScoreGame = 8,
                TotalPointsScoredSeason = 200,
                TotalRecords = 3
            }));
            _uow.Setup(x => x.ScoreRepository.AddAsync(new Domain.Core.Models.Score()));
            _uow.Setup(x => x.ScoreRepository.GetFirstScoreAsync()).Returns(Task.FromResult(score));
            _uow.Setup(x => x.RecordRepository.GetCurrentRecordAsync()).Returns(Task.FromResult(currentRecord));

            _score = new ScoreServices(_uow.Object);
        }

        private Domain.Core.Models.Record GetRecordValue()
        {
            return new Domain.Core.Models.Record
            {
                Current = true,
                Id = 2,
                Register = DateTime.UtcNow.AddDays(-4),
                ScoreId = 5,
                Score = new Score
                {
                    Id = 5,
                    GameDate = DateTime.UtcNow.AddDays(-2),
                    Register = DateTime.UtcNow.AddDays(-4),
                    ScoreValue = 30
                }
            };
        }

        private Score GetScore()
        {
            return new Score
            {
                Id = 1,
                GameDate = DateTime.UtcNow.AddDays(-2),
                Register = DateTime.UtcNow.AddDays(-4),
                ScoreValue = 30
            };
        }
    }
}

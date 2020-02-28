using PointsBasketballGames.Domain.Core.DTOs;
using PointsBasketballGames.Domain.Core.DTOs.Object;
using PointsBasketballGames.Domain.Core.Interfaces;
using PointsBasketballGames.Domain.Core.Interfaces.Services;
using PointsBasketballGames.Domain.Core.Models;
using System;
using System.Threading.Tasks;

namespace PointsBasketballGames.Domain.Services
{
    public class ScoreServices : IScoreServices
    {
        private readonly IUnitOfWork _uow;

        public ScoreServices(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ValidateModel> AddAsync(ScoreBasic score)
        {
            var @return = new ValidateModel();
            try
            {
                @return = score.IsValid();

                if (@return.Success)
                {

                    var @new = new Score
                    {
                        Register = DateTime.UtcNow,
                        GameDate = score.GameDate.Value,
                        ScoreValue = score.ScoreValue
                    };

                    await _uow.ScoreRepository.AddAsync(@new);

                    var currentRecord = await _uow.RecordRepository.GetCurrentRecordAsync();

                    if (currentRecord != null)
                    {
                        if (currentRecord.Score.ScoreValue < @new.ScoreValue)
                        {
                            currentRecord.Current = false;
                            _uow.RecordRepository.Update(currentRecord);
                            await RegisterRecordAsync(@new);
                        }
                    }
                    else
                    {
                        var firstRegister = await _uow.ScoreRepository.GetFirstScoreAsync();
                        if (firstRegister != null && firstRegister.ScoreValue < @new.ScoreValue)
                        {
                            await RegisterRecordAsync(@new);
                        }
                    }

                    await _uow.CommitAsync();
                }
            }
            catch (Exception e)
            {
                @return.NotValid(e.GetBaseException().Message);
            }

            return @return;
        }

        public async Task<ResultModel<ScoreResult>> GetResult()
        {
            var @return = new ResultModel<ScoreResult>();
            try
            {
                @return.SetData(await _uow.ScoreRepository.GetResult());
            }
            catch (Exception e)
            {
                @return.NotValid(e.GetBaseException().Message);
            }

            return @return;
        }

        private async Task RegisterRecordAsync(Score score)
        {
            await _uow.RecordRepository.AddAsync(new Record
            {
                Current = true,
                Register = DateTime.UtcNow,
                Score = score
            });
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RightOnBoard.JwtAuthTokenServer.Service.Interfaces;
using RightOnBoard.Survey.Data.DbContext;
using RightOnBoard.Survey.Services.Entities;
using RightOnBoard.Survey.Services.Interfaces;

namespace RightOnBoard.Survey.Services
{
    public class IterationRepository : IIterationRepository
    {
        private ApplicationDbContext _dbContext;
        private IUserService _userService;

        public IterationRepository(ApplicationDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<bool> CreateIteration(List<SurveyIteration> iterationInfo)
        {
            try
            {
                List<Data.Models.SurveyIteration> iterationModel = (from iteration in iterationInfo
                                      select new Data.Models.SurveyIteration
                                      {
                                          Id = iteration.Id,
                                          SurveyId = iteration.SurveyId,
                                          IterationName = iteration.IterationName,
                                          OpenDateTime = iteration.OpenDateTime,
                                          CloseDateTime = iteration.CloseDateTime,
                                          ReminderDateTime = iteration.ReminderDateTime,
                                          ReminderFrequency = iteration.ReminderFrequency
                                      }).ToList();

                await _dbContext.SurveyIteration.AddRangeAsync(iterationModel);

                //if (result)
                //{
                    await _dbContext.SaveChangesAsync();

                    //return result;
                //}

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

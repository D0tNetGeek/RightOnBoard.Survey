using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RightOnBoard.JwtAuthTokenServer.Service.Interfaces;
using RightOnBoard.Survey.Data.DbContext;
using RightOnBoard.Survey.Services.Entities;
using RightOnBoard.Survey.Services.Interfaces;

namespace RightOnBoard.Survey.Services
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        private ApplicationDbContext _dbContext;
        private IUserService _userService;

        public HealthCheckRepository(ApplicationDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public IEnumerable<SurveyIteration> GetHealthChecks()
        {
            var userId = _userService.GetCurrentUserId();

            if(userId == null)
            {
                return null;
            }

            var companyId = _dbContext.Customers.FirstOrDefault(x => x.UserId == userId).CompanyId;

            var healthChecks = _dbContext.SurveyIteration.FromSql("SurveyIterations_GetList_ByUser @p0, @p1", companyId, userId);

            return healthChecks.Select(x=> new SurveyIteration
            {
                Id = x.Id,
                SurveyInfo = new SurveyInfo
                {
                    SurveyId = x.SurveyId
                },
                IterationName = x.IterationName,
                OpenDateTime = x.OpenDateTime,
                CloseDateTime = x.CloseDateTime,
                SurveyStatus = x.SurveyStatus
            });
        }
    }
}

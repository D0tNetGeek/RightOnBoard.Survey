using System.Collections.Generic;
using System.Linq;
using RightOnBoard.JwtAuthTokenServer.Service.Interfaces;
using RightOnBoard.Survey.Data.DbContext;
using RightOnBoard.Survey.Services.Entities;
using RightOnBoard.Survey.Services.Interfaces;

namespace RightOnBoard.Survey.Services
{
    public class SurveyRepository : ISurveyRepository
    {
        private ApplicationDbContext _dbContext;
        private IUserService _userService;

        public SurveyRepository(ApplicationDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public IEnumerable<SurveyInfo> GetAdminSurveyList()
        {
            var userId = _userService.GetCurrentUserId();

            var companyId = _dbContext.Customers.FirstOrDefault(x => x.UserId == userId).CompanyId;
            
                //var surveyList = _dbContext.SurveyInfo.FromSql("Survey_GetList_ByCompany @p0, @p1", "0A7CCADC-F6AA-49F6-87A0-476F43C74756", "74f4db91-8998-4e56-80e2-f91619630269");

            var surveyList = (from si in _dbContext.SurveyInfo
                              join sc in _dbContext.SurveyCompany on si.Id equals sc.SurveyId
                              join c in _dbContext.Customers on sc.CompanyId equals c.CompanyId
                              where sc.CompanyId == companyId && c.UserId == userId     //  "0A7CCADC-F6AA-49F6-87A0-476F43C74756"      "74f4db91-8998-4e56-80e2-f91619630269"
                              select new SurveyInfo
                              {
                                  SurveyId = si.Id,
                                  Name = si.Name,
                                  Description = si.Description,
                                  WelcomeMessage = si.WelcomeMessage,
                                  ExitMessage = si.ExitMessage,
                                  StartDate = si.StartDate,
                                  EndDate = si.EndDate,
                                  ExpirationDate = si.ExpirationDate,
                                  PublicationDate = si.PublicationDate
                              });

            return surveyList;
        }
    }
}

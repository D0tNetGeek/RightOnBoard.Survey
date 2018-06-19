using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RightOnBoard.JwtAuthTokenServer.Service.Interfaces;
using RightOnBoard.Survey.Data.DbContext;
using RightOnBoard.Survey.Data.Models;
using RightOnBoard.Survey.Services.Entities;
using RightOnBoard.Survey.Services.Interfaces;

namespace RightOnBoard.Survey.Services
{
    public class QuestionGroupRepository : IQuestionGroupRepository
    {
        private ApplicationDbContext _dbContext;
        private IUserService _userService;

        public QuestionGroupRepository(ApplicationDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<bool> CreateQuestionGroups(List<QuestionGroup> questionGroups)
        {
            try
            {
                var insertQuestionGroup = (from questionGroup in questionGroups
                                           select new QuestionGroups
                                           {
                                               Id = questionGroup.QuestionGroupId,
                                               QuestionGroupName = questionGroup.QuestionGroupName,
                                               QuestionGroupDescription = questionGroup.QuestionGroupDescription,
                                               SurveyId = questionGroup.SurveyId
                                           }).ToList();

                if (_dbContext.QuestionGroup.AddRangeAsync(insertQuestionGroup).IsCompletedSuccessfully)
                {
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;


            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<QuestionGroup> GetQuestionGroupsForSurvey(string surveyId)
        {
            var questionGroups = _dbContext.QuestionGroup.Where(x => x.SurveyId == surveyId).ToList();

            var result = (from questionGroup in questionGroups
                          select new  QuestionGroup
                          {
                              QuestionGroupId = questionGroup.Id,
                              QuestionGroupName = questionGroup.QuestionGroupName,
                              QuestionGroupDescription = questionGroup.QuestionGroupDescription,
                              SurveyId = questionGroup.SurveyId
                          }).ToList();

            return result;
        }
    }
}

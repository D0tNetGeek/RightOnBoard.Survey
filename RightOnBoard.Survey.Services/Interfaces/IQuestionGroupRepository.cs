using RightOnBoard.Survey.Services.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RightOnBoard.Survey.Services.Interfaces
{
    public interface IQuestionGroupRepository
    {
        Task<bool> CreateQuestionGroups(List<QuestionGroup> questionGroups);
        List<QuestionGroup> GetQuestionGroupsForSurvey(string surveyId);
    }
}

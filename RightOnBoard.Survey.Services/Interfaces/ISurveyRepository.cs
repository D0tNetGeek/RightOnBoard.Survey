using RightOnBoard.Survey.Services.Entities;
using RightOnBoard.Survey.Services.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RightOnBoard.Survey.Services.Interfaces
{
    public interface ISurveyRepository
    {
        IEnumerable<SurveyViewModel> GetAdminSurveyList();
        Task<SurveyInfo> CreateSurvey(SurveyInfo survey);
    }
}

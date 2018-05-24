using RightOnBoard.Survey.Services.Entities;
using System.Collections.Generic;

namespace RightOnBoard.Survey.Services.Interfaces
{
    public interface ISurveyRepository
    {
        IEnumerable<SurveyInfo> GetAdminSurveyList();
    }
}

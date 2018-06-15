using System.Collections.Generic;
using RightOnBoard.Survey.Api.Models;

namespace RightOnBoard.Survey.Api.ViewModels
{
    public class QuestionnaireViewModel
    {
        public SurveyViewModel SurveyInfo { get; set; }
        public List<QuestionGroup> QuestionGroups { get; set; }
    }
}
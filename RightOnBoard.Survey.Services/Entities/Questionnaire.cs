using System.Collections.Generic;

namespace RightOnBoard.Survey.Services.Entities
{
    public class Questionnaire
    {
        public SurveyInfo SurveyInfo { get; set; }

        public List<QuestionGroup> QuestionGroups { get; set; }
    }
}

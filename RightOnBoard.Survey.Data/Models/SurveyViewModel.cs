using System;

namespace RightOnBoard.Survey.Data.Models
{
    public class SurveyViewModel
    {
        public string SurveyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WelcomeMessage { get; set; }
        public string ExitMessage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? PublicationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string CompanyName { get; set; }
    }
}

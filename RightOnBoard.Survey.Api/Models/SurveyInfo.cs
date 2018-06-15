using System;
using System.Collections.Generic;

namespace RightOnBoard.Survey.Api.Models
{
    public class SurveyInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string WelcomeMessage { get; set; }
        public string ExitMessage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? PublicationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string CompanyId { get; set; }
    }
}
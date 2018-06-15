using RightOnBoard.Survey.Api.Models;
using System;

namespace RightOnBoard.Survey.Api.ViewModels
{
    public class HealthCheckViewModel
    {
        public string IterationId { get; set; }
        public string IterationName { get; set; }
        public SurveyViewModel SurveyInfo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string SurveyStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RightOnBoard.Survey.Services.Entities
{
    public class SurveyIteration
    {
        public string Id { get; set; }
        public string IterationName { get; set; }
        public SurveyInfo SurveyInfo { get; set; }
        public DateTime OpenDateTime { get; set; }
        public DateTime CloseDateTime { get; set; }
        public DateTime? ReminderDateTime { get; set; }
        public int ReminderFrequency { get; set; }
        public string SurveyStatus { get; set; }
    }
}

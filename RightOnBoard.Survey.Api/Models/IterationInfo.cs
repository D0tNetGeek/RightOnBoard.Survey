﻿using System;

namespace RightOnBoard.Survey.Api.Models
{
    public class IterationInfo
    {
        public string Id { get; set; }
        public string IterationName { get; set; }
        public string SurveyId { get; set; }
        public DateTime OpenDateTime { get; set; }
        public DateTime CloseDateTime { get; set; }
        public DateTime ReminderDateTime { get; set; }
        public int ReminderFrequency { get; set; }
        public string SurveyStatus { get; set; }
    }
}
﻿using System.Collections.Generic;

namespace RightOnBoard.Survey.Services.Entities
{
    public class QuestionGroup
    {
        public string QuestionGroupId { get; set; }
        public string QuestionGroupName { get; set; }
        public string QuestionGroupDescription { get; set; }
        public List<Driver> Drivers { get; set; }
        public string SurveyId { get; set; }
    }
}

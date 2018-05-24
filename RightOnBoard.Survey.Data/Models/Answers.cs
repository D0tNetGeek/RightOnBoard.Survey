using System;
using System.Collections.Generic;

namespace RightOnBoard.Survey.Data.Models
{
    public partial class Answers
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string QuestionOptionId { get; set; }
        public int? AnswerNumeric { get; set; }
        public string AnswerText { get; set; }
        public bool? AnswerYn { get; set; }
        public string UnitOfMeasureId { get; set; }

        public QuestionOptions QuestionOption { get; set; }        
        //public AspNetUsers User { get; set; }
    }
}

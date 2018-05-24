using System;
using System.Collections.Generic;

namespace RightOnBoard.Survey.Data.Models
{
    public partial class QuestionTypes
    {
        public string Id { get; set; }
        public string QuestionTypeName { get; set; }
        public bool? QuestionTypeHasChoices { get; set; }
    }
}

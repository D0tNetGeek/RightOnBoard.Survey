using System;
using System.Collections.Generic;

namespace RightOnBoard.Survey.Data.Models
{
    public partial class QuestionOptions
    {
        public QuestionOptions()
        {
            Answers = new HashSet<Answers>();
        }

        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string OptionChoiceId { get; set; }

        public ICollection<Answers> Answers { get; set; }
    }
}

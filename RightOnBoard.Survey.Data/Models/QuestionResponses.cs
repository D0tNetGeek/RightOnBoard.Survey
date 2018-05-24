using System;

namespace RightOnBoard.Survey.Data.Models
{
    public class QuestionResponses
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string SurveyIterationId { get; set; }
        public string UserId { get; set; }
        public string TextResponse { get; set; }
        public bool BoolResponse { get; set; }
        public int NumericResponse { get; set; }
        public DateTime ResponseDateTime { get; set; }
        public int ClusterId { get; set; }
    }
}

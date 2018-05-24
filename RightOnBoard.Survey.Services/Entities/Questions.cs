namespace RightOnBoard.Survey.Services.Entities
{
    public class Questions
    {
        public string Id { get; set; }
        public string QuestionName { get; set; }
        public string QuestionText { get; set; }
        public bool? QuestionAnswerRequired { get; set; }
        public string QuestionNumber { get; set; }
        public int? QuestionSequence { get; set; }
        public string QuestionTypeId { get; set; }
        public string QuestionTypeName { get; set; }
    }
}

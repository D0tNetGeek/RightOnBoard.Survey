using System.Collections.Generic;

namespace RightOnBoard.Survey.Services.Entities
{
    public class DriverQuestionGroup1
    {
        public string Id { get; set; }
        public string DriverId { get; set; }
        public string QuestionGroupId { get; set; }
        public string QuestionId { get; set; }
    }

    public class DriverQuestionGroup
    {
        public string QuestionGroupId { get; set; }
        public string QuestionGroupName { get; set; }
        public string QuestionGroupDescription { get; set; }
        public List<Driver> Drivers { get; set; }
    }
}

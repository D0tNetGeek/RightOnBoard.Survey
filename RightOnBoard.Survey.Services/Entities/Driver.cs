using System.Collections.Generic;

namespace RightOnBoard.Survey.Services.Entities
{
    public class Driver
    {
        public string Id { get; set; }
        public string DriverName { get; set; }
        public List<Questions> Questions { get; set; }
    }
}

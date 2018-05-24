using System.Collections.Generic;

namespace RightOnBoard.Survey.Api.Models
{
    public class Department
    {
        public string DeptId { get; set; }
        public string DeptName { get; set; }
        public List<DeptValue> DeptValues { get; set; }
    }

    public class DeptValue
    {
        public string DeptValueId { get; set; }
        public string DeptDispValue { get; set; }
    }
}

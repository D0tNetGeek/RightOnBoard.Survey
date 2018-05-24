using System.ComponentModel.DataAnnotations;

namespace RightOnBoard.Survey.Data.Models
{
    public class Customers
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public string Gender { get; set; }
        public string Locale { get; set; }
        public string Location { get; set; }
    }
}

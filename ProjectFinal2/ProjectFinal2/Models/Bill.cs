using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFinal2.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("realestate")]
        public int realestateId { get; set; }
        public realestate realestate { get; set; }


    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFinal2.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string FeedbackBody { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("realestate")]
        public int realestateId { get; set; }
        public realestate realestate { get; set; }
    }
}

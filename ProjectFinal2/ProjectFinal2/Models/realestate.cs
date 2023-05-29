using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFinal2.Models
    
{
    [Flags]
    public enum HomeType{
        Villa,
        Apartment
    }
    public class realestate
    {
        public int Id { get; set; }
        public HomeType Type { get; set; }
        public int RoomsNumber { get; set; }
        public int FloorNumber { get; set; }
        public double  Price { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Address { get; set; }

        public bool Status { get; set; }
        [ForeignKey("owner")]
        public int ownerId { get; set; }
        public owner owner { get; set; }
        public virtual List<Feedback>? Feedbacks { get; set; }
        public virtual List<Bill>? Bills { get; set; }
        public virtual List<Images> Images { get; set; }
       


    }
}

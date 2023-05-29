using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFinal2.Models
{
    public class Images
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [ForeignKey("realestate")]
        public int realestateId { get; set; }
        public realestate? realestate { get; set; }
        
    }
}

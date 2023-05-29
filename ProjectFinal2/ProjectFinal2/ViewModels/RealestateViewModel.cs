using ProjectFinal2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFinal2.ViewModels
{
    public class RealestateViewModel
    {
        public int id { get; set; }
        public HomeType Type { get; set; }
        public int RoomsNumber { get; set; }
        public int FloorNumber { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Address { get; set; }
       
        [NotMapped]
        public List<IFormFile> photes { get; set; }=new List<IFormFile>();
    }
}

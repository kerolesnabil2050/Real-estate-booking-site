using System.ComponentModel.DataAnnotations;

namespace ProjectFinal2.ViewModels
{
    public class Login
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

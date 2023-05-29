using System.ComponentModel.DataAnnotations;

namespace ProjectFinal2.ViewModels
{
    [Flags]
    public enum Role
    {
        Owner=1,
        user=2
    }
    public class UserRegistration
    {
        [Key]
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare ("Password")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
        public Role  role { get; set; }
    }
}

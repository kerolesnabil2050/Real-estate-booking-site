namespace ProjectFinal2.Models
{
    public class owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Balance { get; set; }
        public bool State { get; set; }
        public virtual List<realestate> realestate { get; set; }

    }
}

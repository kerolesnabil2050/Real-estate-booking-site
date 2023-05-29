using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProjectFinal2.ViewModels;

namespace ProjectFinal2.Models
{
    public class Context : DbContext
    {
        public Context() : base()
        {

        }
        //using during injection
        public Context(DbContextOptions option) : base(option)
        {

        }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<realestate> realestate { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<owner> Owner { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NNJMDGE\\SQL19;Initial Catalog=FinalVersion;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }


      
    }
}



using System.Collections.Generic;
using System.Data.Entity;

namespace SQLPhoneBook
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }
    }

    public class Phone
    {
        public int PhoneId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }

    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() : base("name=PhoneBookDBConnectionString")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}

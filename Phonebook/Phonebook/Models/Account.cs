using System.Collections.Generic;

namespace Phonebook.Models
{
    public class Account
    {
        public Account()
        {
        }

        public Account(string userName)
        {
            UserName = userName;
        }
        public Account(string userName, int id)
        {
            UserName = userName;
            Id = id;
        }

        public string UserName { get; protected set; }
        public int Id { get; protected set; }
        public IList<Phone> Phones { get; set; } 
    }
}
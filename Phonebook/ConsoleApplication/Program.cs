using System;
using System.Collections.Generic;
using SQLPhoneBook;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new PhoneBookContext())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");

                var phone = new Phone();
                var user = new User();
                phone.Number = "yui";
                user.Name = "tyui";
                user.Phones = new List<Phone> {phone};
                phone.Users = new List<User> {user};
                db.Users.Add(user);
                db.SaveChanges();


            }
        }
    }
}

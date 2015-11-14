namespace Phonebook.Models
{
    public class Account
    {
        public Account(int id, int userName)
        {
            Id = id;
            UserName = userName;
        }

        public int Id { get; protected set; }

        public int UserName { get; protected set; }
    }
}
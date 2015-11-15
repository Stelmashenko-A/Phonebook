namespace Phonebook.Models
{
    public class Account
    {
        public Account(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; protected set; }
    }
}
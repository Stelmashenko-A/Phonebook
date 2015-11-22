using System.Collections.Generic;
using Phonebook.Models;

namespace Phonebook.Raven
{
    class Document
    {
        public Document( Account account, List<Phone> phones)
        {
            Account = account;
            Phones = phones;
        }

        public string Id { get; set; }

        public Account Account { get; set; }

        public List<Phone> Phones { get; set; }

        public override bool Equals(object obj)
        {
            var tmp = obj as Document;
            return tmp != null && Equals(tmp);
        }

        protected bool Equals(Document other)
        {
            return Equals(Account.Id, other.Account.Id);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Account.Id.GetHashCode();
            }
        }
    }
}

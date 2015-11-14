using System.Collections.Generic;

namespace Phonebook.Models
{
    public class PhoneStorage
    {
        public PhoneStorage()
        {
            Data = new Dictionary<Account, IList<Account>>();
        }

        public IDictionary<Account, IList<Account>> Data { get; protected set; }
    }
}
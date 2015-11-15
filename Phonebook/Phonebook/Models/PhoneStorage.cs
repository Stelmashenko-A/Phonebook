using System.Collections.Generic;

namespace Phonebook.Models
{
    public class PhoneStorage
    {
        public PhoneStorage()
        {
            Data = new Dictionary<int, KeyValuePair<Account, IList<Phone>>>();
        }

        public Dictionary<int, KeyValuePair<Account, IList<Phone>>> Data { get; protected set; }

        public int MaxId = 1;
    }
}
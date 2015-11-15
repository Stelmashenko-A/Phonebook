using System.Collections.Generic;

namespace Phonebook
{
    public interface IRepository
    {
        IEnumerable<Phone> GetPhone(int id);
        IEnumerable<Phone> GetPhone(string userName);

        IEnumerable<string> GetAllUserNames();
        IEnumerable<KeyValuePair<string, IList<Phone>>> GetAllPhones();

        void AddUser(string userName, IList<Phone> phones);
        void AddUser(string userName);

        void AddPhone(int id, Phone phone);
        void AddPhone(int id, IList<Phone> phones);
        void AddPhone(string userName, Phone phone);
        void AddPhone(string userName, IList<Phone> phones);


        void RemoveUser(int id);
        void RemoveUser(string userName);

        void RemovePhone(int id, Phone phone);
        void RemovePhone(string userName, Phone phone);

        int GetId(string userName);
    }
}

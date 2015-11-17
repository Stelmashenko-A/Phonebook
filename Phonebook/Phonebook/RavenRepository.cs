using System.Collections.Generic;
using System.Linq;
using Phonebook.Models;
using Raven.Client;
using Raven.Client.Document;

namespace Phonebook
{
    public class RavenRepository : IRepository
    {
        protected readonly IDocumentStore Store;

        public RavenRepository(string name)
        {
            Store = new DocumentStore
            {
                Url = "http://localhost:8081/",
                DefaultDatabase = name
            };
            Store.Initialize();
        }

        protected int ReservNextId()
        {
            using (var session = Store.OpenSession())
            {
                var maxId = session.Query<MaxId>().First().Value;
                maxId++;
                session.Query<MaxId>().First().Value = maxId;
                session.SaveChanges();
                return maxId;
            }
        }

        public IEnumerable<Phone> GetPhone(int id)
        {
            using (var session = Store.OpenSession())
            {
                try
                {
                    return
                        session.Query<Document>().First(x => x.Account.Id == id).Phones;
                }
                catch (KeyNotFoundException)
                {
                    return null;
                }
            }
        }

        public IEnumerable<Phone> GetPhone(string userName)
        {
            using (var session = Store.OpenSession())
            {
                return
                    session.Query<Document>().First(x => x.Account.UserName == userName).Phones;
            }
        }

        public IEnumerable<string> GetAllUserNames()
        {
            using (var session = Store.OpenSession())
            {

                return session.Query<Document>().Select(x => x.Account.UserName);
            }
        }

        public IEnumerable<KeyValuePair<string, IList<Phone>>> GetAllPhones()
        {//todo fix
            using (var session = Store.OpenSession())
            {
                var phoneStorage = session.Query<PhoneStorage>().First().Data;
                return
                    phoneStorage.Values.Select(
                        variable => new KeyValuePair<string, IList<Phone>>(variable.Key.UserName, variable.Value))
                        .ToList();
            }
        }

        public void AddUser(string userName, IList<Phone> phones)
        {
            using (var session = Store.OpenSession())
            {
                var id = ReservNextId();
                var doc = new Document(new Account(userName, id), phones.ToList());
                session.Store(doc);
                var s = doc.Id;
                session.SaveChanges();
            }
        }

        public void AddUser(string userName)
        {
            AddUser(userName,new List<Phone>());
        }

        public void AddPhone(int id, Phone phone)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<Document>().First(x=>x.Account.Id==id).Phones.Add(phone);
                session.SaveChanges();
            }
        }

        public void AddPhone(int id, IList<Phone> phones)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<Document>().First(x => x.Account.Id == id).Phones.AddRange(phones);
                session.SaveChanges();
            }
        }

        public void AddPhone(string userName, Phone phone)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<Document>().First(x => x.Account.UserName==userName).Phones.Add(phone);
                session.SaveChanges();
            }
        }

        public void AddPhone(string userName, IList<Phone> phones)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<Document>().First(x => x.Account.UserName == userName).Phones.AddRange(phones);
                session.SaveChanges();
            }
        }

        public void RemoveUser(int id)
        {
            using (var session = Store.OpenSession())
            {
                session.Delete(session.Query<Document>().First(x => x.Account.Id == id).Id);
                session.SaveChanges();
            }
        }

        public void RemoveUser(string userName)
        {
            using (var session = Store.OpenSession())
            {
                session.Delete(session.Advanced.GetDocumentId(session.Query<Document>().First(x => x.Account.UserName == userName)));
                session.SaveChanges();
            }
        }

        public void RemovePhone(int id, Phone phone)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<Document>().First(x => x.Account.Id == id).Phones.Remove(phone);
                session.SaveChanges();
            }
        }

        public void RemovePhone(string userName, Phone phone)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<Document>()
                    .First(x => x.Account.UserName == userName)
                    .Phones.Remove(phone);
                session.SaveChanges();
            }
        }

        public int GetId(string userName)
        {
            using (var session = Store.OpenSession())
            {
                return session.Query<Document>()
                    .First(x => x.Account.UserName == userName).Account.Id;
            }
        }
    }
}
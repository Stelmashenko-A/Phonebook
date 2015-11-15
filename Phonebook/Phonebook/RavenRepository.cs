using System;
using System.Collections.Generic;
using System.Linq;
using Phonebook.Models;
using Raven.Abstractions.Extensions;
using Raven.Client;
using Raven.Client.Document;

namespace Phonebook
{
    public class RavenRepository : IRepository
    {
        protected readonly IDocumentStore Store;

        public RavenRepository()
        {
            Store = new DocumentStore
            {
                Url = "http://localhost:8081/",
                DefaultDatabase = "Phonebook"
            };
            Store.Initialize();

        }

        protected int ReservNextId()
        {
            using (var session = Store.OpenSession())
            {
                var maxId = session.Query<PhoneStorage>().First().MaxId;
                maxId++;
                session.Query<PhoneStorage>().First().MaxId = maxId;
                session.SaveChanges();
                return maxId;
            }
        }

        public IEnumerable<Phone> GetPhone(int id)
        {
            using (var session = Store.OpenSession())
            {
                return
                    session.Query<PhoneStorage>().First().Data[id].Value;
            }
        }

        public IEnumerable<Phone> GetPhone(string userName)
        {
            using (var session = Store.OpenSession())
            {
                return
                    session.Query<PhoneStorage>()
                        .First()
                        .Data[GetId(userName)].Value;
            }
        }

        public IEnumerable<string> GetAllUserNames()
        {
            using (var session = Store.OpenSession())
            {
                return session.Query<PhoneStorage>().First().Data.Values.Select(x => x.Key.UserName);
            }
        }

        public IEnumerable<KeyValuePair<string, IList<Phone>>> GetAllPhones()
        {
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
                session.Query<PhoneStorage>()
                    .First()
                    .Data.Add(ReservNextId(), new KeyValuePair<Account, IList<Phone>>(new Account(userName), phones));
                session.SaveChanges();
            }
        }

        public void AddUser(string userName)
        {
            using (var session = Store.OpenSession())
            {
                var id = ReservNextId();
                session.Query<PhoneStorage>()
                    .First()
                    .Data.Add(id, new KeyValuePair<Account, IList<Phone>>(new Account(userName), new List<Phone>()));
                session.SaveChanges();
            }
        }

        public void AddPhone(int id, Phone phone)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<PhoneStorage>().First().Data[id].Value.Add(phone);
                session.SaveChanges();
            }
        }

        public void AddPhone(int id, IList<Phone> phones)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<PhoneStorage>().First().Data[id].Value.AddRange(phones);
                session.SaveChanges();
            }
        }

        public void AddPhone(string userName, Phone phone)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<PhoneStorage>().First().Data[GetId(userName)].Value.Add(phone);
                session.SaveChanges();
            }
        }

        public void AddPhone(string userName, IList<Phone> phones)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<PhoneStorage>().First().Data[GetId(userName)].Value.AddRange(phones);
                session.SaveChanges();
            }
        }

        public void RemoveUser(int id)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<PhoneStorage>()
                    .First()
                    .Data.Remove(id);
                session.SaveChanges();
            }
        }

        public void RemoveUser(string userName)
        {
            using (var session = Store.OpenSession())
            {
                session.Query<PhoneStorage>()
                    .First()
                    .Data.Remove(GetId(userName));
                session.SaveChanges();
            }
        }

        public void RemovePhone(int id, Phone phone)
        {
            using (var session = Store.OpenSession())
            {
                var tmp = session.Query<PhoneStorage>()
                    .First()
                    .Data[id].Value.First(x => x.Value == phone.Value);
                session.Query<PhoneStorage>()
                    .First()
                    .Data[id].Value.Remove(tmp);
                session.SaveChanges();
            }
        }

        public void RemovePhone(string userName, Phone phone)
        {
            using (var session = Store.OpenSession())
            {
                var tmp = session.Query<PhoneStorage>()
                    .First()
                    .Data[GetId(userName)].Value.First(x => x.Value == phone.Value);
                session.Query<PhoneStorage>()
                    .First()
                    .Data[GetId(userName)].Value.Remove(tmp);
                session.SaveChanges();
            }
        }

        public int GetId(string userName)
        {
            using (var session = Store.OpenSession())
            {
                try
                {
                    return session.Query<PhoneStorage>()
                        .First()
                        .Data.First(x => x.Value.Key.UserName == userName).Key;
                }
                catch (InvalidOperationException)
                {
                    return -1;
                }
            }
        }
    }
}
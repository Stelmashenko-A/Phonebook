using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Models;
using Raven.Abstractions.Extensions;

namespace Phonebook.MSSQL
{
    public class MSSQLRepository:IRepository
    {
        public IEnumerable<Phone> GetPhone(int id)
        {
            using (var db = new PhoneBookContext())
            {
                return db.Account.Include(p => p.Phones).First(x => x.Id == id).Phones;
            }
        }

        public IEnumerable<Phone> GetPhone(string userName)
        {
            
            using (var db = new PhoneBookContext())
            {
                try
                {
                    return db.Account.Include(p => p.Phones).First(x => x.UserName == userName).Phones;
                }
                catch (Exception)
                {
                    
                    return new List<Phone>();
                }
                
            }
        }

        public IEnumerable<string> GetAllUserNames()
        {
            try
            {
                using (var db = new PhoneBookContext())
                {
                    try
                    {
                        return db.Account.Include(p => p.Phones).ToList().Select(x => x.UserName).ToList();
                        //return null;
                    }
                    catch (Exception)
                    {

                        return new List<string>();
                    }

                }
            }
            catch (Exception)
            {

                return new List<string>();
            }
           
        }

        public IEnumerable<KeyValuePair<string, IList<Phone>>> GetAllPhones()
        {
            throw new NotImplementedException();
        }

        public void AddUser(string userName, IList<Phone> phones)
        {
            using (var db = new PhoneBookContext())
            {
                var user = new Account(userName) {Phones = phones};
                db.Account.Add(user);
                db.SaveChanges();
            }
        }

        public void AddUser(string userName)
        {
            using (var db = new PhoneBookContext())
            {
                var user = new Account(userName) { Phones = new List<Phone>() };
                db.Account.Add(user);
                db.SaveChanges();
            }
        }

        public void AddPhone(int id, Phone phone)
        {
            using (var db = new PhoneBookContext())
            {
                var account = db.Account.Include(p => p.Phones).FirstOrDefault(user=>user.Id ==id);
                db.Account.Attach(account);
                var entry = db.Entry(account);
                account?.Phones.Add(phone);
                entry.Property(e => e.Phones).IsModified = true;
                db.SaveChanges();
            }
        }

        public void AddPhone(int id, IList<Phone> phones)
        {
            using (var db = new PhoneBookContext())
            {
                var account = db.Account.Include(p => p.Phones).FirstOrDefault(user => user.Id == id);
                db.Account.Attach(account);
                var entry = db.Entry(account);
                account?.Phones.AddRange(phones);
                entry.Property(e => e.Phones).IsModified = true;
                db.SaveChanges();
            }
        }

        public void AddPhone(string userName, Phone phone)
        {
            using (var db = new PhoneBookContext())
            {
                var account = db.Account.Include(p => p.Phones).FirstOrDefault(user => user.UserName == userName);
                db.Account.Attach(account);
                account?.Phones.Add(phone);
                db.SaveChanges();
            }
        }

        public void AddPhone(string userName, IList<Phone> phones)
        {
            using (var db = new PhoneBookContext())
            {
                var account = db.Account.Include(p => p.Phones).FirstOrDefault(user => user.UserName == userName);
                db.Account.Attach(account);
                var entry = db.Entry(account);
                account?.Phones.AddRange(phones);
                entry.Property(e => e.Phones).IsModified = true;
                db.SaveChanges();
            }
        }

        public void RemoveUser(int id)
        {
            using (var db = new PhoneBookContext())
            {
                var account = db.Account.Include(p => p.Phones).FirstOrDefault(user => user.Id == id);
                db.Account.Remove(account);
                db.SaveChanges();
            }
        }

        public void RemoveUser(string userName)
        {
            using (var db = new PhoneBookContext())
            {
                var account = db.Account.Include(p => p.Phones).FirstOrDefault(user => user.UserName == userName);
                db.Account.Remove(account);
                db.SaveChanges();
            }
        }

        public void RemovePhone(int id, Phone phone)
        {
            using (var db = new PhoneBookContext())
            {
                var account = db.Account.Include(p => p.Phones).FirstOrDefault(user => user.Id == id);
                db.Account.Attach(account);
                var entry = db.Entry(account);
                account?.Phones.Remove(phone);
                entry.Property(e => e.Phones).IsModified = true;
                db.SaveChanges();
            }
        }

        public void RemovePhone(string userName, Phone phone)
        {
            using (var db = new PhoneBookContext())
            {
                var account = db.Account.Include(p=>p.Phones).FirstOrDefault(item => item.UserName == userName);
                if (account != null)
                {
                    var phonetmp = account.Phones.FirstOrDefault(x => x.Number == phone.Number);
                    db.Phones.Remove(phonetmp);
                }
                // db.Account.Attach(account);
               // var entry = db.Entry(account);
              //  account?.Phones.Remove(phone);
              //  entry.Property(e => e.Phones).IsModified = true;
                db.SaveChanges();
            }
        }

        public int GetId(string userName)
        {
            using (var db = new PhoneBookContext())
            {
                var account = db.Account.Include(p => p.Phones).FirstOrDefault(user => user.UserName == userName);
                if (account != null) return account.Id;
                return -1;
            }
        }
    }

    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() : base("name=PhoneBookDBConnectionString")
        {

        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}

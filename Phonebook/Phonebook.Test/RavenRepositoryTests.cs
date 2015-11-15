using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook.Exceptions;

namespace Phonebook.Test
{
    [TestClass]
    public class RavenRepositoryTests
    {
        private readonly RavenRepository _ravenRepository = new RavenRepository();

        [TestMethod]
        public void AddUserTest()
        {
            _ravenRepository.AddUser("TestUser");
            var tmp = _ravenRepository.GetAllUserNames();
            _ravenRepository.RemoveUser("TestUser");
            Assert.IsTrue(tmp.Contains("TestUser"));
        }

        [TestMethod]
        public void GetPhoneByIdTest()
        {
            var phones = _ravenRepository.GetPhone(2);

            Assert.AreEqual(0, phones.ToList().Count);
        }

        [TestMethod]
        public void GetPhoneByNameTest()
        {
            var phones = _ravenRepository.GetPhone("Andrew");
            Assert.AreEqual(0, phones.ToList().Count);
        }

        [TestMethod]
        public void GetAllPhonesTest()
        {
            var phones = _ravenRepository.GetAllPhones();

            Assert.IsNotNull(phones);
        }

        [TestMethod]
        public void AddUserWithPhonesTest()
        {
            const string name = "UserWithPhones";
            IList<Phone> phones = new List<Phone>(1);
            phones.Add(new Phone("+375441234567"));
            _ravenRepository.AddUser(name, phones);
            var tmp = _ravenRepository.GetPhone(name).ToList();
            _ravenRepository.RemoveUser(name);
            Assert.IsTrue(phones.SequenceEqual(tmp));

        }

        [TestMethod]
        public void RemoveUserByIdTest()
        {
            const string userName = "TestUser";
            _ravenRepository.AddUser("TestUser");
            var id = _ravenRepository.GetId(userName);

            _ravenRepository.RemoveUser(id);
            Assert.AreEqual(-1, _ravenRepository.GetId(userName));

        }

        [TestMethod]
        public void AddRemovePhoneByIdTest()
        {
            const string userName = "TestPhones";
            var id = _ravenRepository.GetId("TestPhones");
            var phone = new Phone("+375444444444");
            _ravenRepository.AddPhone(id, phone);
            var phones = _ravenRepository.GetPhone(userName);
            _ravenRepository.RemovePhone(id, phone);
            Assert.IsTrue(phones.Contains(phone));
        }

        [TestMethod]
        public void AddRemovePhoneByUserNameTest()
        {
            const string userName = "TestPhones";
            var phone = new Phone("+375444444444");
            _ravenRepository.AddPhone(userName, phone);
            var phones = _ravenRepository.GetPhone(userName);
            _ravenRepository.RemovePhone(userName, phone);
            Assert.IsTrue(phones.Contains(phone));
        }

        [TestMethod]
        public void AddRemoveListOfPhonesByUserNameTest()
        {
            const string userName = "TestPhones";
            var phones = new List<Phone> {new Phone("+375444444444"), new Phone("+375447777777")};

            _ravenRepository.AddPhone(userName, phones);
            var phonesFromBd = _ravenRepository.GetPhone(userName).ToList();
            foreach (var variable in phonesFromBd)
            {
                _ravenRepository.RemovePhone(userName,variable);
            }
            foreach (var variable in phonesFromBd)
            {
               Assert.IsTrue(phones.Contains(variable));
            }
            Assert.AreEqual(phones.Count,phonesFromBd.Count);
        }

        [TestMethod]
        public void AddRemoveListOfPhonesByIdNameTest()
        {
            const string userName = "TestPhones";
            var id = _ravenRepository.GetId(userName);
            var phones = new List<Phone> { new Phone("+375444444444"), new Phone("+375447777777") };

            _ravenRepository.AddPhone(id, phones);
            var phonesFromBd = _ravenRepository.GetPhone(id).ToList();
            foreach (var variable in phonesFromBd)
            {
                _ravenRepository.RemovePhone(id, variable);
            }
            foreach (var variable in phonesFromBd)
            {
                Assert.IsTrue(phones.Contains(variable));
            }
            Assert.AreEqual(phones.Count, phones.Count);
        }

        [TestMethod]
        public void IdNotExistExceptionTest()
        {
           Assert.IsNull(_ravenRepository.GetPhone(int.MaxValue));
        }

        [TestMethod]
        [ExpectedException(typeof(MultipleUserNameException))]
        public void MultipleUserNameExceptionTest()
        {
            _ravenRepository.GetId("multiple");
        }

        [TestMethod]
        public void GetIdWhichNotExistTest()
        {
            Assert.AreEqual(-1,_ravenRepository.GetId("not exist"));   
        }

        [TestMethod]
        public void GetPhonesNotExistedUserExistTest()
        {
            Assert.IsNull(_ravenRepository.GetPhone("not exist"));
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Phonebook.Test
{
    [TestClass]
    public class PhoneTests
    {
        [TestMethod]
        public void GetHashCodeTest()
        {
            var phone1 = new Phone("12345");
            var phone2 = new Phone("12345");
            var phone3 = new Phone("54321");
            Assert.IsTrue(phone1.GetHashCode() == phone2.GetHashCode());
            Assert.IsFalse(phone3.GetHashCode() == phone1.GetHashCode());
        }

        [TestMethod]
        public void EqualsTest()
        {
            var phone1 = new Phone("12345");
            var phone2 = new Phone("12345");
            var phone3 = new Phone("54321");
            var flag1 = phone1.Equals(phone2);
            Assert.IsTrue(flag1);
            var flag2 = phone3.Equals(phone1);
            Assert.IsFalse(flag2);
        }
    }
}
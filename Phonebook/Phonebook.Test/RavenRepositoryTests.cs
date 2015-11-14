using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Phonebook.Test
{
    [TestClass]
    public class RavenRepositoryTests
    {
        private readonly RavenRepository _ravenRepository = new RavenRepository();

        [TestMethod]
        public void AddUserTest()
        {
            _ravenRepository.AddUser("Andrew");
            var tmp = _ravenRepository.GetAllUserNames();
            _ravenRepository.RemoveUser("Andrew");
            Assert.IsTrue(tmp.Contains("Andrew"));
        }
    }
}
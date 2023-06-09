using DataAccessLibrary.Models;
using DataAccessLibrary;

namespace DBMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreationTesting()
        {
            // Arrange
            Random rand = new Random();
            string name = rand.Next().ToString();
            string pass = rand.Next().ToString();
            User user = new User(name,pass,0);
            DBUserManager manager = new DBUserManager();
            // Act
            manager.SingUpUser(user);
            User taken_user = manager.GetUserByName(user.Name);
            manager.RemoveUser(user);
            // Assert
            Assert.AreEqual(user.Name,taken_user.Name);
            Assert.AreEqual(user.ID, taken_user.ID);

        }
    }
}
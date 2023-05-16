using DataAccessLibrary.Models;
using DataAccessLibrary;

namespace DBMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Random rand = new Random();
            string name = rand.Next().ToString();
            string pass = rand.Next().ToString();
            User user = new User(name,pass,0);
            DBManager manager = new DBManager();
            // Act
            manager.SingUpUser(user);
            User taken_user = manager.GetUserByName(user.Name);
            
            // Assert
            Assert.AreEqual(user.Name,taken_user.Name);

        }
    }
}
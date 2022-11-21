using DataAccess.Data;
using DataAccess.DBAccess;
using DataAccess.Models;
using Moq;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace MinimalAPI.Test
{
    public class MinimalAPITest
    {
        private readonly Mock<ISQLDataAccess> _db = new Mock<ISQLDataAccess>( );
        
        
        [Test]
        public async Task Test1()
        {

            UserDataRepo repo = new UserDataRepo(_db);
            UserModel user = new UserModel();
            user.FirstName = "Test";
            user.LastName = "TEst";
            _db.Setup(mock => mock.SaveData("sp_InsertUser", new { user.FirstName, user.LastName }, "default")).Returns(Task.CompletedTask);
           await repo.InsertUser(user);
            _db.Verify(mock => mock.SaveData("sp_InsertUser", new { user.FirstName, user.LastName }, "default"), Times.Once);
            Assert.Pass();
        }
    }
}
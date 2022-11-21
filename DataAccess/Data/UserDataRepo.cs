using DataAccess.DBAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class UserDataRepo : IUserDataRepo
    {
        private readonly ISQLDataAccess _db;
        public UserDataRepo(ISQLDataAccess db)
        {
            _db = db;

        }

        public Task<IEnumerable<UserModel>> GetUser() => _db.LoadData<UserModel, dynamic>("sp_GetAllUser", new { });

        public async Task<UserModel?> GetUser(int id)
        {
            var results = await _db.LoadData<UserModel, dynamic>("dbo.spUserGet", new { id });
            return results.FirstOrDefault();
        }

        public Task InsertUser(UserModel user) =>
          _db.SaveData("sp_InsertUser", new { user.FirstName, user.LastName });

        public Task UpdateUser(UserModel user) =>
            _db.SaveData("[dbo].[sp_UpsertUser]", new { user });

        public Task DeleteUser(int id) =>
            _db.SaveData("[dbo].[sp_DeleteUser]", new { id });
    }
}

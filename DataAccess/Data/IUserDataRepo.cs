using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IUserDataRepo
    {
        Task DeleteUser(int id);
        Task<IEnumerable<UserModel>> GetUser();
        Task<UserModel?> GetUser(int id);
        Task InsertUser(UserModel user);
        Task UpdateUser(UserModel user);
    }
}
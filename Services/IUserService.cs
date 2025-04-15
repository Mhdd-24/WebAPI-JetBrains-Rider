// Services/IUserService.cs
using VibeCodeUserMgmtCRUD.Models;

namespace VibeCodeUserMgmtCRUD.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
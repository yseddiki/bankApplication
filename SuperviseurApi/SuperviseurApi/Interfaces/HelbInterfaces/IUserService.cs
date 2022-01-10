using SuperviseurApi.Models;

namespace SuperviseurApi.Services.HelbService
{
    public interface IUserService
    {
        Task<User?> AddUser(User user);
        void DeleteUser(int id);
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(int id);
    }
}
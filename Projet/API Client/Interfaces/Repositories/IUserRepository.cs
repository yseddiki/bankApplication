using API_Client.Model;

namespace API_Client.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> UsersList();
        void DeleteUser(int id);
        Task<User> GetUser(int id);
        Task UpdateUser(User user);
        Task<User> AddUser(User user);
        Task<User> LoginUser(UserLogin user);
    }
}
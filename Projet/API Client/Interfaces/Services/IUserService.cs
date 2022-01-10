using API_Client.Model;

namespace API_Client.Services
{
    public interface IUserService
    {
        public Task<User> GetUser(int id);
        public Task<User> AddUser(User user);
        public Task<User> UpdateUser(User user);
        public Task<User> LoginUser(UserLogin user);
        public void DeleteUser(int id);

        public Task<List<User>> GetAllUsers();
    }
}
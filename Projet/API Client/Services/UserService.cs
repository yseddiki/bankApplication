using API_Client.Model;
using API_Client.Repositories;

namespace API_Client.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(User user)
        {
            return await _userRepository.AddUser(user);
        }

        public async void DeleteUser(int id)
        {
              _userRepository.DeleteUser(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
           return await _userRepository.UsersList();
        }

        public async Task<User> GetUser(int id)
        {
           return await _userRepository.GetUser(id);
        }
        public async Task<User> LoginUser(UserLogin userLogin)
        {
            var user = await _userRepository.LoginUser(userLogin);
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var oldUser = await GetUser(user.Id);
            oldUser.username = user.username;
            oldUser.phone = user.phone;
            oldUser.email = user.email;
            oldUser.postalCode = user.postalCode;
            oldUser.city = user.city;
            oldUser.address = user.address;
            oldUser.country = user.country;
            await _userRepository.UpdateUser(oldUser);
            return oldUser;
        }
    }
}

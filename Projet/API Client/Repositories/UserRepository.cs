using API_Client.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Client.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<User> GetUser(int id)
        {
            return await _databaseContext.Users.FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task UpdateUser(User user)
        {
           
            _databaseContext.Users.Update(user);
            await _databaseContext.SaveChangesAsync();
            
        }
        public async Task<User> LoginUser (UserLogin userLogin)
        {
           User user =  await _databaseContext.Users.Include(u=>u.Role).FirstOrDefaultAsync(o => o.username.Equals(userLogin.Username)
                                    && o.password.Equals(userLogin.Password));
            return user;
        }
        public async void DeleteUser(int id)
        {
            var user = await GetUser(id);
            _databaseContext.Users.Remove(user);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task<List<User>> UsersList()
        {
            return await _databaseContext.Users.ToListAsync();
        }
        public async Task<User> AddUser(User user)
        {
            if (user == null) { return null;};
            await _databaseContext.Users.AddAsync(user);
            await _databaseContext.SaveChangesAsync();
            return user;
        }
    }
}

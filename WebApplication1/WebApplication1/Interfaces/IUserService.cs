
using WebApplication1.DomainModels;

namespace WebApplication1.Interfaces
{
    public interface IUserService
    {

        public Task SaveNewUser(User user);
        public Task EditUserSave(User user);
        public Task DeleteUser(User user);
        public Task<User> GetUser(string UserEmail);
        public Task<List<User>> GetUsers();

    }
}

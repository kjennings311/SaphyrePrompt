using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.ComponentModel;
using WebApplication1.DomainModels;
using WebApplication1.Interfaces;
using WebApplication1.Repository;
namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
    

      

        public async Task DeleteUser(User user)
        {
            try
            {
                using (var context = new RepoContext())
                {
                   

                    context.Entry(user).State = EntityState.Deleted;
                    await context.SaveChangesAsync();

                    
                }


            }
            catch (Exception ex)
            {

            }
        }

        public async Task EditUserSave(User user)
        {

            try
            {
                using (var context = new RepoContext())
                {
                   var _user = await context.UserTable.Where(x=>x.Email==user.Email).FirstOrDefaultAsync();
                    //some edits 

                   await context.SaveChangesAsync();
                }


            }
            catch (Exception ex)
            {

            }
        }

        public async Task<User> GetUser(String UserEmail)
        {

            try
            {
                using (var context = new RepoContext())
                {
                    var _user = await context.UserTable.Where(x => x.Email == UserEmail).FirstOrDefaultAsync();
                    return _user;
                    
                }


            }
            catch (Exception ex)
            {
                return new User();
            }
        }



        public async Task<List<User>> GetUsers()
        {
            try
            {
                using (var context = new RepoContext())
                {
                    var UserList = await context.UserTable.Where(x => x.Email != String.Empty).ToListAsync();
                    return UserList;
                }
            }
            catch (Exception ex)
            {
                return new List<User>();
            }

        }

    

        public async Task SaveNewUser(User user)
        {

            try
            {
                using (var context = new RepoContext())
                {
                    await context.AddAsync(user);
                    await context.SaveChangesAsync();
                }


            }
            catch (Exception ex)
            {

            }

            
        }

     
    }
}

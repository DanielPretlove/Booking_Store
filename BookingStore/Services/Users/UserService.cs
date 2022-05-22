using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Model;

namespace BookingStore.Services.Users
{
    public class UserService : IUserService
    {

        private readonly UserContext userContext;

        public UserService(UserContext userContext) 
        {
            this.userContext = userContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await userContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int Id)
        {
            return await userContext.Users.Where(x => x.ID == Id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmailAddress(string email)
        {
            return await userContext.Users.Where(x => x.EmailAddress == email).FirstOrDefaultAsync();
        }

        public async Task<User> AddNewUser(User user)
        {
            var result = await userContext.Users.AddAsync(user);
            await userContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<User> UpdateUser(User user)
        {
            var result = await userContext.Users.FirstOrDefaultAsync(x => x.ID == user.ID);

            if(result != null) 
            {
                result.Username = user.Username;
                result.EmailAddress = user.EmailAddress;
                result.Role = user.Role;
                result.Password = user.Password;

                await userContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<User> DeleteUser(int ID)
        {
            var result = await userContext.Users.FirstOrDefaultAsync(x => x.ID == ID);

            if(result != null)
            {
                userContext.Users.Remove(result);
                await userContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
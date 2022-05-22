using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace BookingStore.Services.Users
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int Id);
        public Task<User> GetUserByEmailAddress(string email);
        public Task<User> AddNewUser(User user);
        public Task<User> UpdateUser(User user);
        public Task<User> DeleteUser(int ID);
    }
}
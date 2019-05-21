using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelter.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _appDbContext.Users;
        }

        public User GetUserById(int UserId)
        {
            return _appDbContext.Users.FirstOrDefault(p => p.UserId == UserId);
        }
    }
}

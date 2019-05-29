using Microsoft.AspNetCore.Identity;
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


        public IdentityUser GetUserById(string id)
        {
            return _appDbContext.AspNetUsers.Where(user => user.Id == id).FirstOrDefault();
        }

    }
}

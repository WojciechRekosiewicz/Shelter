using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelter.Models
{
    interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int UserId);
    }
}

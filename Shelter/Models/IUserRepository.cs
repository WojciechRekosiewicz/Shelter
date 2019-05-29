using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelter.Models
{
    public interface IUserRepository
    {
        IdentityUser GetUserById(string id);
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelter.ViewModels
{
    public class AdvertViewModel 
    {
        public string Title { get; set; }
        public IdentityUser User { get; set; }
    }
}

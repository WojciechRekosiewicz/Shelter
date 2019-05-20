using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelter.Models
{
    interface IAdvertRepository
    {
        IEnumerable<Advert> GetAllAdverts();
        Advert GetAdvertById(int AdvertID);
    }
}

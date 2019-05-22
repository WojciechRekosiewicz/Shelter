using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelter.Models
{
    public interface IAdvertRepository
    {
        IEnumerable<Advert> GetAllAdverts();
        Advert GetAdvertById(int AdvertID);
        void Create(Advert advert);
        void Delete(int id);
    }
}

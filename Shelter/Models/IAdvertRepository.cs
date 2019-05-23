using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelter.Models
{
    public interface IAdvertRepository
    {
        IEnumerable<Advert> GetAllAdverts();
        IEnumerable<Advert> GetAdvertsByUserId(string userId);
        Advert GetAdvertById(int AdvertID);
        void Create(Advert advert);
        void Delete(int id);
        void Update(Advert advert);
        bool CanDelete(string userId, int advertId);
    }
}

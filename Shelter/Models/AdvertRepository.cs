using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelter.Models
{
    public class AdvertRepository : IAdvertRepository
    {
        private readonly AppDbContext _appDbContext;

        public AdvertRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Advert> GetAllAdverts()
        {
            return _appDbContext.Adverts;
        }

        public Advert GetAdvertById(int AdvertID)
        {
            return _appDbContext.Adverts.FirstOrDefault(p => p.AdvertId == AdvertID);
        }


    }
}

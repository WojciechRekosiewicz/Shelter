
﻿using Microsoft.AspNetCore.Identity;
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

        public IEnumerable<Advert> GetAdvertsByUserId(string id)
        {
            return _appDbContext.Adverts.Where(advert => advert.AuthorId == id).ToArray();
        }

        public IEnumerable<Advert> GetAllAdverts()
        {
            return _appDbContext.Adverts.ToArray();
        }

        public Advert GetAdvertById(int AdvertID)
        {
            return _appDbContext.Adverts.FirstOrDefault(p => p.AdvertId == AdvertID);
        }

        public void Create(Advert advert)
        {
            _appDbContext.Add(advert);

            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var record = (from advert in _appDbContext.Adverts
                            where advert.AdvertId == id
                            select advert).FirstOrDefault();
            if (record != null)
            {
                _appDbContext.Adverts.Remove(record);
                _appDbContext.SaveChanges();
            }
        }

        public bool CanDelete(string userId, int advertId)
        {
            var record = (from advert in _appDbContext.Adverts
                            where advert.AdvertId == advertId
                            select advert.AuthorId).FirstOrDefault();

            return (record != null) ? record == userId : false;
        }

        public void Update(Advert advert)
        {
            _appDbContext.Update(advert);

            _appDbContext.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Shelter.Controllers;
using NUnit.Framework;
using Shelter.Models;
using Moq;

namespace test
{
    public class AdvertRepositoryShould
    {
        [Test]
        public void CreateNewAdvert()
        {
            var mockAdvertRepository = new Mock<IAdvertRepository>();
            Advert sampleAdvert = new Advert { AdvertId = 1, Title = "Kot burek", AuthorId = "d1fb7415-45ca-40d3-86a0-55c258965444", ShortDescription = "Taki se kotek fajny", LongDescription = "Super mega ekstra dlugi kot z dlugim opisem", ImageUrl = "https://img.besty.pl/images/396/82/3968217.jpg" };
            Advert sampleAdvert2 = new Advert { AdvertId = 2, Title = "Kot burek2", AuthorId = "d2fb7415-45ca-40d3-86a0-55c258965444", ShortDescription = "Taki se kotek fajny2", LongDescription = "Super mega ekstra dlugi kot z dlugim opisem2", ImageUrl = "https://img.besty.pl/images/396/82/3968217.jpg" };
            mockAdvertRepository.Setup(advert => advert.GetAdvertById(1)).Returns(sampleAdvert);

            Assert.AreEqual(sampleAdvert, mockAdvertRepository.Object.GetAdvertById(1));
            Assert.AreEqual(sampleAdvert, mockAdvertRepository.Object.GetAllAdverts().GetEnumerator().Current);
        }
    }
}

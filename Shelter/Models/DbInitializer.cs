using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelter.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Adverts.Any())
            {
                context.AddRange
                (
                    new Advert { Title = "Kot burek", AuthorId = "d1fb7415-45ca-40d3-86a0-55c258965444", ShortDescription = "Taki se kotek fajny", LongDescription = "Super mega ekstra dlugi kot z dlugim opisem", ImageUrl = "https://img.besty.pl/images/396/82/3968217.jpg" },
                    new Advert { Title = "Pies Azor", AuthorId = "d1fb7415-45ca-40d3-86a0-55c258965444", ShortDescription = "Duży skurczybyk", LongDescription = "Fajnie goni listonosza", ImageUrl = "https://www.wykop.pl/cdn/c3201142/comment_zKuWohgYtJwjt30l9fjfxDUipsxbVUOj.jpg" }
                );

                context.SaveChanges();
            }
        }
    }
}

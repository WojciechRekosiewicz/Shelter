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
                    new Advert { Title = "Kot burek", AuthorId = "3a70755a-74c2-48c5-b4a6-9f54f8006367", ShortDescription = "Taki se kotek fajny", LongDescription = "Super mega ekstra dlugi kot z dlugim opisem", ImageUrl = "https://img.besty.pl/images/396/82/3968217.jpg" },
                    new Advert { Title = "Pies Azor", AuthorId = "3a70755a-74c2-48c5-b4a6-9f54f8006367", ShortDescription = "Duży skurczybyk", LongDescription = "Fajnie goni listonosza", ImageUrl = "https://www.wykop.pl/cdn/c3201142/comment_zKuWohgYtJwjt30l9fjfxDUipsxbVUOj.jpg" }
                );

                context.SaveChanges();
            }
        }
    }
}

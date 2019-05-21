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
            if (!context.Users.Any())
            {
                context.AddRange
                (
                    new User { Name="Janusz", Surname="Kowalski", Email="horacurka@pieniazek.pl", TelephoneNumber="666777888",  Password="kotalik" },
                    new User { Name = "Sebastian", Surname = "Problem", Email = "jessica@pieniazek.pl", TelephoneNumber = "112233445", Password = "legja" }

                );

                context.SaveChanges();
            }

            if (!context.Adverts.Any())
            {
                context.AddRange
                (
                    new Advert { Title="Kot burek", AuthorId=1, ShortDescription="Taki se kotek fajny", LongDescription="Super mega ekstra dlugi kot z dlugim opisem", ImageUrl= "https://img.besty.pl/images/396/82/3968217.jpg" },
                    new Advert { Title = "Pies Azor", AuthorId = 2, ShortDescription = "Duży skurczybyk", LongDescription = "Fajnie goni listonosza", ImageUrl = "https://www.wykop.pl/cdn/c3201142/comment_zKuWohgYtJwjt30l9fjfxDUipsxbVUOj.jpg" }


                );

                context.SaveChanges();
            }

        }
    }
}

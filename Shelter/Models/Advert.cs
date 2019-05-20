using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shelter.Models
{
    public class Advert
    {
        public int AdvertId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int? ReservingId { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("AuthorId")]
        public User AuthorUser { get; set; }
        [ForeignKey("ReservingId")]
        public User ReservingUser { get; set; } 
    }
}

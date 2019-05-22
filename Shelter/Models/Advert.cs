using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Shelter.Models
{
    public class Advert
    {
        public int AdvertId { get; set; }
        [Required]
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string ReservingId { get; set; }
        [Required]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }
        [Required]
        [DisplayName("Long Description")]
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("AuthorId")]
        public IdentityUser AuthorUser { get; set; }
        [ForeignKey("ReservingId")]
        public IdentityUser ReservingUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentAFlat.Models
{
    public class Flat
    {
        public int Id { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public User Owner { get; set; }

        [Required]
        public long PostCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        public double RoomCount { get; set; }

        public string MainPic { get; set; }

        [Required]
        public Boolean IsActive { get; set; }

        public string Location { get; set; }

    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentAFlat.Models
{
    public class Offer
    {
        public int Id { get; set; }

        [Required]
        public int RenterId { get; set; }

        public User Renter { get; set; }

        [Required]
        public int FlatId { get; set; }

        public Flat Flat { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public DateTime Date_From { get; set; }

        [Required]
        public DateTime Date_Until { get; set; }

        [Required]
        public Boolean IsAccepted { get; set; }

    }

}

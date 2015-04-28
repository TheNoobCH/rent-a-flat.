using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentAFlat.Models
{
    public class UserViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ProfilePic { get; set; }

        public Boolean IsActive { get; set; }
    }
}
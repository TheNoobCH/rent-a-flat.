using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentAFlat.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }        
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string ProfilePic { get; set; }        
        public Boolean IsActive { get; set; }

        public void create( 
            string username, 
            string password, 
            string firstname, 
            string lastname, 
            string email, 
            string profilePic, 
            Boolean isActive)
        {
            this.Username = username;
            this.Password = password;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this.ProfilePic = profilePic;
            this.IsActive = isActive;
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RentAFlat.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ProfilePic { get; set; }

        [Required]
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
            var hashPassword = HashPassword(password);

            this.Username = username;
            this.Password = hashPassword;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this.ProfilePic = profilePic;
            this.IsActive = isActive;
        }

        private byte[] HashPassword(string password)
        {
            using (var md5Hasher = new MD5CryptoServiceProvider())
            {
                var encoder = new UTF8Encoding();
                return md5Hasher.ComputeHash(encoder.GetBytes(password));
            }
        }
    }

}

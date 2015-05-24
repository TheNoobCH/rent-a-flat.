using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentAFlat.Models;
using System.Security.Cryptography;
using System.Text;

namespace RentAFlat.Controllers
{
    public class UserController : Controller
    {
        private RentAFlatDBContext db = new RentAFlatDBContext();

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(User model)
        {
            if (db.Users.Count(u => u.Username == model.Username) > 0)
            {
                ModelState.AddModelError("username", "Username already exists. Please choose another one");
            }

            User user = new User();

            user.Username = model.Username;
            user.Password = HashPassword(model.Password);
            user.Firstname = model.Lastname;
            user.Lastname = model.Lastname;
            user.ProfilePic = model.ProfilePic;
            user.IsActive = true;
            user.Email = model.Email;

            if (ModelState.IsValid)
            {
                
                db.Users.Add(user);
                db.SaveChanges();
                var data = new { success = true };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false, text = "Registration failed!" }, JsonRequestBehavior.AllowGet);
            
        }


        private string HashPassword(string password)
        {
            using (var md5Hasher = new MD5CryptoServiceProvider())
            {
                var encoder = new UTF8Encoding();
                byte[] bytes = md5Hasher.ComputeHash(encoder.GetBytes(password));

                // Convert the byte array to hexadecimal string
                StringBuilder strBuild = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    strBuild.Append(bytes[i].ToString("X2"));
                }

                return strBuild.ToString();

            }
        }

    }
}
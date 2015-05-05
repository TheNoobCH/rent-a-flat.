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
        

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(UserViewModel model)
        {
            RentAFlatDBContext db = new RentAFlatDBContext();
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
﻿using RentAFlat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RentAFlat.Controllers
{
    public class AuthenticationController : Controller
    {
        private RentAFlatDBContext db = new RentAFlatDBContext();

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User authUser = Authenticate(model.Username, model.Password);
                if (authUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    return Json(new { authenticated = true, userId = authUser.Id }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { authenticated = false, text = "Username or Password was incorrect" }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public User Authenticate(string username, string password)
        {
            if (password == null)
            {
                return null;
            }
            var passwordHash = HashPassword(password);

            var test = db.Users
                .Where(u => u.Username == username).Select(a => a.Password);

            return db.Users
                .Where(u => u.Username == username
                && u.Password != null
                && u.Password == passwordHash)
                .SingleOrDefault();
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

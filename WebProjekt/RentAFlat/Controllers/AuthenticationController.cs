using RentAFlat.Models;
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
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User authUser = Authenticate(model.Username, model.Password);
                if (authUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, true);

                    var data = new
                    {
                        authenticated = true
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public User Authenticate(string username, string password)
        {
            if (password == null)
            {
                return null;
            }
            var passwordHash = HashPassword(password);

            return db.Users
                .Where(u => u.Username == username
                && u.Password != null
                && u.Password == passwordHash)
                .SingleOrDefault();
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

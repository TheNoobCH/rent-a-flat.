using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentAFlat.Models;

namespace RentAFlat.Controllers
{
    public class UserController : Controller
    {
        private RentAFlatDBContext db = new RentAFlatDBContext();

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string username, string firstname, string lastname, string email, string password)
        {
            var model = new User();

            if(db.Users.Count(u => u.Username == username) > 0)

            model.create(username, password, firstname, lastname, email, "", true);
            if (ModelState.IsValid)
            {
                db.Users.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {

            if (ModelState.IsValid && db.Users.Count(u => u.Username == username && u.Password == password) > 0)
            {
                db.Users.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
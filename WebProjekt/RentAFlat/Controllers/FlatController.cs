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
    public class FlatController : Controller
    {
        private RentAFlatDBContext db = new RentAFlatDBContext();

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult IndexSearch(string Location)
        {
            List<Flat> flats = new List<Flat>();

            // If there is no search entry then display all flats
            if (String.IsNullOrEmpty(Location))
            {
                flats = db.Flat
                    .ToList();
            }
            else
            {
                List<Flat> data = db.Flat
                .Where(f => f.Location == Location).ToList();

                return Json(data, JsonRequestBehavior.AllowGet);
            }

            return Json(flats, JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        public JsonResult Create(Flat model)
        {
            if (ModelState.IsValid)
            {
                db.Flat.Add(model);
                db.SaveChanges();
                return Json(new { error = false }, JsonRequestBehavior.AllowGet);
            }
            var errorList = (from item in ModelState
                            where item.Value.Errors.Any()
                            select item.Value.Errors[0].ErrorMessage).ToList();

            return Json(new { error = true, text = errorList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Details(long Id)
        {
            var data = db.Flat.Where(f => f.Id == Id).SingleOrDefault();

            if (data != null)
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }

            return Json(new { error = "No entity with the Id: " + Id + "was found" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(long Id)
        {
            var flat = db.Flat.Where(f => f.Id == Id).SingleOrDefault();

            if (flat != null)
            {
                db.Flat.Remove(flat);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, error = "No entity with the Id: " + Id + "was found" }, JsonRequestBehavior.AllowGet);
        }

    }
}

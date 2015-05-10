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
        public JsonResult IndexSearch(string Location)
        {
            var data = db.Flats
                .Where(f => f.Location == Location).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Flat model)
        {
            if (ModelState.IsValid)
            {
                db.Flats.Add(model);
                db.SaveChanges();
                return Json(new { error = false }, JsonRequestBehavior.AllowGet);
            }
            var errorList = (from item in ModelState
                            where item.Value.Errors.Any()
                            select item.Value.Errors[0].ErrorMessage).ToList();

            return Json(new { error = true, text = errorList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Details(Flat model)
        {
            if (ModelState.IsValid)
            {
                db.Flats.Add(model);
                db.SaveChanges();
                return Json(new { error = false }, JsonRequestBehavior.AllowGet);
            }
            var errorList = (from item in ModelState
                             where item.Value.Errors.Any()
                             select item.Value.Errors[0].ErrorMessage).ToList();

            return Json(new { error = true, text = errorList }, JsonRequestBehavior.AllowGet);
        }

    }
}

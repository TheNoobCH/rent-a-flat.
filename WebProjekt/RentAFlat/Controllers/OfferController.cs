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
    public class OfferController : Controller
    {
        private RentAFlatDBContext db = new RentAFlatDBContext();

        [HttpPost]
        public JsonResult Create(Offer model)
        {
            model.RenterId = db.Users.Where(u => u.Username == User.Identity.Name).SingleOrDefault() != null ? db.Users.Where(u => u.Username == User.Identity.Name).SingleOrDefault().Id : 0;
            if (ModelState.IsValid && model.RenterId != 0)
            {
                db.Offers.Add(model);
                db.SaveChanges();
                return Json(new { error = false }, JsonRequestBehavior.AllowGet);
            }
            var errorList = (from item in ModelState
                             where item.Value.Errors.Any()
                             select item.Value.Errors[0].ErrorMessage).ToList();

            return Json(new { error = true, text = errorList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(long Id)
        {
            var offer = db.Offers.Where(f => f.Id == Id).SingleOrDefault();

            if (offer != null)
            {
                db.Offers.Remove(offer);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, error = "No entity with the Id: " + Id + "was found" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AcceptFlatOffer(long Id)
        {
            var offer = db.Offers.Where(o => o.Id == Id).SingleOrDefault();

            if (offer != null)
            {
                offer.IsAccepted = true;
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, error = "No offer with the Id: " + Id + "was found" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeclineFlatOffer(long Id)
        {
            var offer = db.Offers.Where(o => o.Id == Id).SingleOrDefault();

            if (offer != null)
            {
                offer.IsAccepted = false;
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, error = "No offer with the Id: " + Id + "was found" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OfferIndexAction(long ownerId)
        {
            var offers = db.Offers.Where(o => o.Flat.OwnerId == ownerId).ToList();

            return Json(offers, JsonRequestBehavior.AllowGet);
        }

    }
}

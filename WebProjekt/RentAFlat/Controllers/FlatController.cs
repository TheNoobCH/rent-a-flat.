using RentAFlat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentAFlat.Controllers
{
    public class FlatController : Controller
    {
        private RentAFlatDBContext db = new RentAFlatDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexSearch(string ort)
        {

            return View();
        }

    }
}

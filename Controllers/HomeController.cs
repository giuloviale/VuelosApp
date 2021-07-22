using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebVuelos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Bienvenidos al sitio web de vuelos";
            ViewBag.Date = DateTime.Today.ToShortDateString();
            return View();
        }
    }
}
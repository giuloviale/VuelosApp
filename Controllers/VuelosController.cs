using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWebVuelos.Models;
using SistemaWebVuelos.Data;


namespace SistemaWebVuelos.Controllers
{
    public class VuelosController : Controller
    {
        SistemaVuelosDBContext context = new SistemaVuelosDBContext();
        // GET: Vuelos
        public ActionResult Index()
        {
            var vuelo = context.vuelos.ToList();
            return View(vuelo);
        }
        //Crear
        public ActionResult Create()
        {
            Vuelo vuelo = new Vuelo();
            return View("Create", vuelo);
        }
        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                context.vuelos.Add(vuelo);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View("Create", vuelo);
            }
        }
        //Detalle
        public ActionResult Detail(int Id)
        {
            var vuelo = context.vuelos.Find(Id);
            if (vuelo != null)
            {
                return View("Detail",vuelo);
            }
            else
            {
                return HttpNotFound();
            }
        }
        //Delete
        public ActionResult Delete(int Id)
        {
            Vuelo vuelo = context.vuelos.Find(Id);
            if (vuelo != null)
            {
                return View("Delete", vuelo);
            }
            return HttpNotFound();
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {

            Vuelo vuelo = context.vuelos.Find(Id);

            context.vuelos.Remove(vuelo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Edit
        public ActionResult Edit(int id)
        {
            var vuelo = context.vuelos.Find(id);
            if (vuelo != null)
            {
                return View("Edit", vuelo);

            }
            else
            {
                return View(vuelo);
            }
        }
        [HttpPost]
        public ActionResult Edit(Vuelo vuelo)
        {
            if (vuelo != null)
            {
                context.Entry(vuelo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(vuelo);
            }

        }
        //Traer por destino
        public ActionResult TraerPorDestino(string destino)
        {
            var vuelos = (from v in context.vuelos where v.Destino == destino select v).ToList();
            return View("Index", vuelos);
        }
    }

}
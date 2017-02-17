using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PointJalkahoitoDemoEka.Models;

namespace PointJalkahoitoDemoEka.Controllers
{
    public class HoitopaikkaController : Controller
    {
        private kauppeedbEntities db = new kauppeedbEntities();

        // GET: Hoitopaikka
        public ActionResult Index()
        {
            var hoitopaikka = db.Hoitopaikka.Include(h => h.Toimipiste).Include(h => h.Varaus);
            return View(hoitopaikka.ToList());
        }

        // GET: Hoitopaikka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitopaikka hoitopaikka = db.Hoitopaikka.Find(id);
            if (hoitopaikka == null)
            {
                return HttpNotFound();
            }
            return View(hoitopaikka);
        }

        // GET: Hoitopaikka/Create
        public ActionResult Create()
        {
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi");
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi");
            return View();
        }

        // POST: Hoitopaikka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Hoitopaikka_id,Hoitopaikan_Nimi,Hoitopaikan_Numero,Toimipiste_id,Varaus_id")] Hoitopaikka hoitopaikka)
        {
            if (ModelState.IsValid)
            {
                db.Hoitopaikka.Add(hoitopaikka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", hoitopaikka.Toimipiste_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi", hoitopaikka.Varaus_id);
            return View(hoitopaikka);
        }

        // GET: Hoitopaikka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitopaikka hoitopaikka = db.Hoitopaikka.Find(id);
            if (hoitopaikka == null)
            {
                return HttpNotFound();
            }
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", hoitopaikka.Toimipiste_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi", hoitopaikka.Varaus_id);
            return View(hoitopaikka);
        }

        // POST: Hoitopaikka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Hoitopaikka_id,Hoitopaikan_Nimi,Hoitopaikan_Numero,Toimipiste_id,Varaus_id")] Hoitopaikka hoitopaikka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoitopaikka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", hoitopaikka.Toimipiste_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi", hoitopaikka.Varaus_id);
            return View(hoitopaikka);
        }

        // GET: Hoitopaikka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoitopaikka hoitopaikka = db.Hoitopaikka.Find(id);
            if (hoitopaikka == null)
            {
                return HttpNotFound();
            }
            return View(hoitopaikka);
        }

        // POST: Hoitopaikka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hoitopaikka hoitopaikka = db.Hoitopaikka.Find(id);
            db.Hoitopaikka.Remove(hoitopaikka);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

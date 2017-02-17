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
    public class PalveluController : Controller
    {
        private kauppeedbEntities db = new kauppeedbEntities();

        // GET: Palvelu
        public ActionResult Index()
        {
            var palvelu = db.Palvelu.Include(p => p.Asiakas1).Include(p => p.Hoitaja1).Include(p => p.Toimipiste).Include(p => p.Varaus);
            return View(palvelu.ToList());
        }

        // GET: Palvelu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palvelu palvelu = db.Palvelu.Find(id);
            if (palvelu == null)
            {
                return HttpNotFound();
            }
            return View(palvelu);
        }

        // GET: Palvelu/Create
        public ActionResult Create()
        {
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi");
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi");
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi");
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi");
            return View();
        }

        // POST: Palvelu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Palvelu_id,Palvelun_Nimi,Palvelun_Kesto,Palvelun_Hinta,Asiakas_id,Hoitaja_id,Toimipiste_id,Varaus_id")] Palvelu palvelu)
        {
            if (ModelState.IsValid)
            {
                db.Palvelu.Add(palvelu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", palvelu.Asiakas_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", palvelu.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", palvelu.Toimipiste_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi", palvelu.Varaus_id);
            return View(palvelu);
        }

        // GET: Palvelu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palvelu palvelu = db.Palvelu.Find(id);
            if (palvelu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", palvelu.Asiakas_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", palvelu.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", palvelu.Toimipiste_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi", palvelu.Varaus_id);
            return View(palvelu);
        }

        // POST: Palvelu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Palvelu_id,Palvelun_Nimi,Palvelun_Kesto,Palvelun_Hinta,Asiakas_id,Hoitaja_id,Toimipiste_id,Varaus_id")] Palvelu palvelu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palvelu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asiakas_id = new SelectList(db.Asiakas, "Asiakas_id", "Etunimi", palvelu.Asiakas_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", palvelu.Hoitaja_id);
            ViewBag.Toimipiste_id = new SelectList(db.Toimipiste, "Toimipiste_id", "Toimipiste_Nimi", palvelu.Toimipiste_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi", palvelu.Varaus_id);
            return View(palvelu);
        }

        // GET: Palvelu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palvelu palvelu = db.Palvelu.Find(id);
            if (palvelu == null)
            {
                return HttpNotFound();
            }
            return View(palvelu);
        }

        // POST: Palvelu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Palvelu palvelu = db.Palvelu.Find(id);
            db.Palvelu.Remove(palvelu);
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

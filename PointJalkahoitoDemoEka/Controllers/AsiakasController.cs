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
    public class AsiakasController : Controller
    {
        private kauppeedbEntities db = new kauppeedbEntities();

        // GET: Asiakas
        public ActionResult Index()
        {
            var asiakas = db.Asiakas.Include(a => a.Osoite).Include(a => a.Puhelin).Include(a => a.Hoitaja).Include(a => a.Varaus).Include(a => a.Palvelu).Include(a => a.Kayttaja);
            //Lisäys
            List<Puhelin> puhelin = db.Puhelin.ToList();
            //PuhelinnakymaModel puhelinnakyma = new PuhelinnakymaModel();

            //Loppu
            return View(asiakas.ToList());
        }

  

        // GET: Asiakas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakas asiakas = db.Asiakas.Find(id);
            if (asiakas == null)
            {
                return HttpNotFound();
            }
            return View(asiakas);
        }

        // GET: Asiakas/Create
        public ActionResult Create()
        {
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite");
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1");
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi");
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi");
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi");
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Asiakas_id,Etunimi,Sukunimi,Henkilotunnus,Huomiot,Sahkoposti,Käyttäjä_id,Osoite_id,Puhelin_id,Puhelinnumero,Hoitaja_id,Varaus_id,Palvelu_id")] Asiakas asiakas)
        {
            if (ModelState.IsValid)
            {
                db.Asiakas.Add(asiakas);
               // db.SaveChanges();

                int viimeisinAsiakas_id = asiakas.Asiakas_id;

                Puhelin puhelin = new Puhelin();
                //puhelin.Puhelinnumero_1 = asiakas.Puhelinnumero;
                puhelin.Asiakas_id = viimeisinAsiakas_id;

                db.Puhelin.Add(puhelin);
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", asiakas.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", asiakas.Puhelin_id);
            ViewBag.Puhelinnumero_1 = new SelectList(db.Puhelin, "Puhelinnumero_1", "Puhelinnumero_1", asiakas.Puhelin_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", asiakas.Hoitaja_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi", asiakas.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", asiakas.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", asiakas.Käyttäjä_id);


            return View(asiakas);
        }


        //[HttpPost]
        //public ActionResult Index(PointJalkahoitoDemoEka.Models.Asiakas model)
        ////public ActionResult Index(PointJalkahoitoDemoEka.Models.Asiakas model)
        //{
        //    kauppeedbEntities db = new kauppeedbEntities();
        //    //List<Asiakas> lista = db.Asiakas.ToList();
        //    //ViewBag.Asiakaslista = new SelectList(lista, "Asiakas_id", "Etunimi");

        //    Asiakas asiakas = new Asiakas();
        //    asiakas.Etunimi = model.Etunimi;
        //    asiakas.Sukunimi = model.Sukunimi;
        //    asiakas.Henkilotunnus = model.Henkilotunnus;

        //    int viimeisinAsiakas_id = asiakas.Asiakas_id;

        //    Puhelin puhelin = new Puhelin();
        //    //puhelin.Puhelinnumero_1 = model.Puhelin1;
        //    puhelin.Asiakas_id = viimeisinAsiakas_id;

        //    db.Puhelin.Add(puhelin);
        //    db.SaveChanges();



        //    return View(model);
        //}

        // POST: Asiakas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Asiakas_id,Etunimi,Sukunimi,Henkilotunnus,Huomiot,Sahkoposti,Käyttäjä_id,Osoite_id,Puhelin_id,Hoitaja_id,Varaus_id,Palvelu_id")] Asiakas asiakas)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Asiakas.Add(asiakas);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", asiakas.Osoite_id);
        //    ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", asiakas.Puhelin_id);
        //    ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", asiakas.Hoitaja_id);
        //    ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi", asiakas.Varaus_id);
        //    ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", asiakas.Palvelu_id);
        //    ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", asiakas.Käyttäjä_id);


        //    return View(asiakas);
        //}

        // GET: Asiakas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakas asiakas = db.Asiakas.Find(id);
            if (asiakas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", asiakas.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", asiakas.Puhelin_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", asiakas.Hoitaja_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi", asiakas.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", asiakas.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", asiakas.Käyttäjä_id);
            return View(asiakas);
        }

        // POST: Asiakas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Asiakas_id,Etunimi,Sukunimi,Henkilotunnus,Huomiot,Sahkoposti,Käyttäjä_id,Osoite_id,Puhelin_id,Hoitaja_id,Varaus_id,Palvelu_id")] Asiakas asiakas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiakas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Osoite_id = new SelectList(db.Osoite, "Osoite_id", "Katuosoite", asiakas.Osoite_id);
            ViewBag.Puhelin_id = new SelectList(db.Puhelin, "Puhelin_id", "Puhelinnumero_1", asiakas.Puhelin_id);
            ViewBag.Hoitaja_id = new SelectList(db.Hoitaja, "Hoitaja_id", "Etunimi", asiakas.Hoitaja_id);
            ViewBag.Varaus_id = new SelectList(db.Varaus, "Varaus_id", "Palvelun_nimi", asiakas.Varaus_id);
            ViewBag.Palvelu_id = new SelectList(db.Palvelu, "Palvelu_id", "Palvelun_Nimi", asiakas.Palvelu_id);
            ViewBag.Käyttäjä_id = new SelectList(db.Kayttaja, "Käyttäjä_id", "Käyttäjätunnus", asiakas.Käyttäjä_id);
            return View(asiakas);
        }

        // GET: Asiakas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiakas asiakas = db.Asiakas.Find(id);
            if (asiakas == null)
            {
                return HttpNotFound();
            }
            return View(asiakas);
        }

        // POST: Asiakas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asiakas asiakas = db.Asiakas.Find(id);
            db.Asiakas.Remove(asiakas);
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

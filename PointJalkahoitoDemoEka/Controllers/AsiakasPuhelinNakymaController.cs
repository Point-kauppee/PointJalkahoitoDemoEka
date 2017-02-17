using PointJalkahoitoDemoEka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointJalkahoitoDemoEka.Controllers
{
    public class AsiakasPuhelinNakymaController : Controller
    {
        // GET: AsiakasPuhelinNakyma
        public ActionResult Index()
        {
            kauppeedbEntities db = new kauppeedbEntities();

            List<Asiakas> asiakaslista = db.Asiakas.ToList();

            //AsiakasPuhelinNakyma pn = new AsiakasPuhelinNakyma();

            List<AsiakasPuhelinNakyma> asiakasPuhelinnakymaLista = asiakaslista.Select(x => new AsiakasPuhelinNakyma
            { Asiakas_id = x.Asiakas_id,
                Etunimi = x.Etunimi,
                Sukunimi = x.Sukunimi,
                Henkilotunnus = x.Henkilotunnus,
                Puhelin_id = x.Puhelin_id,
                Puhelinnumero_1 =x.Puhelin.Puhelinnumero_1 }).ToList();

            //osa 1
            //Asiakas asiakas = db.Asiakas.SingleOrDefault(x => x.Asiakas_id == 1);

            //AsiakasPuhelinNakyma pn = new AsiakasPuhelinNakyma();

            //pn.Asiakas_id = asiakas.Asiakas_id;
            //pn.Puhelin_id = asiakas.Puhelin_id;
            //pn.Etunimi = asiakas.Etunimi;
            //pn.Sukunimi = asiakas.Sukunimi;
            //pn.Henkilotunnus = asiakas.Henkilotunnus;




            //return View(pn);
            return View(asiakasPuhelinnakymaLista);
        }

        public ActionResult AsiakasInfo(int? Asiakas_id)
        {
            kauppeedbEntities db = new kauppeedbEntities();
            Asiakas asiakas = db.Asiakas.SingleOrDefault(x => x.Asiakas_id == Asiakas_id);

            AsiakasPuhelinNakyma asiakasNakyma = new AsiakasPuhelinNakyma();

            asiakasNakyma.Asiakas_id = asiakas.Asiakas_id;
            asiakasNakyma.Etunimi = asiakas.Etunimi;
            asiakasNakyma.Sukunimi = asiakas.Sukunimi;
            asiakasNakyma.Henkilotunnus = asiakas.Henkilotunnus;
            asiakasNakyma.Puhelinnumero_1 = asiakas.Puhelin.Puhelinnumero_1;


            return View(asiakasNakyma);
        }
        public ActionResult Asiakaslomake()
        {
            kauppeedbEntities db = new kauppeedbEntities();

            List<Asiakas> asiakaslista = db.Asiakas.ToList();
            ViewBag.Asiakaslistaus = new SelectList(asiakaslista, "Asiakas_id", "Etunimi");

            return View();

        }

        [HttpPost]
        public ActionResult Asiakaslomake(AsiakasPuhelinNakyma model)
        {
            kauppeedbEntities db = new kauppeedbEntities();

            List<Asiakas> asiakaslista = db.Asiakas.ToList();
            ViewBag.Asiakaslistaus = new SelectList(asiakaslista, "Asiakas_id", "Etunimi");

            Asiakas asiakas = new Asiakas();
            asiakas.Etunimi = model.Etunimi;
            asiakas.Sukunimi = model.Sukunimi;
            asiakas.Henkilotunnus = model.Henkilotunnus;

            db.Asiakas.Add(asiakas);
            db.SaveChanges();

            int viimeisinId = asiakas.Asiakas_id;

            Puhelin puhelin = new Puhelin();
            puhelin.Asiakas_id = viimeisinId;
            puhelin.Puhelinnumero_1 = model.Puhelinnumero_1;

            db.Puhelin.Add(puhelin);
            db.SaveChanges();


            return View(model);
        }

        public ActionResult Rekisterointi()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Rekisteroikayttaja(RekisterointiViewModel model)
        {
            kauppeedbEntities db = new kauppeedbEntities();

            Kayttaja kayttaja = new Kayttaja();
            kayttaja.Käyttäjätunnus = model.Käyttäjätunnus;
            kayttaja.Salasana = model.Salasana;
            kayttaja.Rooli_id = 3;

            db.Kayttaja.Add(kayttaja);
            db.SaveChanges();

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        //[HttpPost]
        //public JsonResult Kayttajansisaankirjaus(RekisterointiViewModel model)
        //{
        //    kauppeedbEntities db = new kauppeedbEntities();
        //    Kayttaja kayttaja = db.Kayttaja.SingleOrDefault(x => x.Käyttäjä_id == model.Käyttäjä_id && x.Käyttäjätunnus == model.Käyttäjätunnus);
        //    //string result = "fail";
        //    if (kayttaja != null)
        //    {
        //        Session["käyttäjä_id"] = kayttaja.Käyttäjä_id;
        //        Session["käyttäjätunnus"] = kayttaja.Käyttäjätunnus;
        //        if(kayttaja.Rooli_id == 3)
        //        {
        //            result = "Normaalikäyttäjä";
        //        }
        //        else if (kayttaja.Rooli_id == 1)
        //        {
        //            result = "Pääkäyttäjä";
        //        }

        //    }

        //    return Json("result",JsonRequestBehavior.AllowGet);
        //}
    }
}
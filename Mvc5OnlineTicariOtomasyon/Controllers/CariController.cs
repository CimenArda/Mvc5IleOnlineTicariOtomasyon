using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context db = new Context();

        public ActionResult Index()
        {
            var cariler =db.Caris.Where(x=>x.CariDurum==true).ToList();
            return View(cariler);
        }

        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari k)
        {
            db.Caris.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CariSil(int id)
        {
            var Cariyibul = db.Caris.Find(id);

            Cariyibul.CariDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CariGuncelle(int id)
        {
            var Cari = db.Caris.Find(id);
            return View("CariGuncelle", Cari);
        }

        [HttpPost]
        public ActionResult CariGuncelle(Cari d)
        {
            var Cari = db.Caris.Find(d.CariID);

            Cari.CariAd = d.CariAd;
            Cari.CariDurum = d.CariDurum;
            Cari.CariSoyad = d.CariSoyad;
            Cari.CariSehir = d.CariSehir;
            Cari.CariMail = d.CariMail;
            db.SaveChanges();
            return RedirectToAction("Index");


        }


        public ActionResult MusteriAlis(int id)
        {
            var degerler = db.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cariad = db.SatisHarekets.Where(x => x.Cariid == id).Select(y => y.Caris.CariAd +" "+ y.Caris.CariSoyad).FirstOrDefault();

            ViewBag.cariad = cariad;
            return View(degerler);
        }

    }
}
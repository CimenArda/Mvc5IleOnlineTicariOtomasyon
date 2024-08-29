using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context db = new Context();
        public ActionResult Index(int sayfa =1)
        {
            var kategoriler = db.Kategoris.ToList().ToPagedList(sayfa, 4);
            
            return View(kategoriler);
        }


        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            db.Kategoris.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KategoriSil(int id)
        {
            var kategoriyibul = db.Kategoris.Find(id);
            db.Kategoris.Remove(kategoriyibul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var kategoriyibul = db.Kategoris.Find(id);

            return View("KategoriGuncelle",kategoriyibul);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kategoriyibul = db.Kategoris.Find(k.KategoriID);

            kategoriyibul.KategoriAd = k.KategoriAd;

            db.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult Deneme()
        {
            Class3 cs = new Class3();

            cs.Kategoriler = new SelectList(db.Kategoris, "KategoriID", "KategoriAd");

            cs.Urunler = new SelectList(db.Uruns, "UrunID", "UrunAd");

            return View(cs);
        }

        public JsonResult UrunGetir(int p)
        {
            var urunListesi = (from x in db.Uruns
                               join y in db.Kategoris
                               on x.Kategoriid equals y.KategoriID
                               where x.Kategoriid == p
                               select new {

                                   Text = x.UrunAd,
                                   Value = x.UrunID.ToString()


                               }).ToList();

            return Json(urunListesi,JsonRequestBehavior.AllowGet);                 
                                 
                              
        }
    }
}
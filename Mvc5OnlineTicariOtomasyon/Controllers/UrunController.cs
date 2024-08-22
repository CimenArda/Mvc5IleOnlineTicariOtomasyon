using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context db = new Context();

        public ActionResult Index(string p)
        {
            var urunler = (from x in db.Uruns select x);
            if (!string.IsNullOrEmpty(p))
            {
                urunler =urunler.Where(y=>y.UrunAd.Contains(p));

            }
            return View(urunler.ToList());
        }


        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger = (from x in db.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriID.ToString()

                                          }).ToList();

            ViewBag.deger = deger;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            db.Uruns.Add(u);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = db.Uruns.Find(id);
            urun.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGuncelle(int id)
        {
            var urun = db.Uruns.Find(id);
            List<SelectListItem> deger = (from x in db.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriID.ToString()

                                          }).ToList();

            ViewBag.deger = deger;

            return View("UrunGuncelle", urun);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(Urun u)
        {
            var urun = db.Uruns.Find(u.UrunID);

            urun.UrunAd = u.UrunAd;
            urun.Marka = u.Marka;
            urun.Stok = u.Stok;
            urun.AlisFiyat = u.AlisFiyat;
            urun.SatisFiyat = u.SatisFiyat;
            urun.UrunGorsel = u.UrunGorsel;
            urun.Durum = u.Durum;

            urun.Kategoriid = u.Kategoriid;

            
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunListesi()
        {
            var degerler =db.Uruns.ToList();

            return View(degerler);
        }

    }
}
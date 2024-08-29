using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class SatışController : Controller
    {
        // GET: Satış
        Context db = new Context();

        public ActionResult Index()
        {
            var degerler =db.SatisHarekets.ToList();
            return View(degerler);
        }

        public ActionResult SatışEkle()
        {
            List<SelectListItem> deger = (from x in db.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunID.ToString()

                                          }).ToList();

            ViewBag.deger = deger;

            List<SelectListItem> deger1 = (from x in db.Personels.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.PersonelAd + " " +x.PersonelSoyad,
                                              Value = x.PersonelID.ToString()

                                          }).ToList();

            ViewBag.deger1 = deger1;

            List<SelectListItem> deger2 = (from x in db.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd+ " " +x.CariSoyad,
                                               Value = x.CariID.ToString()

                                           }).ToList();

            ViewBag.deger2 = deger2;

            return View();
        }

        [HttpPost]
        public ActionResult SatışEkle(SatisHareket s )
        {
            s.Tarih =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SatisHarekets.Add(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult SatışGuncelle(int id)
        {
            List<SelectListItem> deger = (from x in db.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunID.ToString()

                                          }).ToList();

            ViewBag.deger = deger;

            List<SelectListItem> deger1 = (from x in db.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()

                                           }).ToList();

            ViewBag.deger1 = deger1;

            List<SelectListItem> deger2 = (from x in db.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()

                                           }).ToList();

            ViewBag.deger2 = deger2;

            var satis = db.SatisHarekets.Find(id);
            return View(satis);
        }

        [HttpPost]
        public ActionResult SatışGuncelle(SatisHareket s)
        {
            var satis = db.SatisHarekets.Find(s.SatisHareketID);

            satis.Cariid = s.Cariid;
            satis.Personelid = s.Personelid;
            satis.Urunid = s.Urunid;
            satis.Adet = s.Adet;
            satis.Fiyat = s.Fiyat;
            satis.ToplamTutar = s.ToplamTutar;



            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = db.SatisHarekets.Where(x => x.SatisHareketID == id).ToList();
            return View(degerler);
        }


    }
}
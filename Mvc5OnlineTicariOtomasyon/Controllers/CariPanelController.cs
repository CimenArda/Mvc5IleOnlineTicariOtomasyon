using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context db = new Context();

        public ActionResult Index()
        {
            var cariMail = (string)Session["CariMail"];


            var degerler = db.Mesajlars.Where(x => x.Alıcı == cariMail).ToList();

            ViewBag.CariMail = cariMail;

            var mailid = db.Caris.Where(x => x.CariMail == cariMail).Select(y => y.CariID).FirstOrDefault();

            ViewBag.mailid = mailid;



            var toplamsatis = db.SatisHarekets.Where(x => x.Cariid == mailid).Count().ToString();
            ViewBag.toplamsatis = toplamsatis;


            var toplamTutar = db.SatisHarekets.Where(x => x.Cariid == mailid).Sum(y => y.ToplamTutar).ToString();
            ViewBag.toplamTutar = toplamTutar;

            var toplamUrunSayisi = db.SatisHarekets.Where(x => x.Cariid == mailid).Sum(y => y.Adet).ToString();
            ViewBag.toplamUrunSayisi = toplamUrunSayisi;


            var adsoyad = db.Caris.Where(x => x.CariMail == cariMail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            var sehir = db.Caris.Where(x => x.CariMail == cariMail).Select(y => y.CariSehir).FirstOrDefault();
            ViewBag.sehir = sehir;



            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var cariMail = (string)Session["CariMail"];
            var id = db.Caris.Where(x => x.CariMail == cariMail.ToString()).Select(y => y.CariID).FirstOrDefault();

            var degerler = db.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);


        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var gelenmesajlar = db.Mesajlars.Where(x => x.Alıcı == mail).OrderByDescending(x => x.MesajID).ToList();


            var gelenMesajSayi = db.Mesajlars.Count(x => x.Alıcı == mail);
            ViewBag.gelenMesajSayi = gelenMesajSayi;



            return View(gelenmesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var gelenmesajlar = db.Mesajlars.Where(x => x.Gonderici == mail).ToList();



            var gonderilenMesajSayi = db.Mesajlars.Count(x => x.Gonderici == mail);
            ViewBag.gonderilenMesajSayi = gonderilenMesajSayi;

            return View(gelenmesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var mail = (string)Session["CariMail"];


            var mesajlar = db.Mesajlars.Where(x => x.MesajID == id).ToList();


            var gelenMesajSayi = db.Mesajlars.Count(x => x.Alıcı == mail);
            ViewBag.gelenMesajSayi = gelenMesajSayi;
            var gonderilenMesajSayi = db.Mesajlars.Count(x => x.Gonderici == mail);
            ViewBag.gonderilenMesajSayi = gonderilenMesajSayi;




            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Gonderici = mail;
            m.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.Mesajlars.Add(m);
            db.SaveChanges();
            return View();
        }


        public ActionResult KargoTakip(string p)
        {
            var kargo = (from x in db.KargoDetays select x);
            kargo = kargo.Where(y => y.TakipKodu.Contains(p));

            return View(kargo.ToList());
        }


        public ActionResult KargoDetay(string id)
        {
            var degerler = db.KargoTakips.Where(x => x.TakipKodu == id).ToList();


            return View(degerler);
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }




        public PartialViewResult Partial1()
        {
            var cariMail = (string)Session["CariMail"];


            var id = db.Caris.Where(x => x.CariMail == cariMail).Select(y => y.CariID).FirstOrDefault();

            var caribul = db.Caris.Find(id);

            return PartialView("Partial1", caribul);
        }
        [HttpPost]
        public ActionResult CariBilgiGuncelle(Cari c)
        {
            var cariMail = (string)Session["CariMail"];


            var id = db.Caris.Where(x => x.CariMail == cariMail).Select(y => y.CariID).FirstOrDefault();

            var caribul = db.Caris.Find(id);

            caribul.CariAd = c.CariAd;
            caribul.CariSoyad = c.CariSoyad;
            caribul.CariSehir = c.CariSehir;
            caribul.CariMail = c.CariMail;
            caribul.Sifre = c.Sifre;


            db.SaveChanges();

            return RedirectToAction("Index", "CariPanel");
        }




        public PartialViewResult Partial2()
        {
            var veriler = db.Mesajlars.Where(x => x.Gonderici == "Admin").ToList();
            return PartialView(veriler);
        }
    }
}
using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context db = new Context();

        public ActionResult Index()
        {
            var toplamcari = db.Caris.Count();
            ViewBag.toplamcari = toplamcari;

            var toplamurun = db.Uruns.Count();
            ViewBag.toplamurun = toplamurun;



            var toplampersonel =db.Personels.Count();
            ViewBag.toplampersonel=toplampersonel;


            var toplamkategori =db.Kategoris.Count();
            ViewBag.toplamkategori=toplamkategori;

            var toplamstok = db.Uruns.Sum(x => x.Stok);
            ViewBag.toplamstok = toplamstok;

            var toplammarka = db.Uruns.GroupBy(x=>x.Marka).Count();
            ViewBag.toplammarka =toplammarka;

            var kritikseviye = db.Uruns.Count(x => x.Stok <= 20);
            ViewBag.kritikseviye =kritikseviye;


            var maxfiyatliurun =(from x in db.Uruns orderby x.SatisFiyat descending  select x.UrunAd).FirstOrDefault();
            ViewBag.maxfiyatliurun = maxfiyatliurun;

            var minfiyatliurun = (from x in db.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.minfiyatliurun =minfiyatliurun;


            var buzdolabısayi = db.Uruns.Count(x => x.UrunAd == "Buzdolabı");
            var laptopsayi = db.Uruns.Count(x => x.UrunAd == "Laptop");
            ViewBag.buzdolabısayi = buzdolabısayi;
            ViewBag.laptopsayi = laptopsayi;


            var kasatutar = db.SatisHarekets.Sum(x => x.ToplamTutar);
            ViewBag.kasatutar = kasatutar;


            DateTime bugün = DateTime.Today;
            var bugünsatis = db.SatisHarekets.Count(x => x.Tarih == bugün);
            ViewBag.bugünsatis = bugünsatis;

            var bugünkasa = db.SatisHarekets.Where(x=>x.Tarih ==bugün).Sum(y=>y.ToplamTutar).ToString();
            ViewBag.bugünkasa = bugünkasa;



            var maxmarka = db.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.maxmarka = maxmarka;


            var encoksatan = db.Uruns.Where(u => u.UrunID == (db.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.encoksatan = encoksatan;





            return View();
        }
    }
}
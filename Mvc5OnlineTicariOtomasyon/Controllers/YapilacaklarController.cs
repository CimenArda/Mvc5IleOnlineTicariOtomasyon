using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class YapilacaklarController : Controller
    {
        // GET: Yapilacaklar
        Context db = new Context();

        public ActionResult Index()
        {
            var cariler = db.Caris.Count();
            var urunler = db.Uruns.Count();
            var kategori = db.Kategoris.Count();
            var personel = db.Personels.Count();    


            ViewBag.cariler = cariler;
            ViewBag.urunler = urunler;
            ViewBag.kategori = kategori;
            ViewBag.personel = personel;


            var yapilacaklar =db.Yapilacaklars.ToList();
            return View(yapilacaklar);
        }
    }
}
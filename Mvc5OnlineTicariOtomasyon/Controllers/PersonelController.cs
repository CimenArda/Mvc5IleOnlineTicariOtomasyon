using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context db = new Context();

        public ActionResult Index()
        {
            var degerler =db.Personels.ToList();
            return View(degerler);
        }

        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger = (from x in db.Departmans.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanID.ToString()

                                          }).ToList();

            ViewBag.deger = deger;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel u)
        {
            db.Personels.Add(u);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult PersonelGuncelle(int id)
        {
            var Personel = db.Personels.Find(id);
            List<SelectListItem> deger = (from x in db.Departmans.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanID.ToString()

                                          }).ToList();

            ViewBag.deger = deger;

            return View("PersonelGuncelle", Personel);
        }

        [HttpPost]
        public ActionResult PersonelGuncelle(Personel u)
        {
            var p = db.Personels.Find(u.PersonelID);

            p.PersonelAd = u.PersonelAd;
            p.PersonelSoyad = u.PersonelSoyad;
            p.PersonelGorsel = u.PersonelGorsel;

            p.Departmanid = u.Departmanid;
    

            db.SaveChanges();
            return RedirectToAction("Index");

        }



        public ActionResult PersonelDetaylıListesi()
        {
            var personeller = db.Personels.ToList();
            return View(personeller);
        }







    }
}
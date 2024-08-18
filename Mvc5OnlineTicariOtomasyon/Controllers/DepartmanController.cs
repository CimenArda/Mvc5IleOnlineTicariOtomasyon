using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context db = new Context();

        public ActionResult Index()
        {
            var departmanlar = db.Departmans.Where(x=>x.Durum).ToList();
            return View(departmanlar);
        }


        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            db.Departmans.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult DepartmanSil(int id)
        {
            var dep = db.Departmans.Find(id);
            dep.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DepartmanGuncelle(int id)
        {
            var departman = db.Departmans.Find(id);
            return View("DepartmanGuncelle", departman);
        }

        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var departman = db.Departmans.Find(d.DepartmanID);

            departman.DepartmanAd=d.DepartmanAd;
            departman.Durum = d.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler =db.Personels.Where(x=>x.Departmanid==id).ToList();

            var dpt = db.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.departmanad = dpt;


            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler =db.SatisHarekets.Where(x=>x.Personelid==id).ToList();

            var personelad = db.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + y.PersonelSoyad).FirstOrDefault();
            ViewBag.departmanPersonel = personelad;    
            return View(degerler);

        }




    }
}
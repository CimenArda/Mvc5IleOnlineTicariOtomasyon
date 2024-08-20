using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context db = new Context();

        public ActionResult Index()
        {
            var faturalar =db.Faturas.ToList();
            return View(faturalar);
        }


        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
            db.Faturas.Add(f);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult FaturaGuncelle(int id)
        {
            var fatura = db.Faturas.Find(id);
            return View("FaturaGuncelle",fatura);
        }

        [HttpPost]
        public ActionResult FaturaGuncelle(Fatura f)
        {

            var fatura = db.Faturas.Find(f.FaturaID);

            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.Tarih =f.Tarih;
            fatura.Saat =f.Saat;
            fatura.Toplam =f.Toplam;
            fatura.TeslimAlan =f.TeslimAlan;
            fatura.TeslimEden =f.TeslimEden;
            fatura.VergiDairesi =f.VergiDairesi;

            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult FaturaDetay(int id)
        {
            var degerler = db.faturaKalems.Where(x => x.Faturaid == id).ToList();

            var sırano = db.Faturas.Where(x => x.FaturaID == id).Select(y => y.FaturaSıraNo).FirstOrDefault();
            ViewBag.FaturaSırano = sırano;
            return View(degerler);
        }

        public ActionResult FaturaKalemEkle()
        {
            List<SelectListItem> deger = (from x in db.Faturas.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.FaturaSıraNo,
                                              Value = x.FaturaID.ToString()

                                          }).ToList();

            ViewBag.deger = deger;
            return View();
        }

        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem fk)
        {
            db.faturaKalems.Add(fk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
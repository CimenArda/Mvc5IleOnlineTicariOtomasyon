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



        public ActionResult Dinamik()
        {
            Class4 cs =new Class4();
            cs.Fatura = db.Faturas.ToList();
            cs.faturaKalem = db.faturaKalems.ToList();
            return View(cs);
        }


        public ActionResult FaturaKaydet(string FaturaSeriNo,string FaturaSıraNo, DateTime tarih,string VergiDairesi,string Saat,string TeslimEden,string TeslimAlan,string Toplam, FaturaKalem[] kalemler)
        {
            Fatura f = new Fatura();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSıraNo = FaturaSıraNo;
            f.Tarih = tarih;
            f.VergiDairesi = VergiDairesi;
            f.Saat = Saat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.Toplam =Decimal.Parse(Toplam);

            db.Faturas.Add(f);

            foreach (var item in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama =item.Aciklama;
                fk.BirimFiyat = item.BirimFiyat;
                fk.Faturaid = item.Faturaid;
                fk.Miktar = item.Miktar;
                fk.Tutar = item.Tutar;
                db.faturaKalems.Add(fk);
            }
            db.SaveChanges();

            return Json("İşlem Başarılı");
        }

    }
}
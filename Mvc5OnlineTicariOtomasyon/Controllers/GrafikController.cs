using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context db = new Context();

        public ActionResult Index()
        {
            //view üzerinde chart olusturma

            return View();
        }

        public ActionResult Index2()
        {
            var grafikciz = new Chart(width: 600, height: 600);
            grafikciz.AddTitle("Kategori-Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Beyaz Eşya", "Küçük Ev Aleti", "Teknoloji", "Ofis Eşyaları" },yValues: new[]{56,59,123,23}).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "Image/jpeg");

            //controller üzerinde chart olusturma

        }

        public ActionResult Index3()
        {
            //veritabanı üzerinden chart olusturm
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();

            var sonuclar = db.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));

            sonuclar.ToList().ForEach(x => yvalue.Add(x.Stok));

            var grafik = new Chart(width: 500, height: 500).AddTitle("Ürün-Stok Sayısı").AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);

            return File(grafik.ToWebImage().GetBytes(), "Image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult()
        {
            return Json(urunListesi(), JsonRequestBehavior.AllowGet);
           
        }

        public List<Sinif1> urunListesi()
        {
            List<Sinif1> snf = new List<Sinif1>();
            snf.Add(new Sinif1()
            {
                urunad = "Laptop",
                stok = 120
            });
            snf.Add(new Sinif1()
            {
                urunad = "Su Isıtıcı",
                stok = 141
            });
            snf.Add(new Sinif1()
            {
                urunad = "Buzdolabı",
                stok = 45
            });
            snf.Add(new Sinif1()
            {
                urunad = "Tablet",
                stok = 55
            });

            return snf;
        }





        public ActionResult Index5()
        {
            return View();
        }


        public ActionResult VisualizeUrunResult2()
        {
            return Json(urunListesi2(), JsonRequestBehavior.AllowGet);

        }

        public List<Sinif2> urunListesi2()
        {
            List<Sinif2> snf = new List<Sinif2>();
            using (var db = new Context())
            {
                snf = db.Uruns.Select(x => new Sinif2
                {
                    urn = x.UrunAd,
                    stk = x.Stok
                }).ToList();
            }

            return snf;
        }



































    }
}
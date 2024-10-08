﻿using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class KargoController : Controller
    {
        Context db = new Context();
        // GET: Kargo
        public ActionResult Index(string p)
        {
            var kargo = (from x in db.KargoDetays select x);
            if (!string.IsNullOrEmpty(p))
            {
                kargo = kargo.Where(y => y.TakipKodu.Contains(p));

            }
            return View(kargo.ToList());
        }


        public ActionResult KargoEkle()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);

            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);

            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod = kod;
            return View();
        }

        [HttpPost]
        public ActionResult KargoEkle(KargoDetay d)
        {
            db.KargoDetays.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KargoTakip(string id)
        {
            var degerler = db.KargoTakips.Where(x => x.TakipKodu == id).ToList();


         


            return View(degerler);
        }

    }
}
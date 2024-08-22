using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc5OnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context db = new Context();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult KayitOl()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult KayitOl(Cari c)
        {
            db.Caris.Add(c);
            db.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CariGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariGiris(Cari c)
        {
            var bilgi =db.Caris.FirstOrDefault(x=>x.CariMail==c.CariMail && x.Sifre ==c.Sifre);
            if (bilgi !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.CariMail, false);

                Session["CariMail"] = bilgi.CariMail.ToString();
                return RedirectToAction("Index","CariPanel");   

            }
            return RedirectToAction("Index", "Login");
        }


    }
}
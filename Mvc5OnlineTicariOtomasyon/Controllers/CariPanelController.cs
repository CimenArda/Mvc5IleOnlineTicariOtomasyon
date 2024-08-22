using Mvc5OnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var degerler =db.Caris.FirstOrDefault(x=>x.CariMail == cariMail);

            ViewBag.CariMail = cariMail;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var cariMail = (string)Session["CariMail"];
            var id =db.Caris.Where(x=>x.CariMail ==cariMail.ToString()).Select(y=>y.CariID).FirstOrDefault();

            var degerler =db.SatisHarekets.Where(x=>x.Cariid==id).ToList();
            return View(degerler);
        }


    }
}
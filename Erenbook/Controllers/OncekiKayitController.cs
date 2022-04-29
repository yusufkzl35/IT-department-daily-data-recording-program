using Erenbook.Login;
using Erenbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Erenbook.Controllers
{
    [LoginFilter]
    public class OncekiKayitController : Controller
    {
        // GET: OncekiKayit
        EREN db = new EREN();
        public ActionResult Index(string aranan = null)
        {
            var t = from x in db.EskiProgramKayitis select x;
            if (!String.IsNullOrEmpty(aranan))
            {
                t = db.EskiProgramKayitis.Where(kayit => kayit.AdSoyad.Contains(aranan) || kayit.Donanım.Contains(aranan) || kayit.TarihBaslangic.Contains(aranan));

            }
            return View(t.OrderByDescending(kayit => kayit.id).ToList());
        }
    }
}
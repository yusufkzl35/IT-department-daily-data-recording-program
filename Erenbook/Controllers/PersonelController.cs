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
    public class PersonelController : Controller
    {
        // GET: Personel
        EREN db = new EREN();
        public ActionResult Index(string aranan=null)
        {
            var t = from x in db.Personels select x;
            if (!String.IsNullOrEmpty(aranan))
            {
                t = db.Personels.Where(kayit => kayit.Adi.Contains(aranan) || kayit.Soyadi.Contains(aranan) );

            }
            return View(t.OrderByDescending(kayit => kayit.id).ToList());
        }

        public ActionResult ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ekle(Personel kayit)
        {
            db.Personels.Add(kayit);
            db.SaveChanges();
            return RedirectToActionPermanent("Index");
        }
        public ActionResult guncelle(int id = 0)
        {
           Personel kayit = db.Personels.Find(id);
            return View(kayit);
        }
        [HttpPost]
        public ActionResult guncelle(Personel kayit)
        {
            db.Entry(kayit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
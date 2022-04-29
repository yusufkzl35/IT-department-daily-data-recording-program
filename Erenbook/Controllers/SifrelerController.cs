using Erenbook.Models;
using Erenbook.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Erenbook.Controllers
{
    [LoginFilter]
    public class SifrelerController : Controller
    {
       
        EREN db = new EREN();
        public ActionResult Index(string aranan = null)
        {
            var t = from x in db.Sifrelers select x;
            if (!String.IsNullOrEmpty(aranan))
            {
                t = db.Sifrelers.Where(kayit => kayit.Birim.Contains(aranan) );

            }
            return View(t.OrderByDescending(kayit => kayit.id).ToList());
        }

        public ActionResult ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ekle(Sifreler kayit)
        {
            db.Sifrelers.Add(kayit);
            db.SaveChanges();
            return RedirectToActionPermanent("Index");
        }

        public ActionResult guncelle(int id = 0)
        {
            Sifreler kayit = db.Sifrelers.Find(id);
            return View(kayit);

        }

        [HttpPost]
        public ActionResult guncelle(Sifreler kayit)
        {
            db.Entry(kayit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }

    

}
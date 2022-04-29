using Erenbook.Login;
using Erenbook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Erenbook.Controllers
{
    [LoginFilter]
    public class DonanimBakimController : Controller
    {
        // GET: DonanimBakim
        EREN db = new EREN();
        public ActionResult Index(string aranan = null)
        {
            var t = from x in db.DonanimBakims select x;
            if (!String.IsNullOrEmpty(aranan))
            {
                t = db.DonanimBakims.Where(kayit => kayit.Kullanici.Contains(aranan));

            }
            return View(t.OrderByDescending(kayit => kayit.id).ToList());
        }

        public ActionResult ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ekle(DonanimBakim kayit)
        {


            db.DonanimBakims.Add(kayit);
            db.SaveChanges();

            return RedirectToActionPermanent("Index");
        }

        

        public ActionResult resimler(int sayfaid = 0)
        {
            return View(db.sayfaresimleri.Where(kayit => kayit.sayfa_id == sayfaid).ToList());
        }

        public ActionResult resimekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult resimekle(HttpPostedFileBase resimadi, int sayfaid)
        {
            if (resimadi.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Content/images"), Guid.NewGuid().ToString() + "_" + Path.GetFileName(resimadi.FileName)); resimadi.SaveAs(filePath);

                SayfaResimleri sr = new SayfaResimleri();
                sr.sayfa_id = sayfaid;
                sr.resimadi = Path.GetFileName(filePath);
                db.sayfaresimleri.Add(sr);
                db.SaveChanges();
            }
           
            return RedirectToActionPermanent("Index");
        }

        public ActionResult resimsil(int[] resim_id)
        {
            foreach (int resimID in resim_id)
            {
                SayfaResimleri kayit = db.sayfaresimleri.Find(resimID);
                db.sayfaresimleri.Remove(kayit);

                string fullPath = Request.MapPath("~/Content/images/" + kayit.resimadi);

                if (System.IO.File.Exists(fullPath))
                { 
                    System.IO.File.Delete(fullPath); 
                }

            }
            db.SaveChanges();
            return Json("Seçili dosyalar silindi!");
        }

        public ActionResult Duzelt(int id = 0)
        {
            DonanimBakim kayit = db.DonanimBakims.Find(id);
            return View(kayit);

        }

        [HttpPost]
        public ActionResult Duzelt(DonanimBakim kayit)
        {
            db.Entry(kayit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}
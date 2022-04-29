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
    public class DonanimBakim2022Controller : Controller
    {
        // GET: DonanimBakim2022
        EREN db = new EREN();
        public ActionResult Index(string aranan = null)
        {
            var t = from x in db.DonanimBakim2022s select x;
            if (!String.IsNullOrEmpty(aranan))
            {
                t = db.DonanimBakim2022s.Where(kayit => kayit.Kullanici.Contains(aranan));

            }
            return View(t.OrderByDescending(kayit => kayit.id).ToList());
        }

        public ActionResult ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ekle(DonanimBakim2022 kayit)
        {


            db.DonanimBakim2022s.Add(kayit);
            db.SaveChanges();

            return RedirectToActionPermanent("Index");
        }

        public ActionResult resimler(int sayfaid = 0)
        {
            return View(db.sayfaResimleri2s.Where(kayit => kayit.sayfa_id == sayfaid).ToList());
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

                SayfaResimleri2 sr = new SayfaResimleri2();
                sr.sayfa_id = sayfaid;
                sr.resimadi = Path.GetFileName(filePath);
                db.sayfaResimleri2s.Add(sr);
                db.SaveChanges();
            }

            return RedirectToActionPermanent("Index");
        }

        public ActionResult resimsil(int[] resim_id)
        {
            foreach (int resimID in resim_id)
            {
                SayfaResimleri2 kayit = db.sayfaResimleri2s.Find(resimID);
                db.sayfaResimleri2s.Remove(kayit);

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
            DonanimBakim2022 kayit = db.DonanimBakim2022s.Find(id);
            return View(kayit);

        }
        [HttpPost]
        public ActionResult Duzelt(DonanimBakim2022 kayit)
        {
            db.Entry(kayit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
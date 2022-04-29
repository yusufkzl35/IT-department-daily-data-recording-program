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
    public class SiparisFisiController : Controller
    {
        // GET: SiparisFisi
        EREN db = new EREN();
        public ActionResult Index(string aranan = null)
        {
            var t = from x in db.MalSipFisis select x;
            if (!String.IsNullOrEmpty(aranan))
            {
                t = db.MalSipFisis.Where(kayit => kayit.MlzmListesi.Contains(aranan) || kayit.Aciklama.Contains(aranan));

            }
            return View(t.OrderByDescending(kayit => kayit.id).ToList());
        }

        public ActionResult ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ekle(MalSipFisi kayit)
        {


            db.MalSipFisis.Add(kayit);
            db.SaveChanges();

            return RedirectToActionPermanent("Index");
        }

        public ActionResult resimler(int sayfaid = 0)
        {
            return View(db.siparisResimleris.Where(kayit => kayit.sayfa_id == sayfaid).ToList());
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
                // string filePath = Path.Combine(Server.MapPath("~/Content/SiparisResimleri"), Guid.NewGuid().ToString() + "_" + Path.GetFileName(resimadi.FileName)); resimadi.SaveAs(filePath);
                string filePath = Path.Combine(Server.MapPath("~/Content/ArizaResimleri"), Path.GetFileName(resimadi.FileName)); resimadi.SaveAs(filePath);
                SiparisResimleri sr = new SiparisResimleri();
                sr.sayfa_id = sayfaid;
                sr.resimadi = Path.GetFileName(filePath);
                db.siparisResimleris.Add(sr);
                db.SaveChanges();
            }

            return RedirectToActionPermanent("Index");
        }

        public ActionResult resimsil(int[] resim_id)
        {
            foreach (int resimID in resim_id)
            {
                SiparisResimleri kayit = db.siparisResimleris.Find(resimID);
                db.siparisResimleris.Remove(kayit);

                string fullPath = Request.MapPath("~/Content/SiparisResimleri/" + kayit.resimadi);

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
            MalSipFisi kayit = db.MalSipFisis.Find(id);
            return View(kayit);

        }

        [HttpPost]
        public ActionResult Duzelt(MalSipFisi kayit)
        {
            db.Entry(kayit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
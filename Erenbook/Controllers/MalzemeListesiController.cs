using ClosedXML.Excel;
using Erenbook.Login;
using Erenbook.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Erenbook.Controllers
{
    [LoginFilter]
    public class MalzemeListesiController : Controller
    {
        // GET: MalzemeListesi
        EREN db = new EREN();
       

        public ActionResult Index(string aranan = null)
        {
           

                var t = from x in db.MalzemeListesis select x;
            if (!String.IsNullOrEmpty(aranan))
            {
                t = db.MalzemeListesis.Where(kayit => kayit.MlzmListesi.Contains(aranan));

            }
            return View(t.OrderBy(kayit => kayit.id).ToList());
        }
        public ActionResult ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ekle(MalzemeListesi kayit)
        {
            

            db.MalzemeListesis.Add(kayit);
            db.SaveChanges();

            return RedirectToActionPermanent("Index");
        }

        public ActionResult guncelle(int id = 0)
        {
            MalzemeListesi kayit = db.MalzemeListesis.Find(id);
            return View(kayit);

        }

        [HttpPost]
        public ActionResult guncelle(MalzemeListesi kayit)
        {
            db.Entry(kayit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


     


        [HttpPost]

        public FileResult Excel()
        {
            DataTable dt = new DataTable("F 293 Rev.0");
          

            dt.Columns.AddRange(new DataColumn[4]
                {

                
                     new DataColumn("Malzemeler"),
                     new DataColumn("Kritik Stok Miktarı"),
                     new DataColumn("Hazır Miktar"),
                     new DataColumn("Sipariş Miktari")});

            var emps = from MalzemeListesi in db.MalzemeListesis.ToList() select MalzemeListesi;

            foreach(var MalzemeListesi in emps )
            {
                dt.Rows.Add(MalzemeListesi.MlzmListesi, MalzemeListesi.KSMiktari, MalzemeListesi.HazirMiktar, MalzemeListesi.SprsMiktari);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream=new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "KritikYedekParçaListesi.xlsx");
                }
            }


        }
        



    }
}
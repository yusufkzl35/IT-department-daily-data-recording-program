using Erenbook.Login;
using Erenbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using OfficeOpenXml;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using ClosedXML.Excel;

namespace Erenbook.Controllers
{
    [LoginFilter]
    public class GunlukController : Controller
    {


        EREN db = new EREN();

        // GET: Gunluk


        //public ActionResult Index(int sayfa = 1)
        //{

        //    return View(db.Gunluks.OrderByDescending(kayit => kayit.id).ThenBy(x => x.id).ToPagedList(sayfa, 20));
        //}


        //public ActionResult Index(string search, int? i)
        //{
        //    EREN db = new EREN();

        //    List<Gunluk> listemp = db.Gunluks.ToList();
        //    return View(db.Gunluks.Where(x => x.AdSoyad.StartsWith(search) || x.Donanım.StartsWith(search)  || search == null).ToList().ToPagedList(i ?? 1, 25));
        //}

        public ActionResult Index(string aranan = null, int sayfa = 1)
        {
            var t = from x in db.Gunluks select x;
            if (!String.IsNullOrEmpty(aranan))
            {
                t = db.Gunluks.Where(kayit => kayit.AdSoyad.Contains(aranan)||kayit.Donanım.Contains(aranan));

            }
            return View(t.OrderByDescending(kayit => kayit.id).ThenBy(x => x.id).ToPagedList(sayfa, 35));
        }


        public ActionResult ekle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ekle(Gunluk kayit)
        {
           

            db.Gunluks.Add(kayit);
            db.SaveChanges();

            return RedirectToActionPermanent("Index");
        }

        public ActionResult GunlukGetir(int id)//Blog 
        {
            var bl = db.Gunluks.Find(id);//
            return View("GunlukGetir", bl);

        }

        public ActionResult guncelle(int id = 0)
        {
            Gunluk kayit = db.Gunluks.Find(id);
            return View(kayit);

        }

        [HttpPost]
        public ActionResult guncelle(Gunluk kayit)
        {
            db.Entry(kayit).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpPost]

        public FileResult Excel()
        {
            DataTable dt = new DataTable("gunluk");


            dt.Columns.AddRange(new DataColumn[10]
                {

                     new DataColumn("İşlem Başlangıç Tarihi"),
                     new DataColumn("İşlem Başlangıç Saati"),
                     new DataColumn("Adı Soyadı"),
                     new DataColumn("Departmanı"),
                     new DataColumn("Arıza Türü"),
                     new DataColumn("Kullanılan Malzeme"),
                     new DataColumn("İşlem Bitiş Tarihi"),
                      new DataColumn("İşlem Bitiş Saati"),
                     new DataColumn("Toplam Geçen Süre"),
                     new DataColumn("Yapılan İşlem")

                });

            var emps = from gunluk in db.Gunluks.ToList() select gunluk;

            foreach (var gunluk in emps)
            {
                dt.Rows.Add(gunluk.TarihBaslangic,
               gunluk.Ilk1,
               gunluk.AdSoyad,
               gunluk.Bolum,
               gunluk.ArizaTuru,
               gunluk.Donanım,         
               gunluk.TarihBitis,
               gunluk.Son1,
               gunluk.GecenSure,
               gunluk.YapilanIslem); }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Gunluk.xlsx");
                }
            }


        }



    }
}





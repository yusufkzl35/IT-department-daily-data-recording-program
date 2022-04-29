using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class EskiProgramKayiti
    {
        public int id { get; set; }

        [Display(Name = "Personel Adı Soyadı")]
        public string AdSoyad { get; set; }

        [Display(Name = "Departmanı")]
        public string Bolum { get; set; }

        [Display(Name = "Arıza Türü")]
        public string ArizaTuru { get; set; }

        [Display(Name = "Kullanılan Malzeme")]
        public string Donanım { get; set; }

        [Display(Name = "İşlem Başlangıç Tarihi")]
        public string TarihBaslangic { get; set; }

        [Display(Name = "İşlem Başlangıç Saati")]
        public string BaslangicSaati { get; set; }

        [Display(Name = "İşlem Bitiş Tarihi")]
        public string TarihBitis { get; set; }
        [Display(Name = "İşlem Bitiş Saati")]
        public string BitisSaati { get; set; }

        [Display(Name = "Toplam Geçen Süre")]
        public string GecenSure { get; set; }

        [Display(Name = "Yapılan İşlem")]
        public string YapilanIslem { get; set; }
    }
}
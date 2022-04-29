using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class Gunluk
    {
        [BsonRepresentation(BsonType.ObjectId)]

        CultureInfo us = new CultureInfo("Tr-TR");
        public int id { get; set; }

        [Display(Name = "Personel Adı Soyadı")]
        public string AdSoyad { get; set; }

        [Display(Name = "Departmanı")]
        public string Bolum { get; set; }

        [Display(Name = "Arıza Türü")]

        public string ArizaTuru { get; set; }

        [Display(Name = "Kullanılan Malzeme")]
        public string Donanım { get; set; }

        [DisplayName("Toplam Geçen Süre (Dk)")]

        [NotMapped]
        public TimeSpan GecenSure
             
        {
            get
         {
                return this.Son1 - this.Ilk1;
            }
        }


        [DataType(DataType.Date)]
        
        public DateTime TarihBaslangic { get; set; }

       

        [DataType(DataType.Date)]


        public DateTime TarihBitis { get; set; }

        [Display(Name = "İşlem Bitiş Saati")]
       
        public TimeSpan Son1 { get; set; }


        [Display(Name = "İşlem Başlangıç Saati")]
        public TimeSpan Ilk1 { get; set; }


        [Display(Name = "Yapılan İşlem")]
        public string YapilanIslem { get; set; }

        internal static object GetAll()
        {
            throw new NotImplementedException();
        }


        
    }
}
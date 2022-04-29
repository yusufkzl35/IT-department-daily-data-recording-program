using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class PersonelAccesID
    {
        public int id { get; set; }

        [Display(Name = "Personel Adı Soyadı")]
        public string AdSoyad { get; set; }

        [Display(Name = "Access Kapı No ")]
        public string  AccesId { get; set; }
    }
}
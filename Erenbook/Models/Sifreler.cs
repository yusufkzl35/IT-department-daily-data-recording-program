using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class Sifreler
    {
        public int id { get; set; }

        [Display(Name = "Başlığı")]
        public string Birim { get; set; }

        [Display(Name = "Şifresi")]
        public string Sifre { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string Kullanici { get; set; }

    }
}
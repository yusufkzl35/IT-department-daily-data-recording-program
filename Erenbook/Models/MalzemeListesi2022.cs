using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class MalzemeListesi2022
    {
        public int id { get; set; }

        [Display(Name = "Malzemeler")]
        public string MlzmListesi { get; set; }

        [Display(Name = "Kritik Stok Miktarı")]
        public string KSMiktari { get; set; }

        [Display(Name = "Elimizdeki Miktar")]
        public string HazirMiktar { get; set; }

        [Display(Name = "Sipariş Edilecek Miktar")]
        public string SprsMiktari { get; set; }
    }
}
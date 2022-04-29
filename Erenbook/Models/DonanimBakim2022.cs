using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class DonanimBakim2022
    {
        public int id { get; set; }

        [Display(Name = "Kullanıcı")]
        public string Kullanici { get; set; }

        [Display(Name = "1. Periyot(Mayıs-Haziran)")]
        public bool Periyot1 { get; set; }

        [Display(Name = "2. Periyot(Kasım-Aralık)")]
        public bool Periyot2 { get; set; }

        public string Sorumlu { get; set; }

        [Display(Name = "Açıklama")]
        public string Acıklama { get; set; }

        [Display(Name = "Veri Yedeği")]
        public bool Yedek { get; set; }

        [Display(Name = "Temizlik/Bakım")]
        public bool TemizlikBakim { get; set; }

        [Display(Name = "Depatmanı")]
        public string Departman { get; set; }

        public virtual ICollection<SayfaResimleri2> SayfaResimleri2 { get; set; }


    }
}
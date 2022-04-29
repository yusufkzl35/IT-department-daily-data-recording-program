using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class MalSipFisi
    {
        public int id { get; set; }

        [Display(Name = "Firma İsmi")]
        public string MlzmListesi { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Sipariş Tarihi")]
        public DateTime SiparisTarihi { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        public virtual ICollection<SiparisResimleri> SiparisResimleris { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class SayfaResimleri
    {
        public int id { get; set; }

        public string resimadi { get; set; }
        [ForeignKey("DonanimBakim")]

        public int? sayfa_id { get; set; }

        public virtual DonanimBakim DonanimBakim { get; set; }
    }
}
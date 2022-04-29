using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class SayfaResimleri2
    {
        public int id { get; set; }

        public string resimadi { get; set; }
        [ForeignKey("DonanimBakim2022")]

        public int? sayfa_id { get; set; }

        public virtual DonanimBakim2022 DonanimBakim2022 { get; set; }
    }
}
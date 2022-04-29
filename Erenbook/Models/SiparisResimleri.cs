using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class SiparisResimleri
    {
        public int id { get; set; }

        public string resimadi { get; set; }
        [ForeignKey("MalSipFisi")]

        public int? sayfa_id { get; set; }

        public virtual MalSipFisi MalSipFisi { get; set; }

    }
}
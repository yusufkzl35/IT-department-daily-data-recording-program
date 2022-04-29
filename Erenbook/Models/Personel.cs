using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class Personel
    {
        public int id { get; set; }

        [Display(Name = "Adı")]
        public string Adi { get; set; }

        [Display(Name = "Soyadı")]
        public string Soyadi { get; set; }

        [Display(Name = "Departmanı")]
        public string Departman { get; set; }
        [Display(Name = "Dahili No")]
        public string DahiliNo { get; set; }
        [Display(Name = "Cep No")]
        public string CepNo { get; set; }

        [Display(Name = "Mail Adresi")]
        public string Mail { get; set; }

        [Display(Name = "Pc Şifresi")]
        public string PcSifre { get; set; }
        [Display(Name = "Micro Şifresi")]
        public string MicroSifre { get; set; }

        [Display(Name = "Mail Şifresi")]
        public string MailSifre { get; set; }

        [Display(Name = "Ekstra Bilgi")]

        public string PerInfo { get; set; }
    }
}
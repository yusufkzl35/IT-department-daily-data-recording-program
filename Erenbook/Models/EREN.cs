using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Erenbook.Models
{
    public class EREN:DbContext
    {
        public DbSet<Personel> Personels { get; set; }

        public DbSet<Gunluk> Gunluks { get; set; }

        public DbSet<Sifreler> Sifrelers { get; set; }

        public DbSet<PersonelAccesID> PersonelAccesIDs { get; set; }

        public DbSet<MalzemeListesi> MalzemeListesis { get; set; }

      
        public DbSet<Kullanici> kullanicis { get; set; }

        public DbSet<DonanimBakim> DonanimBakims { get; set; }
      
        public DbSet<EskiProgramKayiti> EskiProgramKayitis { get; set; }

        public DbSet<SayfaResimleri> sayfaresimleri { get; set; }

        public DbSet<DonanimBakim2022> DonanimBakim2022s { get; set; }

        public DbSet<SayfaResimleri2> sayfaResimleri2s { get; set; }

        public DbSet<MalzemeListesi2022> MalzemeListesi2022s { get; set; }

        public DbSet<MalSipFisi> MalSipFisis { get; set; }

        public DbSet<SiparisResimleri> siparisResimleris { get; set; }
    }
}


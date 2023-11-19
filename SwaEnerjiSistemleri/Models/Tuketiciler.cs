using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwaEnerjiSistemleri.Models
{
    public class Tuketiciler
    {


        [Key]
        public int TuketiciId { get; set; }
        public int SayacNo { get; set; }
        public string? TuketiciAd { get; set; }
        public string? TuketiciSoyad { get; set; }
        public DateTime AbonelikTarihi { get; set; }
        public decimal FaturaTutar { get; set; }
        public DateTime FaturaKesimTarihi { get; set; }

       
        public int FirmaId { get; set; }
        [ForeignKey("FirmaId")]

        public virtual Firmalar? Firmalar { get; set; }

        
        public int SehirId { get; set; }
        [ForeignKey("SehirId")]

        public virtual Sehirler? Sehirler { get; set; }



    }
}

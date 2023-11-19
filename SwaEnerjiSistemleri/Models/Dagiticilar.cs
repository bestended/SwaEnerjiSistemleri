using System.ComponentModel.DataAnnotations;

namespace SwaEnerjiSistemleri.Models
{
    public class Dagiticilar
    {
        [Key]
        public int DagiticiId { get; set; }
        public string? DagiticiAdi { get; set; }
        public string? DagiticiSehir { get; set; }
        public int MevcutTrafoSayisi { get; set; }
        public int ToplamUretilenElektrik { get; set; }
        public int ToplamTuketilenElektrik { get; set; }



    }
}

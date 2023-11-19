using System.ComponentModel.DataAnnotations;

namespace SwaEnerjiSistemleri.Models
{
    public class Sehirler
    {
        [Key]
        public int SehirId { get; set; }
        public string? SehirAdi { get; set; }
        public string? SehirMerkezi { get; set; }

        public string? Ulke { get; set; }



    }
}

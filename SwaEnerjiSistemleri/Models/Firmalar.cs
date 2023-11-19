using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwaEnerjiSistemleri.Models
{
    public class Firmalar
    {
        [Key]
        public int FirmaId { get; set; }

        public string? FirmaAdi { get; set; }
        public string? FirmaTelefon { get; set; }
        public string? Mail { get; set; }

      
        public int DagiticiId { get; set; }
        [ForeignKey("DagiticiId")]

        public virtual Dagiticilar? Dagiticilar { get; set; }


    }
}

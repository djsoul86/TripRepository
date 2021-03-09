using System.ComponentModel.DataAnnotations.Schema;

namespace Viajeros.DA
{
    [Table("Viajes")]
    public class Viaje : IEntity
    {
        public string CodigoViaje { get; set; }
        public int NumeroPlazas { get; set; }
        public int OrigenId { get; set; }
        [ForeignKey("OrigenId")]
        public Pais Origen { get; set; }
        public int DestinoId { get; set; }
        [ForeignKey("DestinoId")]
        public Pais Destino { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
    }
}

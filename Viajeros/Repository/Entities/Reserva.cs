using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajeros.DA
{
    [Table("Reservas")]
    public class Reserva: IEntity
    {
        public int IdViajero { get; set; }
        [ForeignKey("IdViajero")]
        public Viajero Viajero { get; set; }
        public int IdViaje { get; set; }
        [ForeignKey("IdViaje")]
        public Viaje Viaje { get; set; }
    }
}

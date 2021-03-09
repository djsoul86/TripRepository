using System;
namespace Viajeros.Services
{
    public class ReservaRequestDto
    {
        public int IdViajero { get; set; }
        public int IdViaje { get; set; }
    }

    public class ReservaDto
    {
        public int Id { get; set; }
        public int IdViajero { get; set; }
        public int IdViaje { get; set; }
        public ViajerosDto Viajero { get; set; }
        public ViajesDto Viaje { get; set; }
    }
}

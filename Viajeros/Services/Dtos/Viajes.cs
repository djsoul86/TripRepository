using System;
namespace Viajeros.Services
{
    public class ViajesRequestDto
    {
        public string CodigoViaje { get; set; }
        public int NumeroPlazas { get; set; }
        public int OrigenId { get; set; }
        public int DestinoId { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
    }

    public class ViajesDto
    {
        public int Id { get; set; }
        public string CodigoViaje { get; set; }
        public int NumeroPlazas { get; set; }
        public int OrigenId { get; set; }
        public PaisDto Origen { get; set; }
        public int DestinoId { get; set; }
        public PaisDto Destino { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
        public string FullName { get
            {
                return $"{Origen.Nombre} - {Destino.Nombre}";
            }
        }
    }
}

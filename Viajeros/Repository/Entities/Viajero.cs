using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajeros.DA
{
    [Table("Viajeros")]
    public class Viajero: IEntity
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}

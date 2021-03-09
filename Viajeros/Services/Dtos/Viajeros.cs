namespace Viajeros.Services
{ 
    public class ViajerosRequestDto
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }

    public class ViajerosDto
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}



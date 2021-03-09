using Microsoft.EntityFrameworkCore;

namespace Viajeros.DA

{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {
            //

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            // ...
        }

        public DbSet<Viajero> Viajeros { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }

}


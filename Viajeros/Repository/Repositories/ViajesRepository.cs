using System;
namespace Viajeros.DA
{
    public class ViajesRepository : Repository<Viaje>, IViajesRepository
    {

        public ViajesRepository(DB db) : base(db)
        {

        }

    }
}

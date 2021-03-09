using System;
namespace Viajeros.DA
{
    public class ViajerosRepository : Repository<Viajero>, IViajerosRepository
    {

        public ViajerosRepository(DB db) : base(db)
        {
            //

        }

    }
}

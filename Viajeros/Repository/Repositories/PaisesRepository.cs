using System;
namespace Viajeros.DA
{
    public class PaisesRepository : Repository<Pais>, IPaisesRepository
    {

        public PaisesRepository(DB db) : base(db)
        {
            //

        }

    }
}

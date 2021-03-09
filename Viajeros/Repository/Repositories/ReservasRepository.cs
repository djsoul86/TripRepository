using System;
namespace Viajeros.DA
{
    public class ReservasRepository : Repository<Reserva>, IReservasRepository
    {

        public ReservasRepository(DB db) : base(db)
        {
            //

        }

    }
}

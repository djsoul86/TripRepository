using System;
using System.ComponentModel.DataAnnotations;

namespace Viajeros.DA
{
    public abstract class IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

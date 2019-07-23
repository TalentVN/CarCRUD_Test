using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Data.Entities
{
    public class Area : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Garage> Garages { get; set; }
    }
}

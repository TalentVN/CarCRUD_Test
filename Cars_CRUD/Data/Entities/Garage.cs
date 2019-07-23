using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Data.Entities
{
    public class Garage : BaseEntity
    {
        public string Name { get; set; }

        public Guid GarageTypeId { get; set; }

        public Guid AreaId { get; set; }

        public Area Area { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}

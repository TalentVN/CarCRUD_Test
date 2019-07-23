using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Data.Entities
{
    public class Report : BaseEntity
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid GarageId { get; set; }
        
        public Garage Garage { get; set; }
    }
}

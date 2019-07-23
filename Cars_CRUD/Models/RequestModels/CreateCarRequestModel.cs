using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Models.RequestModels
{
    public class CreateCarRequestModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public Guid GarageId { get; set; }

        public int ImpactClassId { get; set; }

        public int CarProbabilityClassId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Models.ResponseModels
{
    public class GarageResponseModel
    {
        public string Name { get; set; }

        public Guid GarageTypeId { get; set; }

        public AreaResponseModel Area { get; set; }

        public IEnumerable<CarResponseModel> Cars { get; set; }
    }
}

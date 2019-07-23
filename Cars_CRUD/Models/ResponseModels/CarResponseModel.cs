using Cars_CRUD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Models.ResponseModels
{
    public class CarResponseModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public CarCategoryResponseModel CarCategory { get; set; }

        public CarImpactClass CarImpactClass { get; set; }

        public CarProbabilityClass CarProbabilityClass { get; set; }
    }
}

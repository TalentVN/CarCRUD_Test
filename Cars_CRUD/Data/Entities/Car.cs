using Cars_CRUD.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Data.Entities
{
    public class Car : BaseEntity
    {

        public Car()
        {
            this.ObjectStatus = ObjectStatus.Active;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public ObjectStatus ObjectStatus { get; private set; }

        public Guid CarCategoryId { get; set; }

        public CarCategory CarCategory { get; set; }

        public Guid GarageId { get; set; }

        public Garage Garage { get; set; }

        [Column("ImpactClass_Index")]
        public int CarImpactClassId { get; set; }

        public CarImpactClass CarImpactClass { get; set; }

        [Column("ProbabilityClass_Index")]
        public int CarProbabilityClassId { get; set; }

        public CarProbabilityClass CarProbabilityClass { get; set; }

        public void DeActive()
        {
            this.ObjectStatus = ObjectStatus.DeActive;
        }

        public void Active()
        {
            this.ObjectStatus = ObjectStatus.Active;
        }
    }
}

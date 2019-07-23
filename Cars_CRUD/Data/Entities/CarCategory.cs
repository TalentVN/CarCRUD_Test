using Cars_CRUD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Data.Entities
{
    public class CarCategory : BaseEntity
    {
        public CarCategory()
        {
            this.ObjectStatus = ObjectStatus.Active;
        }

        public string Name { get; set; }

        public int Ordinal { get; set; }

        public ObjectStatus ObjectStatus { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}

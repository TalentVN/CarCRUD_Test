using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Data.Entities
{
    public class CarBaseClass
    {
        [Column("Index")]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}

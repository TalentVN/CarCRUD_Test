using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Data.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
            this.DateCreated = DateTime.UtcNow;
            this.ModifiedRevCounter = 0;
        }

        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime CreatedFrom { get; set; }

        public DateTime DateModified { get; set; }

        public string ModifiedFrom { get; set; }

        public int ModifiedRevCounter { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
    }
}

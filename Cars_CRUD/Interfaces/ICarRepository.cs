using Cars_CRUD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Interfaces
{
    public interface ICarRepository : IAsyncRepository<Car>
    {

    }
}

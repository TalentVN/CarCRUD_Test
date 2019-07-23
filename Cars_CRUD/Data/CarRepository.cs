using Cars_CRUD.Data.Entities;
using Cars_CRUD.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Data
{
    public class CarRepository : EfRepository<Car>, ICarRepository
    {
        public CarRepository(CarsContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Car> GetByIdAsync(Guid id)
        {
            return await _dbContext.Cars
                .Include(x => x.CarCategory)
                .Include(x => x.CarImpactClass)
                .Include(x => x.CarProbabilityClass)
                .Include(x => x.Garage)
                    .ThenInclude(g => g.Area)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

using Cars_CRUD.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Data
{
    public class CarsContextSeed
    {
        public static async Task SeedAsync(CarsContext carsContext,
           ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // Seed Areas and Garages
                if (!carsContext.Areas.Any())
                {
                    IEnumerable<Area> areas = GetPreconfiguredAreas();
                    carsContext.Areas.AddRange(areas);

                    foreach (Area area in areas)
                    {
                        carsContext.Garages.AddRange(GetPreconfiguredGarages(area));
                    }

                    await carsContext.SaveChangesAsync();
                }

                if (!carsContext.CarCategories.Any())
                {
                    carsContext.CarCategories.AddRange(GetPreconfiguredCarCategories());
                    await carsContext.SaveChangesAsync();
                }

                if (!carsContext.CarImpactClasses.Any())
                {
                    carsContext.CarImpactClasses.AddRange(GetPreconfiguredCarImpactClasses());
                    await carsContext.SaveChangesAsync();
                }

                if (!carsContext.CarProbabilityClasses.Any())
                {
                    carsContext.CarProbabilityClasses.AddRange(GetPreconfiguredCarProbabilityClasses());
                    await carsContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CarsContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(carsContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<Area> GetPreconfiguredAreas()
        {
            return new List<Area>()
            {
                new Area() { Name = "Area 1"},
                new Area() { Name = "Area 2"},
                new Area() { Name = "Area 3"},
            };
        }

        static IEnumerable<Garage> GetPreconfiguredGarages(Area area)
        {
            return new List<Garage>()
            {
                new Garage() { Name = area.Name + "Garage 1", Area = area, AreaId = area.Id},
                new Garage() { Name = area.Name + "Garage 2", Area = area, AreaId = area.Id},
                new Garage() { Name = area.Name + "Garage 3", Area = area, AreaId = area.Id},
            };
        }

        static IEnumerable<CarCategory> GetPreconfiguredCarCategories()
        {
            return new List<CarCategory>()
            {
                new CarCategory() { Name = "CarCategory 1"},
                new CarCategory() { Name = "CarCategory 2"},
                new CarCategory() { Name = "CarCategory 3"},
                new CarCategory() { Name = "CarCategory 4"},
                new CarCategory() { Name = "CarCategory 5"},
            };
        }

        static IEnumerable<CarImpactClass> GetPreconfiguredCarImpactClasses()
        {
            return new List<CarImpactClass>()
            {
                new CarImpactClass() { Name = "CarImpactClass 1", Value = "1"},
                new CarImpactClass() { Name = "CarImpactClass 2", Value = "2"},
            };
        }

        static IEnumerable<CarProbabilityClass> GetPreconfiguredCarProbabilityClasses()
        {
            return new List<CarProbabilityClass>()
            {
                new CarProbabilityClass() { Name = "CarProbabilityClass 1", Value = "1"},
                new CarProbabilityClass() { Name = "CarProbabilityClass 2", Value = "2"},
            };
        }
    }
}

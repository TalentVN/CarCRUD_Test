using Cars_CRUD.Data.Entities;
using Cars_CRUD.Models.RequestModels;
using Cars_CRUD.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarResponseModel>> GetCars();
        Task<CarResponseModel> GetCar(Guid id);
        Task<CarResponseModel> CreateCar(CreateCarRequestModel requestModel);
        Task UpdateCar(Guid id, UpdateCarRequestModel requestModel);
        Task DeleteCar(Guid id);
    }
}

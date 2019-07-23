using AutoMapper;
using Cars_CRUD.Data.Entities;
using Cars_CRUD.Interfaces;
using Cars_CRUD.Logging;
using Cars_CRUD.Models.RequestModels;
using Cars_CRUD.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CarService> _logger;

        public CarService(
            ICarRepository carRepository,
            IMapper mapper,
            IAppLogger<CarService> logger)
        {
            _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CarResponseModel>> GetCars()
        {
            _logger.LogInformation("GetCars");

            IEnumerable<Car> cars = await _carRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<CarResponseModel>>(cars);
        }

        public async Task<CarResponseModel> GetCar(Guid id)
        {
            _logger.LogInformation($"GetCar - params: id={id}");

            Car car = await _carRepository.GetByIdAsync(id);
            return _mapper.Map<CarResponseModel>(car);
        }

        public async Task<CarResponseModel> CreateCar(CreateCarRequestModel requestModel)
        {
            _logger.LogInformation("CreateCar - params: requestModel={0}", requestModel);

            Car car = new Car()
            {
                CarCategoryId = requestModel.CategoryId,
                CarImpactClassId = requestModel.ImpactClassId,
                CarProbabilityClassId = requestModel.CarProbabilityClassId,
                DateCreated = DateTime.UtcNow,
                Description = requestModel.Description,
                Title = requestModel.Title,
                GarageId = requestModel.GarageId,
            };

            await _carRepository.AddAsync(car);

            var result = await _carRepository.GetByIdAsync(car.Id);

            return _mapper.Map<Car, CarResponseModel>(result);
        }

        public async Task UpdateCar(Guid id, UpdateCarRequestModel requestModel)
        {
            _logger.LogInformation("UpdateCar - params: id={0} requestModel={1}", id, requestModel);
            var valid = await _carRepository.GetByIdAsync(id);

            if (id != requestModel.Id || valid == null) throw new Exception($"Invalid Car with Id:{id}");

            valid.Description = requestModel.Description;
            valid.Title = requestModel.Title;
            valid.ModifiedRevCounter++;

            await _carRepository.UpdateAsync(valid);
        }

        public async Task DeleteCar(Guid id)
        {
            _logger.LogInformation("DeleteCar - params: id={0}", id);
            var valid = await _carRepository.GetByIdAsync(id);

            if (valid == null) throw new Exception($"Invalid Car with Id:{id}");

            await _carRepository.DeleteAsync(valid);
        }
    }
}

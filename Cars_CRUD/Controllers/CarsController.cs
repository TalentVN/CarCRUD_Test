using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cars_CRUD.Data;
using Cars_CRUD.Data.Entities;
using Cars_CRUD.Interfaces;
using Cars_CRUD.Logging;
using Cars_CRUD.Models.ResponseModels;
using Cars_CRUD.Models.RequestModels;

namespace Cars_CRUD.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IAppLogger<CarsController> _logger;

        public CarsController(
            ICarService carService,
            IAppLogger<CarsController> logger)
        {
            _carService = carService;
            _logger = logger;
        }

        // GET: api/v1/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarResponseModel>>> GetCars()
        {
            return Ok(await _carService.GetCars());
        }

        // GET: api/v1/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarResponseModel>> GetCar(Guid id)
        {
            var car = await _carService.GetCar(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/v1/Cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(Guid id, UpdateCarRequestModel requestModel)
        {
            await _carService.UpdateCar(id, requestModel);

            return NoContent();
        }

        // POST: api/v1/Cars
        [HttpPost]
        public async Task<ActionResult<CarResponseModel>> PostCar(CreateCarRequestModel requestModel)
        {
            return Ok(await _carService.CreateCar(requestModel));
        }

        // DELETE: api/v1/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCar(Guid id)
        {
            await _carService.DeleteCar(id);

            return NoContent();
        }
    }
}

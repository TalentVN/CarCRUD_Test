using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars_CRUD.Data;
using Cars_CRUD.Data.Entities;
using Cars_CRUD.Interfaces;
using Cars_CRUD.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cars_CRUD.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GaragesController : ControllerBase
    {
        private readonly IAsyncRepository<Garage> _garageRepository;
        private readonly IMapper _mapper;

        public GaragesController(
            IAsyncRepository<Garage> garageRepository,
            IMapper mapper)
        {
            _garageRepository = garageRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GarageResponseModel>>> Get()
        {
            IEnumerable<Garage> areas = await _garageRepository.ListAllAsync();
            return Ok(_mapper.Map<IEnumerable<GarageResponseModel>>(areas));
        }
    }
}

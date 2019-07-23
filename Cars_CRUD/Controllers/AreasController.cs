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
    public class AreasController : ControllerBase
    {
        private readonly IAsyncRepository<Area> _areaRepository;
        private readonly IMapper _mapper;

        public AreasController(
            IAsyncRepository<Area> areaRepository,
            IMapper mapper)
        {
            _areaRepository = areaRepository ?? throw new ArgumentNullException(nameof(areaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaResponseModel>>> Get()
        {
            IEnumerable<Area> areas = await _areaRepository.ListAllAsync();
            return Ok(_mapper.Map<IEnumerable<AreaResponseModel>>(areas));
        }
    }
}

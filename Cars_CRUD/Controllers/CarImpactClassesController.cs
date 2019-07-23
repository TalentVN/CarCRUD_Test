using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars_CRUD.Data;
using Cars_CRUD.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_CRUD.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarImpactClassesController : ControllerBase
    {
        private readonly CarsContext _context;
        private readonly IMapper _mapper;

        public CarImpactClassesController(
            CarsContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarImpactClass>>> Get()
        {
            return await _context.CarImpactClasses.ToListAsync();
        }
    }
}

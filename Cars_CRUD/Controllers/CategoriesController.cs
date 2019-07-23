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
    public class CategoriesController : ControllerBase
    {
        private readonly IAsyncRepository<CarCategory> _categoriesRepository;
        private readonly IMapper _mapper;

        public CategoriesController(
            IAsyncRepository<CarCategory> categoriesRepository,
            IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarCategoryResponseModel>>> Get()
        {
            IEnumerable<CarCategory> areas = await _categoriesRepository.ListAllAsync();
            return Ok(_mapper.Map<IEnumerable<CarCategoryResponseModel>>(areas));
        }
    }
}

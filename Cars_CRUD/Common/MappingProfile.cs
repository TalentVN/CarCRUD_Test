using AutoMapper;
using Cars_CRUD.Data.Entities;
using Cars_CRUD.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Area, AreaResponseModel>();
            CreateMap<Car, CarResponseModel>();
            CreateMap<Garage, GarageResponseModel>();
            CreateMap<CarCategory, CarCategoryResponseModel>();
            CreateMap<Report, ReportResponseModel>();
        }
    }
}

using AutoMapper;
using Cars_CRUD.Data;
using Cars_CRUD.Data.Entities;
using Cars_CRUD.Logging;
using Cars_CRUD.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Services
{
    public class ReportService
    {
        private readonly CarsContext _context;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ReportService> _logger;

        public ReportService(
            CarsContext context,
            IMapper mapper,
            IAppLogger<ReportService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ReportResponseModel>> GetReports()
        {
            _logger.LogInformation("GetReports");

            IEnumerable<Report> reports = await _context.Reports.ToListAsync();
            return _mapper.Map<IEnumerable<ReportResponseModel>>(reports);
        }

        public async Task<ReportResponseModel> GetReport(Guid id)
        {
        }

        public async Task<ReportResponseModel> CreateReport(DateTime start, DateTime end, Guid areaId)
        {
        }
    }
}

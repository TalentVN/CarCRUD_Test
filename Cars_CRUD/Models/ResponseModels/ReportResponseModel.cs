using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars_CRUD.Models.ResponseModels
{
    public class ReportResponseModel
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public GarageResponseModel GarageResponseModel { get; set; }
    }
}

using AcademicManagement.Application.DTOs.Core;
using System;
using System.Collections.Generic;

namespace AcademicManagement.Application.DTOs.AcademicPeriod
{
    public class AcademicPeriodDto:BaseDto
    {
        public AcademicPeriodDto()
        {
            AcademicPeriodDetailDto = new List<AcademicPeriodDetailDto>();
        }

        public AcademicPeriodDto(string name, string description, DateTime startDate, DateTime endDate,string status)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = EndDate;
            Status = status;
            AcademicPeriodDetailDto = new List<AcademicPeriodDetailDto>();
        }
        public int AcademicPeriodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        public List<AcademicPeriodDetailDto> AcademicPeriodDetailDto { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AcademicManagement.Domain.Entities.AcademicPeriods
{
    public class AcademicPeriod
    {
        public int AcademicPeriodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        public List<AcademicPeriodDetail> AcademicPeriodDetail { get; set; }

        public AcademicPeriod()
        {
            AcademicPeriodDetail = new List<AcademicPeriodDetail>();
        }

        public AcademicPeriod(string name, string description, DateTime startDate, DateTime endDate, string status)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = EndDate;
            Status = status;
            AcademicPeriodDetail = new List<AcademicPeriodDetail>();
        }

        public void Delete()
        {
            Status = "DELETED";
        }

        public void UpdateAcademicPeriod(string name, string description, DateTime startDate, DateTime endDate, string status)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = EndDate;
            Status = status;
        }
    }
}

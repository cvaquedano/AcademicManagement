using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Domain.Entities.AcademicPeriods
{
    public class AcademicPeriodCourseAsignature
    {
        public AcademicPeriodCourseAsignature()
        {

        }

        public AcademicPeriodCourseAsignature(int asignatureId, string name)
        {
            AsignatureId = asignatureId;
            AsignatureName = name;
        }

        public int AcademicPeriodCourseAsignatureId { get; set; }
        public int AcademicPeriodDetailId { get; set; }
        public int AsignatureId { get; set; }
        public string AsignatureName { get; set; }

        AcademicPeriodDetail AcademicPeriodDetail { get; set; }
    }
}

using AcademicManagement.Application.DTOs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Application.DTOs
{
    public class TeacherDto:PersonDto
    {
        public int TeacherId { get; set; }
    }
}

﻿using AcademicManagement.Domain.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Domain.Entities
{
    public class Teacher:Person
    {
        public int TeacherId { get; set; }
    }
}

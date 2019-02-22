using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicManagement.Domain.Entities.BaseEntities
{
    public class Entity
    {
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public string TriggerAction { get; set; }
    }
}

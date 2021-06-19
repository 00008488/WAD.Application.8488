using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD.Application._8488.Models
{
    public class EmployeeViewModel
    {
        public String Id { get; set; }
        public DepartmentViewModel Department { get; set; }
        public String DepartmentId { get; set; }
        public String Name { get; set; }
        public DateTime Dob { get; set; }
    }
}

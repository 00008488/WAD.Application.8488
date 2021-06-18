using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Department
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}

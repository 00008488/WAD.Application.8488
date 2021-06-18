using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Employee
    {
        public Int32 Id { get; set; }
        public String Department_id { get; set; }
        public Department Department { get; set; }
        public String Name { get; set; }

        public DateTime Dob { get; set; }
    }
}

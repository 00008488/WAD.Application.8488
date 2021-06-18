using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Employee
    {
        public String Id { get; set; }
        public Department Department { get; set; }
        public String Name { get; set; }
        public DateTime Dob { get; set; }
    }
}

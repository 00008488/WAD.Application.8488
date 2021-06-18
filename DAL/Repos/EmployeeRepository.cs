using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public interface EmployeeRepository
    {
        public Employee GetById(String Id);
        List<Employee> GetAll();
        public bool Create(Employee e);
        public bool Update(Employee e);
        public bool Delete(String Id);
    }
}

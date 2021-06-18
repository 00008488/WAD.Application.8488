using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public interface DepartmentRepository
    {
        public Department GetById(String Id);
        List<Department> GetAll();
        public bool Create(Department d);
        public bool Update(Department d);
        public bool Delete(String Id);
    }
}

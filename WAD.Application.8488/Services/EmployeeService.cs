using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD.Application._8488.Models;

namespace WAD.Application._8488.Services
{
    public interface EmployeeService
    {
        public List<EmployeeViewModel> GetAll();
        public EmployeeViewModel GetById(String Id);
        public bool Create(EmployeeViewModel e);
        public bool Update(EmployeeViewModel e);
        public bool Delete(String Id);
    }
}

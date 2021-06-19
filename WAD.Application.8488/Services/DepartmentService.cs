using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD.Application._8488.Models;

namespace WAD.Application._8488.Services
{
    public interface DepartmentService
    {
        public DepartmentViewModel GetById(String Id);
        public List<DepartmentViewModel> GetAll();
        public bool Create(DepartmentViewModel c);
        public bool Update(DepartmentViewModel c);
        public bool Delete(String Id);
    }
}

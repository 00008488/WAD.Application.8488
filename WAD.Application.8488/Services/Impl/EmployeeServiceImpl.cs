using DAL.Entities;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD.Application._8488.Models;

namespace WAD.Application._8488.Services.Impl
{
    public class EmployeeServiceImpl : EmployeeService
    {
        private readonly EmployeeRepository _repo;
        private readonly DepartmentRepository _department_repo;

        public EmployeeServiceImpl(EmployeeRepository repo, DepartmentRepository department_repo)
        {
            _repo = repo;
            _department_repo = department_repo;
        }

        public List<EmployeeViewModel> GetAll()
        {
            List<Employee> list = _repo.GetAll();

            List<EmployeeViewModel> listvm = null;

            if (list != null && list.Count() > 0)
            {
                listvm = new List<EmployeeViewModel>();
                foreach (Employee item in list)
                {
                    Department d = _department_repo.GetAll().Single(x => x.Id == item.DepartmentId);
                    item.Department = d;
                    EmployeeViewModel vm = Mapper.EmployeeToEmployeeViewModel(item);
                    listvm.Add(vm);
                }
            }

            return listvm;
        }

        public EmployeeViewModel GetById(String Id)
        {
            Employee employee = _repo.GetById(Id);

            Department d = _department_repo.GetAll().Single(x => x.Id == employee.DepartmentId);
            employee.Department = d;

            return Mapper.EmployeeToEmployeeViewModel(employee);
        }

        public bool Create(EmployeeViewModel vm)
        {
            return _repo.Create(Mapper.EmployeeViewModelToEmployee(vm));
        }

        public bool Update(EmployeeViewModel vm)
        {
            return _repo.Update(Mapper.EmployeeViewModelToEmployee(vm));
        }

        public bool Delete(String Id)
        {
            return _repo.Delete(Id);
        }


    }
}

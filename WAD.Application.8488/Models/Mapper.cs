using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD.Application._8488.Models
{
    public class Mapper
    {
        public static DepartmentViewModel DepartmentToDepartmentViewModel(Department d)
        {
            if (d == null)
                return null;
            return new DepartmentViewModel()
            {
                Id = d.Id,
                Name = d.Name
            };
        }

        public static Department DepartmentViewModelToDepartment(DepartmentViewModel vm)
        {
            return new Department()
            {
                Id = vm.Id,
                Name = vm.Name
            };
        }

        public static EmployeeViewModel EmployeeToEmployeeViewModel(Employee e)
        {
            if (e == null)
                return null;
            return new EmployeeViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Department = DepartmentToDepartmentViewModel(e.Department),
                Dob = e.Dob
            };
        }

        public static Employee EmployeeViewModelToEmployee(EmployeeViewModel vm)
        {
            return new Employee()
            {
                Id = vm.Id,
                Name = vm.Name,
                DepartmentId = vm.DepartmentId,
                Dob = vm.Dob
            };
        }

    }
}

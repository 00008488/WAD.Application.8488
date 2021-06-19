using DAL.Entities;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD.Application._8488.Models;

namespace WAD.Application._8488.Services.Impl
{
    public class DepartmentServiceImpl : DepartmentService
    {
        private DepartmentRepository _repo;

        public DepartmentServiceImpl(DepartmentRepository repo)
        {
            _repo = repo;
        }

        public List<DepartmentViewModel> GetAll()
        {
            List<Department> list = _repo.GetAll();

            List<DepartmentViewModel> listvm = null;

            if (list != null && list.Count() > 0)
            {
                listvm = new List<DepartmentViewModel>();
                foreach (Department item in list)
                {
                    DepartmentViewModel vm = Mapper.DepartmentToDepartmentViewModel(item);
                    listvm.Add(vm);
                }
            }

            return listvm;
        }

        public DepartmentViewModel GetById(String Id)
        {
            Department department = _repo.GetById(Id);
            return Mapper.DepartmentToDepartmentViewModel(department);
        }

        public bool Create(DepartmentViewModel vm)
        {
            return _repo.Create(Mapper.DepartmentViewModelToDepartment(vm));
        }

        public bool Update(DepartmentViewModel vm)
        {
            return _repo.Update(Mapper.DepartmentViewModelToDepartment(vm));
        }

        public bool Delete(String Id)
        {
            return _repo.Delete(Id);
        }

    }
}

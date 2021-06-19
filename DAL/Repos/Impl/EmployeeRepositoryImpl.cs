using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repos.Impl
{
    public class EmployeeRepositoryImpl : EmployeeRepository
    {
        private readonly DbContextConfig _ctx;

        public EmployeeRepositoryImpl(DbContextConfig ctx)
        {
            _ctx = ctx;
        }

        public List<Employee> GetAll()
        {
            return _ctx.Employees.ToList();
        }

        public Employee GetById(String Id)
        {
            return _ctx.Employees.Where(x => x.Id == Id).FirstOrDefault();
        }

        public bool Create(Employee d)
        {
            d.Id = Util.RandomGenerator();
            try
            {
                _ctx.Employees.Add(d);
                _ctx.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public bool Update(Employee e)
        {
            var existing = GetAll().FirstOrDefault(x => x.Id == e.Id);
            if (existing != null)
            {
                try
                {
                    existing.Name = e.Name;
                    existing.DepartmentId = e.DepartmentId;
                    existing.Dob = e.Dob;
                    _ctx.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            return false;
        }

        public bool Delete(String Id)
        {
            try
            {
                _ctx.Employees.Remove(GetAll().First(x => x.Id == Id));
                _ctx.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return false;
        }

    }
}

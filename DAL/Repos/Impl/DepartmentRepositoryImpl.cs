using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repos.Impl
{
    public class DepartmentRepositoryImpl : DepartmentRepository
    {
        private readonly DbContextConfig _ctx;

        public DepartmentRepositoryImpl(DbContextConfig ctx)
        {
            _ctx = ctx;
        }

        public List<Department> GetAll()
        {
            return _ctx.Departments.ToList();
        }

        public Department GetById(String Id)
        {
            return _ctx.Departments.Where(x => x.Id == Id).FirstOrDefault();
        }

        public bool Create(Department d)
        {
            d.Id = Util.RandomGenerator();
            try
            {
                _ctx.Departments.Add(d);
                _ctx.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public bool Update(Department d)
        {
            var existing = GetAll().FirstOrDefault(x => x.Id == d.Id);
            if (existing != null)
            {
                try
                {
                    existing.Name = d.Name;
                    _ctx.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return false;
        }

        public bool Delete(String Id)
        {
            try
            {
                _ctx.Departments.Remove(GetAll().First(x => x.Id == Id));
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAD.Application._8488.Models;
using WAD.Application._8488.Services;

namespace WAD.Application._8488.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        // GET: api/employee/getall
        [HttpGet]
        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return _service.GetAll();
        }

        // GET api/employee/get/1
        [HttpGet("{Id}")]
        public EmployeeViewModel Get(String Id)
        {
            return _service.GetById(Id);
        }

        // POST api/employee/create
        [HttpPost]
        public bool Create([FromBody] EmployeeViewModel vm)
        {
            return _service.Create(vm);
        }

        // POST api/employee/update
        [HttpPost]
        public bool Update([FromBody] EmployeeViewModel vm)
        {
            return _service.Update(vm);
        }

        // GET api/employee/delete/1
        [HttpGet("{Id}")]
        public bool Delete(String Id)
        {
            return _service.Delete(Id);
        }
    }
}

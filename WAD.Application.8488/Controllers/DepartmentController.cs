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
    public class DepartmentController : ControllerBase
    {
        DepartmentService _service;

        public DepartmentController(DepartmentService service)
        {
            _service = service;
        }

        // GET: api/department/getall
        [HttpGet]
        public IEnumerable<DepartmentViewModel> GetAll()
        {
            return _service.GetAll();
        }

        // GET api/department/get/1
        [HttpGet("{Id}")]
        public DepartmentViewModel Get(String Id)
        {
            return _service.GetById(Id);
        }

        // POST api/department/create
        [HttpPost]
        public bool Create([FromBody] DepartmentViewModel vm)
        {
            return _service.Create(vm);
        }

        // POST api/department/update
        [HttpPost]
        public bool Update([FromBody] DepartmentViewModel vm)
        {
            return _service.Update(vm);
        }

        // GET api/department/delete/1
        [HttpGet("{Id}")]
        public bool Delete(String Id)
        {
            return _service.Delete(Id);
        }

    }
}

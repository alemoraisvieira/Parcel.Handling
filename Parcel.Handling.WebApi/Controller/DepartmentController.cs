using DepartmentDBContext;
using Microsoft.AspNetCore.Mvc;
using Parcel.Handling.Application.common;
using Parcel.Handling.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcel.Handling.WebApi.Controller
{

    [Route("api/v1/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private ApiContext _context;


        public DepartmentController(IDepartmentService departmentService, ApiContext context) =>
            (_departmentService, _context) = (departmentService, context);


        [HttpGet]
        public IEnumerable<Department> GetDepartments()
        {
            return _context.Users;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _departmentService.DeleteDepartment(id);
            return Ok();
        }

        [HttpPost]
        [Route("new-department")]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentDto department)
        {
            if (department == null)
                return BadRequest();

            await _departmentService.AddDepartment(department);
            return Ok();
        }

        [HttpPost]
        [Route("first-departments")]
        public IActionResult AddDepartmentFirst()
        {

    
                var department1 = new Department
                {
                    Id = 1,
                    Name = "Mail"
                };

                _context.Users.Add(department1);

                var department2 = new Department
                {
                    Id = 2,
                    Name = "Regular"
                };

                _context.Users.Add(department2);

                var department3 = new Department
                {
                    Id = 3,
                    Name = "Heavy"
                };

                _context.Users.Add(department3);

                var department4 = new Department
                {
                    Id = 4,
                    Name = "Insurance"
                };

                _context.Users.Add(department4);
                _context.SaveChanges();

            return Ok();

        }
    }
}

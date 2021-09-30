﻿using DepartmentDBContext;
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

        public DepartmentController(IDepartmentService departmentService) =>
            (_departmentService) = (departmentService);


        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var result = await _departmentService.GetDepartments();
            if (!result.Any())
                return NoContent();

            return Ok(result);            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _departmentService.DeleteDepartment(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentDto department)
        {
            if (!department.Name.Any() || department is null)
                return BadRequest("Wrong parameters");

            await _departmentService.AddDepartment(department);
            return Created("created", department);
        }
    }
}

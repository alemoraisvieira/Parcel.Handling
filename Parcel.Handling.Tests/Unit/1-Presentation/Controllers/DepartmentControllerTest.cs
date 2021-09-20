using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Parcel.Handling.Application.common;
using Parcel.Handling.Application.Dto;
using Parcel.Handling.WebApi.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Parcel.Handling.Tests.Unit._1_Presentation.Controllers
{
    public class DepartmentControllerTest
    {
        private readonly DepartmentController _controller;
        private readonly IDepartmentService _service;

        public DepartmentControllerTest()
        {
            _service = Substitute.For<IDepartmentService>();
            _controller = new DepartmentController(_service);
        }


        [Fact]
        public async Task Should_call_service_to_get_department()
        {
            var result = await _controller.GetDepartments();

            result.Should().BeOfType<OkResult>;

            await _service.Received(1).GetDepartments();
    
        }

        [Fact]
        public async Task Should_call_service_to_add_department()
        {
            var department = new DepartmentDto() { };
            var result = await _controller.AddDepartment(department);

            result.Should().BeOfType<CreatedResult>;

            await _service.Received(1).AddDepartment(department);

        }
    }
     
}

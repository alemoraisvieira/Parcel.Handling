using DepartmentDBContext;
using Parcel.Handling.Application.Common;
using Parcel.Handling.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel.Handling.Infra
{
    public class DepartmentRespository : IContext
    {
        private ApiContext _context;

        public DepartmentRespository(ApiContext context) =>
            (_context) = ( context);

        public List<Department> GetDepartmentList()
        {
            var result = _context.Users.OrderBy( x=> x.Id).ToList();
            return result;
        }
        public Task DeleteDepartmentById(int id)
        {
            var department = _context.Users.FirstOrDefault(i => i.Id == id);
            if (department != null)
                _context.Users.Remove(department);
                _context.SaveChanges();
            return Task.CompletedTask;
        }
        public Task AddNewDepartment(DepartmentDto department)
        {
            
            var addDepartment = new Department
            {
                Name = department.Name
            };

            _context.Users.Add(addDepartment);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddNewFistDepartment()
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

            return Task.CompletedTask;
        }
    }
}

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
    public class Context : IContext
    {
        private ApiContext _context;

        public Context(ApiContext context) =>
            (_context) = ( context);
        

        public async Task DeleteDepartmentById(int id)
        {
            var department = _context.Users.FirstOrDefault(i => i.Id == id);
            _context.Users.Remove(department);
            _context.SaveChanges();
        }
        public async Task SetNewDepartment(DepartmentDto department)
        {
            
            var addDepartment = new Department
            {
                Id = department.Id,
                Name = department.Name
            };

            _context.Users.Add(addDepartment);
            _context.SaveChanges();

        }
    }
}

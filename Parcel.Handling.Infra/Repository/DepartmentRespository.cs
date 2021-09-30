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
    public class DepartmentRespository : IDepartmentRepository
    {
        private ApplicationDbContext _context;

        public DepartmentRespository(ApplicationDbContext context) =>
            (_context) = ( context);

        public Task <List<Department>> GetDepartmentList()
        {
            return Task.Run(() =>
            {
                var result = _context.Departments.OrderBy( x=> x.Id).ToList();
                return result;
            });
        }
        public Task DeleteDepartmentById(int id)
        {
            var department = _context.Departments.FirstOrDefault(i => i.Id == id);
            if (department != null)
                _context.Departments.Remove(department);
                _context.SaveChanges();
            return Task.CompletedTask;
        }
        public Task AddNewDepartment(DepartmentDto department)
        {
            
            var addDepartment = new Department
            {
                Name = department.Name
            };

            _context.Departments.Add(addDepartment);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

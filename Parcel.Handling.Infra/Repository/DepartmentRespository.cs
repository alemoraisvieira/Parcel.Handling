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

        public async Task <List<Department>> GetDepartmentList()
        {
            var result = _context.Departments.OrderBy( x=> x.Id).ToList();
            return await Task.FromResult(result);
        }
        public async Task DeleteDepartmentById(int id)
        {
            var department = _context.Departments.FirstOrDefault(i => i.Id == id);
            if (department != null)
                _context.Departments.Remove(department);
                _context.SaveChanges();
            await Task.CompletedTask;
        }
        public async Task AddNewDepartment(DepartmentDto department)
        {
            var addDepartment = new Department
            {
                Name = department.Name
            };

            _context.Departments.Add(addDepartment);
            _context.SaveChanges();
            await  Task.CompletedTask;
        }
    }
}

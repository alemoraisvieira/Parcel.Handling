using Parcel.Handling.Application.common;
using Parcel.Handling.Application.Common;
using Parcel.Handling.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parcel.Handling.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IContext _context;
        public DepartmentService(IContext context) =>
                    (_context) = (context);

        
        public async Task DeleteDepartment(int idDepartment)
        {
            await _context.DeleteDepartmentById(idDepartment);

        }
        public async Task AddDepartment(DepartmentDto department)
        {
            await _context.SetNewDepartment(department);

        }
    }
}

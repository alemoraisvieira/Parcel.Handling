using Parcel.Handling.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parcel.Handling.Application.common
{
    public interface IDepartmentService
    {
        Task DeleteDepartment(int id);
        Task AddDepartment(DepartmentDto department);
    }
}

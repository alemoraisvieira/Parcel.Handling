using Parcel.Handling.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parcel.Handling.Application.Common
{
    public interface IContext
    {
        Task DeleteDepartmentById(int idDepartment);
        List<Department> GetDepartmentList();
        Task AddNewDepartment(DepartmentDto department);
        Task AddNewFistDepartment();
    }
}

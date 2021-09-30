using DepartmentDBContext;
using Parcel.Handling.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parcel.Handling.Infra.DBContext
{
    public class SeedData
    {

        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            var departments = CreateDepartment();
            _context.Departments.AddRange(departments);
            _context.SaveChanges();
        }

        private static List<Department> CreateDepartment()
        {
            List<Department> departments = new List<Department>();
            departments.Add (new Department
            {
                Name = "Mail"
            });

            departments.Add(new Department
            {
                Name = "Regular"
            });

            departments.Add(new Department
            {
                Name = "Heavy"
            });

            departments.Add(new Department
            {
                Name = "Insurance"
            });
            return departments;
        }
    }

}

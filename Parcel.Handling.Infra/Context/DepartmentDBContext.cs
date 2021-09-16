using Microsoft.EntityFrameworkCore;
using Parcel.Handling.Application.Dto;

namespace DepartmentDBContext
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Users { get; set; }
        public DbSet<Package> Package { get; set; }


    }
}
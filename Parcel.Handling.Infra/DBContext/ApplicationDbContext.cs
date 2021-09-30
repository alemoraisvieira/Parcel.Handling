using Microsoft.EntityFrameworkCore;
using Parcel.Handling.Application.Dto;

namespace DepartmentDBContext
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Department> Departments { get; set; }
        public DbSet<Package> Packages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasKey(department => department.Id);
            modelBuilder.Entity<Package>().HasKey(package => package.Id);

        }
    }
}
using Demo.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Demo.Entities.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<MaximumHourLimit> MaximumHourLimit { get; set; }

        public DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }

        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }

        public DbSet<Salary> Salary { get; set; } 
        public DbSet<EmployeeCheckIn> EmployeeCheckIn { get; set; }
        public DbSet<EmployeeCheckOut> EmployeeCheckOut { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAttendance>()
                    .Property(e => e.TotalHours)
                         .HasConversion<double>();

            modelBuilder.Entity<Employee>().HasData(

                new Employee { EmployeeId = 1, FullName = "Bijay Mandal", Address = "Janakpur" },
                new Employee { EmployeeId = 2, FullName = "Sunil Mandal", Address = "Janakpur" }

            );
            modelBuilder.Entity<MaximumHourLimit>().HasData(
                new MaximumHourLimit { MaximumHourLimitId = 1, LimitPerDay = 24 }
                );

            modelBuilder.Entity<Salary>().HasData(
                new Salary { EmployeeSalaryId = 1, MinimumHour = 0, MaximumHour = 20, RatePerHour = 50 },
                new Salary { EmployeeSalaryId = 2, MinimumHour = 20, MaximumHour = 40, RatePerHour = 70 },
                new Salary { EmployeeSalaryId = 3, MinimumHour = 40, RatePerHour = 150 }
                );

           

        }

    }
}

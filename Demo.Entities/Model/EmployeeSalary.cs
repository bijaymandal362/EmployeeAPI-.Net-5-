using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    [Index(nameof(EmployeeId), nameof(StartDate), nameof(EndDate), IsUnique = true)]
    //[Index(nameof(EmployeeId), nameof(StartDate), IsUnique = true)]
    public class EmployeeSalary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeSalaryId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
  
        public decimal  TotalWorkingHour { get; set; }

        public decimal Rate { get; set; }

        public decimal NetAmount { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}

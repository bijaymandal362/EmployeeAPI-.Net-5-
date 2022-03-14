using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    [Index(nameof(EmployeeId),nameof(Date), IsUnique = true)]
    public class EmployeeAttendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeAttendanceId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public decimal TotalHours { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}

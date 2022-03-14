using System;

namespace Demo.Models
{
    public class EmployeeSalaryViewModel
    {
        public int EmployeeSalaryId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalWorkingHour { get; set; }
        public decimal Rate { get; set; }
        public decimal NetAmount { get; set; }
    }
}

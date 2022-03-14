using System;

namespace Demo.Models
{
    public class EmployeeAttendanceViewModel
    {
        public int EmployeeAttendanceId { get; set; }


        public int EmployeeId { get; set; }

       
        public decimal TotalHours { get; set; }

        public DateTime Date { get; set; }

    }
}

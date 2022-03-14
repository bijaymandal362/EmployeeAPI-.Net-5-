using System;

namespace Demo.Models.ViewModel
{
    public class EmployeeCheckInViewModel
    {
        public int EmployeeCheckInID { get; set; }
        public int EmployeeId { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string CheckIn { get; set; }
    }
}

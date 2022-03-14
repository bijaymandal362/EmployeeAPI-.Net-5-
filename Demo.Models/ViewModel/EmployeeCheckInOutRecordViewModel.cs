using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models.ViewModel
{
    public class EmployeeCheckInOutRecordViewModel
    {
        public int EmployeeId { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
    }
}

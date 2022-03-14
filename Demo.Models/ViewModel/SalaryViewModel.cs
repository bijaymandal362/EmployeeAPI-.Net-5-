using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
  public  class SalaryViewModel
    {
        public int EmployeeSalaryId { get; set; }
        public decimal MinimumHour { get; set; }
        public decimal MaximumHour { get; set; }
        public decimal RatePerHour { get; set; }
    }
}

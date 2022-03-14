using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entities.Model
{
    public class EmployeeCheckIn
    {
        [Key]
        public int EmployeeCheckInID { get; set; }
        public int EmployeeId { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string CheckIn { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}

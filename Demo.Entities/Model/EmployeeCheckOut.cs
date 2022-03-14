using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities.Model
{
    public class EmployeeCheckOut
    {
        [Key]
        public int EmployeeCheckOutId { get; set; }
        public int EmployeeId { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string CheckOut { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}

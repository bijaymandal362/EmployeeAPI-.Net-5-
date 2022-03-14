using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int EmployeeSalaryId { get; set; }
        public decimal MinimumHour { get; set; }
        public decimal? MaximumHour { get; set; }
        public decimal RatePerHour { get; set; }

    }
}

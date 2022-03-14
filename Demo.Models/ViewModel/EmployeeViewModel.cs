using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class EmployeeViewModel
    {

        public int EmployeeId { get; set; }

        [Required]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
    }
}

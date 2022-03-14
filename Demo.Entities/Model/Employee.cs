using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string FullName { get; set; }
        [Required]
        [Column(TypeName = "NVARCHAR(30)")]
        public string Address { get; set; }
    }
}

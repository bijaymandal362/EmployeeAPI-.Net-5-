using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    public class MaximumHourLimit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaximumHourLimitId { get; set; }

        public decimal LimitPerDay { get; set; }
    }
}

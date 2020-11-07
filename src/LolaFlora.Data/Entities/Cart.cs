using LolaFlora.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace LolaFlora.Data.Entities
{
    public class Cart : BaseEntity
    {
        [Required]
        [Display(Name = "MinCount")]
        public int? MinCount { get; set; }
    }
}

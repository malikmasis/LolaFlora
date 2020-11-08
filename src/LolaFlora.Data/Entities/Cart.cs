using LolaFlora.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LolaFlora.Data.Entities
{
    public class Cart : BaseEntity
    {
        [Column(Order = 1)]
        public long? UserId { get; set; }
        [Column(Order = 2)]
        [Required]
        public long ProductId { get; set; }
        public Product Product { get; set; }

    }
}

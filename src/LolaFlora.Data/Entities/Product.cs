using LolaFlora.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LolaFlora.Data.Entities
{
    public class Product : BaseEntity
    {
        [Column(Order = 1)]
        public string Name { get; set; }
        [Column(Order = 2)]
        public string Price { get; set; }
        [Column(Order = 3)]
        public long Quantity { get; set; }
        [Column(Order = 4)]
        public long CategoryId { get; set; }
    }
}

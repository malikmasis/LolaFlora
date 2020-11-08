using LolaFlora.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LolaFlora.Data.Entities
{
    public class Category : BaseEntity
    {
        [Column(Order = 1)]
        public string Name { get; set; }
    }
}

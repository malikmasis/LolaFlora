using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LolaFlora.Data.Base
{
    public abstract class BaseEntity
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(Order = 1000)]
        public DateTime? CreatedDateTime { get; set; } = DateTime.UtcNow;

        [Column(Order = 1001)]
        public long? CreatedUser { get; set; }

        [Column(Order = 1002)]
        public DateTime? UpdatedDateTime { get; set; }

        [Column(Order = 1003)]
        public long? UpdatedUser { get; set; }

        [Column(Order = 1004)]
        public DateTime? DeletedDateTime { get; set; }

        [Column(Order = 1005)]
        public long? DeletedUser { get; set; }
    }
}

using LolaFlora.Data.Entities;
using System.Collections.Generic;

namespace LolaFlora.Common.Models
{
    public class MyCart
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public int Count
        {
            get { return Products.Count; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartApi.Models;

namespace CartApi.Entities
{
    public class CartItem : BaseEntity
    {
        public long ProductIdInCart { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}

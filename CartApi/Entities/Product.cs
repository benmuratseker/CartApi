using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Entities
{
    public class Product: BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; } = 10;//default units in stock value
    }
}

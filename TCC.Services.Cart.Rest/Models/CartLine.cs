using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Services.Cart.Rest.Models
{
    public class CartLine
    {
        public Guid CartLineId { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
    }
}

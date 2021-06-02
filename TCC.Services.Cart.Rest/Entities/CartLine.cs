using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Services.Cart.Rest.Entities
{
    public class CartLine
    {
        public Guid CartLineId { get; set; }

        [Required]
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }   
    }
}

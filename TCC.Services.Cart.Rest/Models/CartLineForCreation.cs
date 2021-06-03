using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Services.Cart.Rest.Models
{
    public class CartLineForCreation
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public decimal Price { get; set; }        
    }
}

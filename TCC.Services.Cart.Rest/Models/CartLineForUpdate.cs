using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Services.Cart.Rest.Models
{
    public class CartLineForUpdate
    {
        [Required]
        public int Qty { get; set; }
    }
}

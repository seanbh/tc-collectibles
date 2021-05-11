using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.App.BlazorWeb.ViewModels
{
    public class ProductNestedViewModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }        
        public Guid CategoryId { get; set; }
    }
}

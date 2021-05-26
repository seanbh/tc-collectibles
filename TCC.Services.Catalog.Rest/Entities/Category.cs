﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Services.Catalog.Rest.Entities
{
	public class Category
	{
		public Guid CategoryId { get; set; }
		public string Name { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}

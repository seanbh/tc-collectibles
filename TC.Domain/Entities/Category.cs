﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.Domain.Entities
{
	public class Category : AuditableEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}

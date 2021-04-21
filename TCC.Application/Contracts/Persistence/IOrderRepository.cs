﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Domain.Entities;

namespace TCC.Application.Contracts.Persistence
{
	public interface IOrderRepository : IAsyncRepository<Order>
	{
	}
}

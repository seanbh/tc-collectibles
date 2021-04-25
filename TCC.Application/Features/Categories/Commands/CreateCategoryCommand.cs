﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Categories.Commands
{
	public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
	{
		public string Name { get; set; }
	}
}

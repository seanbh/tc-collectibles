using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Responses;

namespace TCC.Application.Features.Categories.Commands
{
	public class CreateCategoryCommandResponse : BaseResponse
	{
		public CreateCategoryCommandResponse() : base()
		{

		}

		public CreateCategoryDto Category { get; set; }
	}
}

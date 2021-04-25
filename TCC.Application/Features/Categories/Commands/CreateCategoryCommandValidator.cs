using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Categories.Commands
{
	public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
	{
		public CreateCategoryCommandValidator()
		{
			RuleFor(c => c.Name)
				.NotEmpty().WithMessage("Name is required")
				.NotNull()
				.MaximumLength(50).WithMessage("Name must not exceed 50 characters");
		}
	}
}

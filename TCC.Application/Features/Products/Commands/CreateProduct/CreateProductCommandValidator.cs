using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Application.Features.Products.Commands.CreateProduct
{
	public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
	{
		public CreateProductCommandValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty().WithMessage("Name required")
				.NotNull()
				.MaximumLength(50);

			RuleFor(p => p.Price)
				.NotEmpty().WithMessage("Price is required")
				.GreaterThan(0);
		}
	}
}

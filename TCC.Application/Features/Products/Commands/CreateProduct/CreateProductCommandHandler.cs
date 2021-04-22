using AutoMapper;
using GloboTicket.TicketManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;
using TCC.Domain.Entities;

namespace TCC.Application.Features.Products.Commands.CreateProduct
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
	{
		private readonly Mapper mapper;
		private readonly IProductRepository repository;

		public CreateProductCommandHandler(Mapper mapper, IProductRepository repository)
		{
			this.mapper = mapper;
			this.repository = repository;
		}
		public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateProductCommandValidator();
			var validationResult = await validator.ValidateAsync(request);

			if(validationResult.Errors.Any())
			{
				throw new ValidationException(validationResult);
			}

			var product = mapper.Map<Product>(request);
			product = await repository.AddAsync(product);
			return product.ProductId;
		}
	}
}

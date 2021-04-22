using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;
using TCC.Domain.Entities;

namespace TCC.Application.Features.Products.Commands.UpdateProduct
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
	{
		private readonly Mapper mapper;
		private readonly IProductRepository repository;

		public UpdateProductCommandHandler(Mapper mapper, IProductRepository repository)
		{
			this.mapper = mapper;
			this.repository = repository;
		}
		public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var productToUpdate = await repository.GetByIdAsync(request.Id);
			mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));
			await repository.UpdateAsync(productToUpdate);

			return Unit.Value;
		}
	}
}

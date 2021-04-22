using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCC.Application.Contracts.Persistence;

namespace TCC.Application.Features.Products.Commands.DeleteProduct
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
	{
		private readonly Mapper mapper;
		private readonly IProductRepository repository;

		public DeleteProductCommandHandler(Mapper mapper, IProductRepository repository)
		{
			this.mapper = mapper;
			this.repository = repository;
		}
		public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			var product = await repository.GetByIdAsync(request.ProductId);
			await repository.DeleteAsync(product);

			return Unit.Value;
		}
	}
}

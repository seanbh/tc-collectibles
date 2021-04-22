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

namespace TCC.Application.Features.Products.Queries.GetProductsList
{
	public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductListVm>>
	{
		private readonly IMapper mapper;
		private readonly IAsyncRepository<Product> productRepository;

		public GetProductsListQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
		{
			this.mapper = mapper;
			this.productRepository = productRepository;
		}
		public async Task<List<ProductListVm>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
		{
			var allProducts = (await productRepository.ListAllAsync()).OrderBy(p => p.Name);
			return mapper.Map<List<ProductListVm>>(allProducts);
		}
	}
}

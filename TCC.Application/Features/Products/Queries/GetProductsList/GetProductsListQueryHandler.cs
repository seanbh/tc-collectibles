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
		private readonly IMapper _mapper;
		private readonly IAsyncRepository<Product> _productRepository;

		public GetProductsListQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
		{
			_mapper = mapper;
			_productRepository = productRepository;
		}
		public async Task<List<ProductListVm>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
		{
			var allProducts = (await _productRepository.ListAllAsync()).OrderBy(p => p.Name);
			return _mapper.Map<List<ProductListVm>>(allProducts);
		}
	}
}

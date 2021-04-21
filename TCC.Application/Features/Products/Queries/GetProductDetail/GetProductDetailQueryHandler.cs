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

namespace TCC.Application.Features.Products.Queries.GetProductDetail
{
	public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
	{
		private readonly IMapper _mapper;
		private readonly IAsyncRepository<Product> _productRepository;
		private readonly IAsyncRepository<Category> _categoryRepository;

		public GetProductDetailQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository, IAsyncRepository<Category> categoryRepository)
		{
			_mapper = mapper;
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
		}
		public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
		{
			var productDetail = await _productRepository.GetByIdAsync(request.Id);
			var productDetailVm = _mapper.Map<ProductDetailVm>(productDetail);

			var category = _categoryRepository.GetByIdAsync(productDetail.CategoryId);
			productDetailVm.CategoryDto = _mapper.Map<CategoryDto>(category);

			return productDetailVm;
		}
	}
}

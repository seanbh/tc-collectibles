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

namespace TCC.Application.Features.Categories.Commands
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
	{
		private readonly IMapper mapper;
		private readonly ICategoryRepository repository;

		public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository repository)
		{
			this.mapper = mapper;
			this.repository = repository;
		}

		public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var createCategoryCommandResponse = new CreateCategoryCommandResponse();

			var validationResult = await new CreateCategoryCommandValidator().ValidateAsync(request);
			if (!validationResult.IsValid)
			{
				createCategoryCommandResponse.Success = false;
				createCategoryCommandResponse.ValidationErrors = new List<string>();
				foreach (var error in validationResult.Errors)
				{
					createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
				}
			}
			else
			{
				var category = await repository.AddAsync(new Category() { Name = request.Name });
				var categoryDto = mapper.Map<CreateCategoryDto>(category);
				createCategoryCommandResponse.Category = categoryDto;
			}

			return createCategoryCommandResponse;
		}
	}
}

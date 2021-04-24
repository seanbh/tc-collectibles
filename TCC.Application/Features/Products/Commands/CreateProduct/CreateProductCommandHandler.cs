using AutoMapper;
using GloboTicket.TicketManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCC.Application.Contracts.Infrastructure;
using TCC.Application.Contracts.Persistence;
using TCC.Application.Models.Mail;
using TCC.Domain.Entities;

namespace TCC.Application.Features.Products.Commands.CreateProduct
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
	{
		private readonly IMapper mapper;
		private readonly IProductRepository repository;
		private readonly IEmailService emailService;

		public CreateProductCommandHandler(IMapper mapper, IProductRepository repository, IEmailService emailService)
		{
			this.mapper = mapper;
			this.repository = repository;
			this.emailService = emailService;
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

			try
			{
				await emailService.SendEmail(new Email() { To="seanhaddock@live.com", Body="Product created", Subject="Product Created" });
			}
			catch (Exception ex)
			{
				// todo: log
			}
			return product.ProductId;
		}
	}
}

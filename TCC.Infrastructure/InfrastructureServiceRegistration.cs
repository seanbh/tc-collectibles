﻿using TCC.Application.Contracts.Infrastructure;
using TCC.Application.Models.Mail;
using TCC.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCC.Infrastructure.FileExport;

namespace TCC.Infrastructure
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

			services.AddTransient<IEmailService, EmailService>();
			services.AddScoped<ICsvExporter, CsvExporter>();

			return services;
		}
	}
}

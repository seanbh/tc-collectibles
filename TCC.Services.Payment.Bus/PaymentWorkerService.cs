using Microsoft.Azure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Rebus.Activation;
using Rebus.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCC.Services.Payment.Bus
{
	public class PaymentWorkerService : BackgroundService
	{
		private readonly IConfiguration config;

		public PaymentWorkerService(IConfiguration config)
		{
			this.config = config;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var connstring = config["AzureQueues:ConnectionString"];
			var storageAccount = CloudStorageAccount.Parse(connstring);

			using var activator = new BuiltinHandlerActivator();
			activator.Register(() => new PaymentHandler());
			Configure.With(activator)
				.Transport(t => t.UseAzureStorageQueues(storageAccount, config["AzureQueues:QueueName"]))
				.Start();

			await Task.Delay(Timeout.InfiniteTimeSpan, stoppingToken);
		}
	}
}

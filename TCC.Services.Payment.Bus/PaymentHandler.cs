using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Messages;

namespace TCC.Services.Payment.Bus
{
	public class PaymentHandler : IHandleMessages<PaymentRequestMessage>
	{
		public Task Handle(PaymentRequestMessage message)
		{
			Console.WriteLine($"Payment request received for basket id {message.CartId}.");
			return Task.CompletedTask;
		}
	}
}

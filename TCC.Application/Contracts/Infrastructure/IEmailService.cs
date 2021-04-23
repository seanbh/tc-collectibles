using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Application.Models.Mail;

namespace TCC.Application.Contracts.Infrastructure
{
	public interface IEmailService
	{
		Task<bool> SendEmail(Email email);
	}
}

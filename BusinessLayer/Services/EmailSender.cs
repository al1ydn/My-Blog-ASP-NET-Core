using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using PostmarkDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
	public class EmailSender : IEmailSender
	{
		public EmailSender(IOptions<AuthMessageSenderOptions> options)
		{
			Options = options.Value;
		}

        public AuthMessageSenderOptions Options { get; set; }

        public async Task SendEmailAsync(string email, 
										 string subject, 
										 string htmlMessage)
		{
			await Execute(Options.PostmarkServerApiToken, 
						  subject, 
						  htmlMessage, 
						  email);
		}

		public async Task Execute(string PostmarkServerApiToken,
								  string subject, 
								  string htmlMessage, 
								  string email)
		{
			var client  = new PostmarkClient(PostmarkServerApiToken);

			var message = new PostmarkMessage()
			{
				From = "confirm-mail@pafe.site",
				To = email,
				Subject = subject,
				TextBody = htmlMessage,
				HtmlBody = htmlMessage,
			};

			var sendResult = await client.SendMessageAsync(message);

			if (sendResult.Status != PostmarkStatus.Success)
			{
				throw new NotImplementedException();
			}
		}
	}
}

using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Services.EmailSenderService
{
	public class EmailSender : IEmailSender
	{
		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			MailMessage mail = new MailMessage();
			mail.IsBodyHtml= true;
			mail.To.Add(email);
			mail.From = new MailAddress("humanresourcehs8@gmail.com", "Admin",System.Text.Encoding.UTF8);
			mail.Subject = subject;
			mail.Body = htmlMessage;
			SmtpClient smp = new SmtpClient();
			smp.Credentials = new NetworkCredential("humanresourcehs8@gmail.com", "letjphjlfbbzxdsd");
			smp.Port = 587;
			smp.Host = "smtp.gmail.com";
			smp.EnableSsl = true;
			smp.Send(mail);
			return Task.CompletedTask;

		}
	}
}

using HumanResource.Application.Models.VMs.EmailVM;
using MimeKit;

namespace HumanResource.Application.Services.EmailSenderService
{
    public interface IEmailService
    {
        void SendEmail(Message message);
        MimeMessage CreateEmailMessage(Message message);
        void Send(MimeMessage mailMessage);
    }
}

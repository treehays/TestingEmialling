using FluentEmail.Core;
using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using System.Transactions;
using System;

namespace TestingEmialling.Utils
{
    public class MailSender : IMailSender
    {
        private readonly IServiceProvider _serviceProvider;

        public MailSender(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async void SendPlainTextGmail(string reciepientEmail, string recipientName)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mailer = scope.ServiceProvider.GetRequiredService<IFluentEmail>();
                var email = mailer
                    .To(reciepientEmail, recipientName)
                    .Subject("This is testin Subject")
                    .Body("This is the whole bodym this is a body");
                await email.SendAsync();
            }
        }


        public async void SendHtmlGmail(string reciepientEmail, string recipientName)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mailer = scope.ServiceProvider.GetRequiredService<IFluentEmail>();
                var email = mailer
                    .To(reciepientEmail, recipientName)
                    .Subject("HTML Subject")
                    .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/wwwroot/emails/sampleEmail.cshtml",
                    new
                    {
                        Name = reciepientEmail,
                    });
                await email.SendAsync();
            }
        }


        public async void SendHtmlWithAttachmentGmail(string reciepientEmail, string recipientName)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mailer = scope.ServiceProvider.GetRequiredService<IFluentEmail>();
                var email = mailer
                    .To(reciepientEmail, recipientName)
                    .Subject("HTML Subject")
                    .AttachFromFilename($"{Directory.GetCurrentDirectory()}/wwwroot/files/sample.pdf", "application/pdf", "AhmadCV.pdf")
                    .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/wwwroot/email/sampleEmail.cshtml",
                    new
                    {
                        Name = reciepientEmail,
                    });
                await email.SendAsync();
            }
        }


        public async void SendPlainTextSendGrid(string reciepientEmail, string recipientName)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mailer = scope.ServiceProvider.GetRequiredService<IFluentEmail>();
                var email = mailer
                    .To(reciepientEmail, recipientName)
                    .Subject("This is testin Subject")
                    .Body("This is the whole bodym this is a body");
                await email.SendAsync();
            }
        }


        public async void SendHtmlSendGrid(string reciepientEmail, string recipientName)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mailer = scope.ServiceProvider.GetRequiredService<IFluentEmail>();
                var email = mailer
                    .To(reciepientEmail, recipientName)
                    .Subject("HTML Subject")
                    .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/wwwroot/emails/sampleEmail.cshtml",
                    new
                    {
                        Name = reciepientEmail,
                    });
                await email.SendAsync();
            }
        }

        public async void SendHtmlWithAttachmentSendGrid(string reciepientEmail, string recipientName)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mailer = scope.ServiceProvider.GetRequiredService<IFluentEmail>();
                var email = mailer
                    .To(reciepientEmail, recipientName)
                    .Subject("HTML Subject")
                    .AttachFromFilename($"{Directory.GetCurrentDirectory()}/wwwroot/files/sample.pdf", "application/pdf", "AhmadCV.pdf")
                    .UsingTemplateFromFile($"{Directory.GetCurrentDirectory()}/wwwroot/email/sampleEmail.cshtml",
                    new
                    {
                        Name = reciepientEmail,
                    });
                await email.SendAsync();
            }
        }


        public void SendSendGridBulk(List<string> reciepientEmail)
        {
            throw new NotImplementedException();
        }
    }
}

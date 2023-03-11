using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using TestingEmialling.Models;
using TestingEmialling.Utils;

namespace TestingEmialling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailSender _mailSender;
        public HomeController(ILogger<HomeController> logger, IMailSender mailSender)
        {
            _logger = logger;
            _mailSender = mailSender;
        }

        //public IActionResult Index([FromServices] IFluentEmail fluentEmail)
        public IActionResult Index()
        {

            //_mailSender.SendPlainTextGmail("aymoneyay@gmail.com", "Abdulsalam Ahmad");




            //var email = fluentEmail
            //    .To("aymoenyay@gmail.com", "Mark Ahmad")
            //    .Subject("This is testin Subject")
            //    .Body("This is the whole bodym this is a body");
            //await email.SendAsync();




            //var sender = new SmtpSender(() => new SmtpClient("smtp,gmail.com")
            //{
            //    UseDefaultCredentials = false,
            //    Port = 587,
            //    Credentials = new NetworkCredential("clhprojecttest@gmail.com", "CLH12345"),
            //    EnableSsl = true,
            //});
            //Email.DefaultSender = sender;
            //var email = Email
            //    .From("clhprojecttest@gmail.com", "Abduksalaj Ahmad")
            //    .To("aymoenyay@gmail.com", "Mark Ahmad")
            //    .Subject("This is testin Subject")
            //    .Body("This is the whole bodym this is a body");
            //try
            //{

            //    await email.SendAsync();
            //}
            //catch (Exception e)
            //{

            //    throw;
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using FluentEmail.SendGrid;
using System.Net;
using System.Net.Mail;
using TestingEmialling.Utils;

namespace TestingEmialling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IMailSender, MailSender>();



            //This for Grid andd
            var from = builder.Configuration.GetSection("Mail")["From"];

            var sendGridSender = builder.Configuration.GetSection("SendGrid")["Sender"];
            var sendGridKey = builder.Configuration.GetSection("SendGrid")["SendGridKey"];


            builder.Services.AddFluentEmail(sendGridSender, from)
               .AddRazorRenderer()
               .AddSendGridSender(sendGridKey);







            ////This for GMail 
            //var gmailSender = builder.Configuration.GetSection("Gmail")["Sender"];
            //var gmailPassword = builder.Configuration.GetSection("Gmail")["Password"];
            //var gmailPort = Convert.ToInt32(builder.Configuration.GetSection("Gmail")["Port"]);
            //This for GMail SMTP
            //builder.Services.AddFluentEmail(gmailSender, from)
            //   .AddRazorRenderer()
            //   .AddSmtpSender(new SmtpClient("smtp.gmail.com")
            //   {
            //       UseDefaultCredentials = false,
            //       Port = gmailPort,
            //       Credentials = new NetworkCredential(gmailSender, gmailPassword),
            //       EnableSsl = true,
            //   });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
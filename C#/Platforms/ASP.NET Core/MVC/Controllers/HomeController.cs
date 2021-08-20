using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using EmailCoreMvc.Models;
using GemBox.Email;
using GemBox.Email.Mime;

namespace EmailCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        static HomeController()
        {
            // If using Professional version, put your serial key below.
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public IActionResult Index()
        {
            return View(new MessageModel());
        }

        public FileStreamResult Download(MessageModel model)
        {
            // Create email.
            var message = new MailMessage(model.Sender, model.Receiver)
            {
                Subject = model.Subject,
                BodyHtml = model.Message
            };

            // Save email in specified file format.
            var stream = new MemoryStream();
            message.Save(stream, MailMessageFormat.Eml);
            stream.Position = 0;

            // Download file.
            return File(stream, MediaTypes.MessageRfc822, "OutputFromView.eml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

namespace EmailCoreMvc.Models
{
    public class MessageModel
    {
        [EmailAddress, Required]
        public string Sender { get; set; } = "sender@example.com";
        [EmailAddress, Required]
        public string Receiver { get; set; } = "receiver@example.com";
        public string Subject { get; set; } = "Example Message";
        public string Message { get; set; } =
            "This is an example message created with " +
            "<a href='https://www.gemboxsoftware.com/email'>GemBox.Email</a> from " +
            "<strong style='color:red'>ASP.NET Core</strong> application!";
    }
}

using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmailCorePages.Models;
using GemBox.Email;
using GemBox.Email.Mime;

namespace EmailCorePages.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public MessageModel Message { get; set; }

        public IndexModel()
        {
            this.Message = new MessageModel();

            // If using Professional version, put your serial key below.
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public void OnGet() { }

        public FileContentResult OnPost()
        {
            // Create email.
            var message = new MailMessage(this.Message.Sender, this.Message.Receiver)
            {
                Subject = this.Message.Subject,
                BodyHtml = this.Message.Message
            };

            // Save email in specified file format.
            var stream = new MemoryStream();
            message.Save(stream, MailMessageFormat.Eml);
            stream.Position = 0;

            // Download file.
            return File(stream.ToArray(), MediaTypes.MessageRfc822, "OutputFromPage.eml");
        }
    }
}

namespace EmailCorePages.Models
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

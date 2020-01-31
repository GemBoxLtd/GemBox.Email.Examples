using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IO;
using GemBox.Email;
using GemBox.Email.Mime;

namespace AspNetCore.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult Create() => View();
        
        [HttpPost]
        public ActionResult Create(MessageModel model)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            if (!ModelState.IsValid)
                return View(model);

            var message = new MailMessage(model.Sender, model.Receiver)
            {
                Subject = model.Subject,
                BodyText = model.BodyText,
                BodyHtml = model.BodyHtml
            };

            using (var messageStream = new MemoryStream())
            {
                message.Save(messageStream, MailMessageFormat.Eml);
                return File(messageStream.ToArray(), MediaTypes.MessageRfc822, "Save.eml");
            }
        }
    }

    public class MessageModel
    {
        [Display(Name = "Sender"), Required, EmailAddress]
        public string Sender { get; set; }

        [Display(Name = "Receiver"), Required, EmailAddress]
        public string Receiver { get; set; }

        [Display(Name = "Subject"), Required]
        public string Subject { get; set; }

        [Display(Name = "Plain message")]
        public string BodyText { get; set; }

        [Display(Name = "HTML message")]
        public string BodyHtml { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IO;
using GemBox.Email;

namespace GemBox.SaveMessage.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(MessageModel messageModel)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            if (!ModelState.IsValid)
                return View(messageModel);

            MailMessage message = new MailMessage(
                new MailAddress(messageModel.SenderAddress),
                new MailAddress(messageModel.ReceiverAddress));
            message.Subject = messageModel.Subject;
            message.BodyText = messageModel.BodyText;

            if (!string.IsNullOrEmpty(messageModel.BodyHtml))
                message.BodyHtml = messageModel.BodyHtml;

            return File(WriteMessageToByteArray(message), "message/rfc822", "Save.eml");
        }

        private byte[] WriteMessageToByteArray(MailMessage message)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                message.Save(stream, MailMessageFormat.Eml);
                return stream.ToArray();
            }
        }
    }

    public class MessageModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Sender address:")]
        public string SenderAddress { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Receiver address:")]
        public string ReceiverAddress { get; set; }
        [Required]
        [Display(Name = "Subject:")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Raw email message:")]
        public string BodyText { get; set; }
        [Display(Name = "HTML email message:")]
        public string BodyHtml { get; set; }
    }
}

using GemBox.Email;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        Example1();
        Example2();
    }

    static void Example1()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message.
        MailMessage message = new MailMessage(
            new MailAddress("sender@example.com", "Sender"),
            new MailAddress("receiver@example.com", "Receiver"));

        // Add subject and body.
        message.Subject = "Save Example by GemBox.Email";
        message.BodyText = "Hi 👋,\n" +
            "This message was created and saved with GemBox.Email.\n" +
            "Read more about it on https://www.gemboxsoftware.com/email";

        // Save message to email file.
        message.Save("Save.eml");
    }

    static void Example2()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        var message = MailMessage.Load("Attachment.eml");
        string zipName = Path.ChangeExtension("Attachment.eml", ".zip");

        using (var archiveStream = File.OpenWrite(zipName))
        using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create))
        {
            foreach (var attachment in message.Attachments)
            {
                string attachmentName = attachment.FileName ?? Path.GetRandomFileName();
                var entry = archive.CreateEntry(attachmentName);

                using (var entryStream = entry.Open())
                    attachment.Save(entryStream);
            }
        }
    }
}

using GemBox.Document;
using GemBox.Email;
using GemBox.Email.Mime;
using System.Linq;

class Program
{
    static void Main()
    {
        Example1();
        Example2();
    }

    static void Example1()
    {
        // If using the Professional version, put your GemBox.Email serial key below.
        GemBox.Email.ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // If using the Professional version, put your GemBox.Document serial key below.
        GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load an email file.
        MailMessage message = MailMessage.Load("Html.eml");

        // Create a new document.
        DocumentModel document = new DocumentModel();

        // Import the email's body to the document.
        if (!string.IsNullOrEmpty(message.BodyHtml))
            document.Content.End.LoadText(message.GetEmbeddedBodyHtml(), LoadOptions.HtmlDefault);
        else
            document.Content.End.LoadText(message.BodyText, LoadOptions.TxtDefault);

        // Save the document as PDF.
        document.Save("Export.pdf");
    }

    static void Example2()
    {
        // If using the Professional version, put your GemBox.Email serial key below.
        GemBox.Email.ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // If using the Professional version, put your GemBox.Document serial key below.
        GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Load an email file.
        MailMessage message = MailMessage.Load("Attachment.eml");

        // Create a new document.
        DocumentModel document = new DocumentModel();

        // Import the email's content to the document.
        LoadHeaders(message, document);
        LoadBody(message, document);
        LoadAttachments(message.Attachments, document);

        // Save the document as PDF.
        document.Save("ExportWithAttachments.pdf");
    }

    static void LoadHeaders(MailMessage message, DocumentModel document)
    {
        // Create HTML content from the email headers.
        var htmlHeaders = $@"
            <style>
              * {{ font-size: 12px; font-family: Calibri; }}
              th {{ text-align: left; padding-right: 24px; }}
            </style>
            <table>
              <tr><th>From:</th><td>{message.From[0].ToString().Replace("<", "&lt;").Replace(">", "&gt;")}</td></tr>
              <tr><th>Sent:</th><td>{message.Date:dddd, d MMM yyyy}</td></tr>
              <tr><th>To:</th><td>{message.To[0].ToString().Replace("<", "&lt;").Replace(">", "&gt;")}</td></tr>
              <tr><th>Subject:</th><td>{message.Subject}</td></tr>
            </table>
            <hr>";

        // Load the HTML headers to the document.
        document.Content.End.LoadText(htmlHeaders, LoadOptions.HtmlDefault);
    }

    static void LoadBody(MailMessage message, DocumentModel document)
    {
        if (!string.IsNullOrEmpty(message.BodyHtml))
            // Load the HTML body to the document.
            document.Content.End.LoadText(
                message.GetEmbeddedBodyHtml(),
                LoadOptions.HtmlDefault);
        else
            // Load the TXT body to the document.
            document.Content.End.LoadText(
                message.BodyText,
                LoadOptions.TxtDefault);
    }

    static void LoadAttachments(AttachmentCollection attachments, DocumentModel document)
    {
        var htmlSubtitle = "<hr><p style='font: bold 12px Calibri;'>Attachments:</p>";
        document.Content.End.LoadText(htmlSubtitle, LoadOptions.HtmlDefault);

        foreach (Attachment attachment in attachments.Where(
            a => a.DispositionType == ContentDispositionType.Attachment &&
                 a.MimeEntity.ContentType.TopLevelType == "image"))
        {
            document.Content.End.InsertRange(
                new Paragraph(document, new Picture(document, attachment.Data)).Content);
        }
    }
}

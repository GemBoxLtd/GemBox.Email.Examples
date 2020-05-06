Imports System.Linq
Imports System.Text.RegularExpressions
Imports GemBox.Document
Imports GemBox.Email
Imports GemBox.Email.Mime

Module Program
    Sub Main()

        ' If using Professional version, put your GemBox.Email serial key below.
        GemBox.Email.ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' If using Professional version, put your GemBox.Document serial key below.
        GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Load email file.
        Dim message As MailMessage = MailMessage.Load("Attachment.eml")

        ' Create new document.
        Dim document As DocumentModel = New DocumentModel()

        ' Import email's content to document.
        LoadHeaders(message, document)
        LoadBody(message, document)
        LoadAttachments(message.Attachments, document)

        ' Save document as PDF.
        document.Save("Export.pdf")

    End Sub

    Sub LoadHeaders(message As MailMessage, document As DocumentModel)

        ' Create HTML content from headers.
        Dim htmlHeaders = $"
            <style>
              * {{ font-size: 12px; font-family: Calibri; }}
              th {{ text-align: left; padding-right: 24px; }}
            </style>
            <table>
              <tr><th>From:</th><td>{message.From(0).ToString().Replace("< ", " & lt;").Replace(">", "&gt;")}</td></tr>
              <tr><th>Sent:</th><td>{message.Date:dddd, d MMM yyyy}</td></tr>
              <tr><th>To:</th><td>{message.To(0).ToString().Replace("<", "&lt;").Replace(">", "&gt;")}</td></tr>
              <tr><th>Subject:</th><td>{message.Subject}</td></tr>
            </table>
            <hr>"

        ' Load HTML headers to document.
        document.Content.End.LoadText(htmlHeaders, LoadOptions.HtmlDefault)

    End Sub

    Sub LoadBody(message As MailMessage, document As DocumentModel)

        If Not String.IsNullOrEmpty(message.BodyHtml) Then
            ' Replace attached CID images to inlined DATA urls.
            Dim htmlBody = ReplaceEmbeddedImages(message.BodyHtml, message.Attachments)

            ' Load HTML body to document.
            document.Content.End.LoadText(htmlBody, LoadOptions.HtmlDefault)
        Else
            ' Load TXT body to document.
            document.Content.End.LoadText(message.BodyText, LoadOptions.TxtDefault)
        End If

    End Sub

    Function ReplaceEmbeddedImages(htmlBody As String, attachments As AttachmentCollection) As String

        Dim srcPattern =
            "(?<=<img.+?src=[""'])" &
            "(.+?)" &
            "(?=[""'].*?>)"

        ' Iterate through "src" attributes from HTML images in reverse order.
        For Each match In Regex.Matches(htmlBody, srcPattern, RegexOptions.IgnoreCase).Cast(Of Match)().Reverse()
            Dim imageId = match.Value.Replace("cid:", "")
            Dim attachment As Attachment = attachments.FirstOrDefault(Function(a) a.ContentId = imageId)

            If attachment IsNot Nothing Then
                ' Create inlined image data. E.g. "data:image/png;base64,AABBCC..."
                Dim entity As ContentEntity = attachment.MimeEntity
                Dim embeddedImage = entity.Charset.GetString(entity.Content)
                Dim embeddedSrc = $"data:{entity.ContentType};{entity.TransferEncoding},{embeddedImage}"

                ' Replace "src" attribute with inlined image.
                htmlBody = $"{htmlBody.Substring(0, match.Index)}{embeddedSrc}{htmlBody.Substring(match.Index + match.Length)}"
            End If
        Next

        Return htmlBody

    End Function

    Sub LoadAttachments(attachments As AttachmentCollection, document As DocumentModel)

        Dim htmlSubtitle = "<hr><p style='font: bold 12px Calibri;'>Attachments:</p>"
        document.Content.End.LoadText(htmlSubtitle, LoadOptions.HtmlDefault)

        For Each attachment As Attachment In attachments.Where(
            Function(a) a.DispositionType = ContentDispositionType.Attachment AndAlso
                        a.MimeEntity.ContentType.TopLevelType = "image")

            document.Content.End.InsertRange(
                New Paragraph(document, New Picture(document, attachment.Data)).Content)
        Next

    End Sub
End Module
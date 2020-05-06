Imports System
Imports System.IO
Imports GemBox.Document
Imports GemBox.Email
Imports GemBox.Email.Smtp

Module Program
    Sub Main()

        ' If using Professional version, put your GemBox.Email serial key below.
        GemBox.Email.ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' If using Professional version, put your GemBox.Document serial key below.
        GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Load Word file.
        Dim document = DocumentModel.Load("BodyTemplate.docx")

        Using stream As New MemoryStream()
            ' Save as MHTML document.
            document.Save(stream, New HtmlSaveOptions() With
            {
                .HtmlType = HtmlType.Mhtml,
                .UseContentIdHeaders = True
            })

            ' Load MHTML content as mail message.
            Dim message = MailMessage.Load(stream, MailMessageFormat.Mhtml)

            message.Subject = "Word message example"
            message.Date = DateTime.Now

            message.From.Add(New MailAddress("sender@example.com"))
            message.To.Add(New MailAddress("receiver@example.com"))

            ' Send email.
            Using smtp As New SmtpClient("<HOST>")
                smtp.Connect()
                smtp.Authenticate("<USERNAME>", "<PASSWORD>")
                smtp.SendMessage(message)
            End Using
        End Using

    End Sub
End Module
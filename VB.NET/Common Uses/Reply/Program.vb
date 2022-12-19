Imports System.Linq
Imports GemBox.Email
Imports GemBox.Email.Imap
Imports GemBox.Email.Mime
Imports GemBox.Email.Smtp

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Retrieve searched email.
        Dim originalMessage As MailMessage
        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            imap.Connect()
            imap.Authenticate("<USERNAME>", "<PASSWORD>")
            imap.SelectInbox()

            Dim search As String = "SUBJECT ""Are you coming to the party?"""
            originalMessage = imap.GetMessage(imap.SearchMessageNumbers(search).First())
        End Using

        ' Create reply email with sender and receiver addresses swapped.
        Dim replyMessage As New MailMessage(
            originalMessage.To(0),
            originalMessage.From(0))

        ' Add 'In-Reply-To' and 'References' header.
        replyMessage.MimeEntity.Headers.Add(
            New Header(HeaderId.InReplyTo, originalMessage.Id))
        replyMessage.MimeEntity.Headers.Add(
            New Header(HeaderId.References, originalMessage.Id))

        ' Set subject.
        replyMessage.Subject = $"Re: { originalMessage.Subject }"

        ' Set reply message message.
        replyMessage.BodyHtml = "<div>Yes. See you there at 9.</div>"

        ' Append original message text.
        replyMessage.BodyHtml +=
            $"<div>On {originalMessage.Date:G}, {originalMessage.From(0).Address} wrote:</div>" +
            $"<blockquote>{originalMessage.BodyHtml}</blockquote>"

        ' Send reply email.
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")
            smtp.Connect()
            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            smtp.SendMessage(replyMessage)
        End Using

    End Sub
End Module
Imports GemBox.Email
Imports GemBox.Email.Imap
Imports GemBox.Email.Mime
Imports GemBox.Email.Smtp
Imports System.Linq

Module Program

    Sub Main()

        Example1()
        Example2()

    End Sub

    Sub Example1()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Retrieve original message.
        Dim originalMessage As MailMessage
        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            imap.Connect()
            imap.Authenticate("<USERNAME>", "<PASSWORD>")
            imap.SelectInbox()

            Dim searchQuery As String = "SUBJECT ""Are you coming to the party?"""
            originalMessage = imap.GetMessage(imap.SearchMessageNumbers(searchQuery).First())
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

        ' Set subject and body with appended original message.
        replyMessage.Subject = $"Re: { originalMessage.Subject }"
        replyMessage.BodyHtml += $"<div>Yes, see you there at 9!</div>
<br><div>On {originalMessage.Date:G}, {originalMessage.From(0).Address} wrote:</div>
<blockquote style='border-left:1pt solid #E1E1E1;padding-left:5pt'>
  {originalMessage.BodyHtml}
</blockquote>"

        ' Send reply email.
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")
            smtp.Connect()
            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            smtp.SendMessage(replyMessage)
        End Using
    End Sub

    Sub Example2()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Retrieve original message.
        Dim originalMessage As MailMessage
        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            imap.Connect()
            imap.Authenticate("<USERNAME>", "<PASSWORD>")
            imap.SelectInbox()

            Dim searchQuery As String = "SUBJECT ""Are you coming to the party?"""
            originalMessage = imap.GetMessage(imap.SearchMessageNumbers(searchQuery).First())
        End Using

        ' Create forward email.
        Dim forwardMessage As New MailMessage(
            "receiver@example.com",
            "anoter.receiver@example.com")

        ' Set subject and body with appended original message.
        forwardMessage.Subject = $"Fw: {originalMessage.Subject}"
        forwardMessage.BodyHtml += $"<div>Are you interested in coming with me to this party?</div>
<br><div>On {originalMessage.Date:G}, {originalMessage.From(0).Address} wrote:</div>
<blockquote style='border-left:1pt solid #E1E1E1;padding-left:5pt'>
  {originalMessage.BodyHtml}
</blockquote>"

        ' Add original attachments.
        For Each attachment In originalMessage.Attachments
            forwardMessage.Attachments.Add(attachment)
        Next

        ' Send forward email.
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")
            smtp.Connect()
            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            smtp.SendMessage(forwardMessage)
        End Using
    End Sub

End Module

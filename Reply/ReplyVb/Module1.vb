Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Text
Imports GemBox.Email
Imports GemBox.Email.Imap
Imports GemBox.Email.Mime
Imports GemBox.Email.Smtp

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Dim message As MailMessage

        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")
            imap.Connect()
            Console.WriteLine("Connected.")

            imap.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

            imap.SelectInbox()
            Dim results As IList(Of Integer) = imap.SearchMessageNumbers("FROM sender@example.com SUBJECT " &
                                                                         """Are you coming to the party""")

            If results.Count = 0 Then
                Console.WriteLine("Message Not found.")
            End If

            message = imap.GetMessage(results(0))
        End Using

        Dim fromAddress As MailAddress = message.From(0)
        Dim reply As New MailMessage(New MailAddress("receiver@example.com", "Receiver"),
                                     fromAddress)

        ' Add 'In-Reply-To' header
        Dim header As New Header(HeaderId.InReplyTo, message.Id)
        reply.MimeEntity.Headers.Add(header)

        ' Check if 'References' header exists and its body is not null or empty
        If message.MimeEntity.Headers.TryGetHeader(HeaderId.References, header) AndAlso Not String.IsNullOrEmpty(header.Body) Then
            ' If found, copy original value and append last message id
            header = New Header(HeaderId.References, header.Body & " "c & message.Id)
        Else
            ' If not found, create one with message id
            header = New Header(HeaderId.References, message.Id)
        End If

        ' Add 'References' header to reply message
        reply.MimeEntity.Headers.Add(header)

        ' Set subject
        reply.Subject = "Re:  " + message.Subject

        ' Compose text body
        Dim text As New StringBuilder()

        text.AppendLine("Yes. See you there at 9.")
        text.AppendLine()
        text.AppendFormat("On {0}, {1} wrote:", message.Date.ToString(CultureInfo.InvariantCulture), fromAddress)
        text.AppendLine()

        ' Append original text body if it exists
        If message.BodyText IsNot Nothing Then
            text.AppendLine()
            text.Append("> " + message.BodyText.Replace(vbCrLf, vbCrLf & "> "))
        End If

        reply.BodyText = text.ToString()

        ' Compose HTML body
        text = New StringBuilder()

        text.Append("<div>Yes. See you there at 9.</div><br/>")
        text.AppendFormat("<div>On {0}, ", message.Date.ToString(CultureInfo.InvariantCulture))

        If fromAddress.DisplayName IsNot Nothing Then
            text.Append(fromAddress.DisplayName + " "c)
        End If

        text.AppendFormat("<<a href=""mailto:{0}"">{0}</a>> wrote:<br/>", fromAddress.Address)

        ' Append original text body if it exists
        If message.BodyHtml IsNot Nothing Then
            text.Append("<blockquote style=""margin: 0 0 0 5px;")
            text.Append(" border-left 2px blue solid;")
            text.Append(" padding-left 5px"">")
            text.Append(message.BodyHtml)
            text.Append("</blockquote><br/></div>")
        End If

        reply.BodyHtml = text.ToString()

        Console.WriteLine("Sending reply...")

        ' Initialize new SMTP client and send message
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")
            smtp.Connect()
            Console.WriteLine("Connected.")

            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

            smtp.SendMessage(message)
        End Using

        Console.WriteLine("Reply sent successfully.")

    End Sub

End Module
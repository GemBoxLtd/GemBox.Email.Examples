Imports GemBox.Email
Imports GemBox.Email.Exchange

Module Program

    Sub Main()
        Example1()
        Example2()
    End Sub

    Sub Example1()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new Exchange client.
        Dim exchangeClient = New ExchangeClient("<HOST> (e.g. https://outlook.office365.com/EWS/Exchange.asmx)")
        exchangeClient.Authenticate("<USERNAME>", "<PASSWORD>")

        ' List the first ten messages in the Inbox folder.
        Dim messageInfos = exchangeClient.ListMessages("Inbox", 0, 10)

        For Each messageInfo As ExchangeMessageInfo In messageInfos
            If Not messageInfo.IsRead Then

                ' Get the full mail message.
                Dim mailMessage = exchangeClient.GetMessage(messageInfo.ExchangeMessageId)
                Console.WriteLine("From: " + String.Join(", ", mailMessage.From))
                Console.WriteLine(mailMessage.BodyHtml)
                Console.WriteLine()

                ' Mark message as read.
                exchangeClient.MarkMessageAsRead(messageInfo.ExchangeMessageId)
            End If
        Next
    End Sub

    Sub Example2()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new email message.
        Dim message As New MailMessage("sender@example.com", "receiver@example.com")

        ' Add subject.
        message.Subject = "Send HTML Email with Image and Attachment"

        ' Add HTML body with CID embedded image.
        Dim cid As String = "image001@gembox.com"
        message.BodyHtml = "<html><body>" &
            "<p>Hi 👋,</p>" &
            "<p>This message was created and sent with:</p>" &
            "<p><img src='cid:" & cid & "'/></p>" &
            "<p>Read more about it on <a href='https://www.gemboxsoftware.com/email'>GemBox.Email Overview</a> page.</p>" &
            "</body></html>"

        ' Add image as inline attachment.
        message.Attachments.Add(New Attachment("%#GemBoxEmailLogo.png%") With {.ContentId = cid})

        ' Add file as attachment.
        message.Attachments.Add(New Attachment("%#GemBoxSampleFile.pdf%"))

        ' Create a new Exchange client and send the email message.
        Dim exchangeClient = New ExchangeClient("<HOST> (e.g. https://outlook.office365.com/EWS/Exchange.asmx)")
        exchangeClient.Authenticate("<USERNAME>", "<PASSWORD>")
        exchangeClient.SendMessage(message)
    End Sub

End Module

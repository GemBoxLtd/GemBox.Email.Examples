Imports GemBox.Email
Imports GemBox.Email.Graph

Module Program

    Sub Main()
        Example1()
        Example2()
    End Sub

    Sub Example1()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new email message.
        Dim message As New MailMessage(
            New MailAddress("sender@example.com", "Sender"),
            New MailAddress("first.receiver@example.com", "First receiver"),
            New MailAddress("second.receiver@example.com", "Second receiver"))

        ' Add additional receivers.
        message.Cc.Add(
            New MailAddress("third.receiver@example.com", "Third receiver"),
            New MailAddress("fourth.receiver@example.com", "Fourth receiver"))

        ' Add subject and body.
        message.Subject = "Send Email in C# and VB.NET"
        message.BodyText = "Hi 👋," & vbLf &
            "This message was created and sent with GemBox.Email." & vbLf &
            "Read more about it on https://www.gemboxsoftware.com/email"

        ' Create a new Graph client and send an email message.
        Dim graphClient = New GraphClient()
        graphClient.Authenticate("<OAUTH2.0-TOKEN>")
        graphClient.ImpersonateUser("<USER-ID-OR-EMAIL>")
        graphClient.SendMessage(message)
    End Sub

    Sub Example2()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new email message.
        Dim message = New MailMessage("sender@example.com", "receiver@example.com")

        ' Add subject.
        message.Subject = "Send HTML Email with Image and Attachment"

        ' Add HTML body with CID embedded image.
        Dim cid = "image001@gembox.com"
        message.BodyHtml = "<html><body>" &
            "<p>Hi 👋,</p>" &
            "<p>This message was created and sent with:</p>" &
            "<p><img src='cid:" & cid & "'/></p>" &
            "<p>Read more about it on <a href='https://www.gemboxsoftware.com/email'>GemBox.Email Overview</a> page.</p>" &
            "</body></html>"

        ' Add image as inline attachment.
        message.Attachments.Add(New Attachment("GemBoxEmailLogo.png") With {.ContentId = cid})

        ' Add file as attachment.
        message.Attachments.Add(New Attachment("GemBoxSampleFile.pdf"))

        ' Create a new Graph client and send an email message.
        Dim graphClient = New GraphClient()
        graphClient.Authenticate("<OAUTH2.0-TOKEN>")
        graphClient.ImpersonateUser("<USER-ID-OR-EMAIL>")
        graphClient.SendMessage(message)
    End Sub

End Module

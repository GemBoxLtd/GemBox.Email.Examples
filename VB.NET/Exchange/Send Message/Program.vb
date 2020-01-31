Imports System
Imports GemBox.Email
Imports GemBox.Email.Exchange

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
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

        ' Create a new Exchange client and send an email message.
        Dim exchangeClient = New ExchangeClient("<HOST> (e.g. https://outlook.office365.com/EWS/Exchange.asmx)")
        exchangeClient.Authenticate("<USERNAME>", "<PASSWORD>")
        exchangeClient.SendMessage(message)

    End Sub
End Module
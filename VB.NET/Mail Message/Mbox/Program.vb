Imports System
Imports GemBox.Email

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Load message collection.
        Dim messages As MailMessageCollection = MailMessageCollection.Load("Collection.mbox")

        ' Display message information.
        For Each message As MailMessage In messages
            Console.WriteLine($"From: {message.From}")
            Console.WriteLine($"Subject: {message.Subject}")
            Console.WriteLine($"Body: {message.BodyText}")
            Console.WriteLine()
        Next

        ' Create new message.
        Dim newMessage As New MailMessage("sender@example.com", "receiver@example.com") With
        {
            .Subject = "Test email message with a text body",
            .BodyText = "This is a test message with a text body."
        }

        ' Add message to the collection
        messages.Add(newMessage)

        ' Save message collection
        messages.Save("Modified Collection.mbox")

    End Sub
End Module
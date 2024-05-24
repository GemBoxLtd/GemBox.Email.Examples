Imports System
Imports GemBox.Email

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Load message from email file.
        Dim message As MailMessage = MailMessage.Load("Html.eml")

        ' Read message information.
        Console.WriteLine($"Date: {message.Date}")
        Console.WriteLine($"Subject: {message.Subject}")
        Console.WriteLine($"From: {message.From}")
        Console.WriteLine($"To: {message.To}")

        If (message.Cc.Count > 0) Then
            Console.WriteLine($"Cc: {message.Cc}")
        End If

        If (message.Bcc.Count > 0) Then
            Console.WriteLine($"Bcc: {message.Bcc}")
        End If

        If (message.Attachments.Count > 0) Then
            Console.WriteLine($"Attachments: {message.Attachments.Count}")
        End If

        Console.WriteLine()
        If (String.IsNullOrEmpty(message.BodyHtml)) Then
            Console.WriteLine(message.BodyText)
        Else
            Console.WriteLine(message.BodyHtml)
        End If

    End Sub
End Module
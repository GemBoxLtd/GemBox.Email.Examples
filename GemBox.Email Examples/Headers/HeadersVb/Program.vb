Imports System
Imports GemBox.Email
Imports GemBox.Email.Mime

Module Program

    Sub Main()

        Example1()
        Example2()

    End Sub

    Sub Example1()
        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new message.
        Dim message As New MailMessage("sender@example.com", "receiver@example.com")

        ' Get 'From' property and 'From' header.
        Dim fromAddresses As MailAddressCollection = message.From
        Dim fromHeader As Header = message.MimeEntity.Headers(HeaderId.From)

        Console.WriteLine($"Original 'From' property value: {fromAddresses}")

        ' Change 'From' header value.
        fromHeader.Body = "new.sender@example.com"

        Console.WriteLine($"Modified 'From' property value: {fromAddresses}")

        ' Get 'To' property and 'To' header.
        Dim toAddresses As MailAddressCollection = message.To
        Dim toHeader As Header = message.MimeEntity.Headers(HeaderId.To)

        Console.WriteLine($"Original 'To' header value: {toHeader.Body}")

        ' Change 'To' property value.
        toAddresses(0).Address = "new.receiver@example.com"

        Console.WriteLine($"Modified 'To' header value: {toHeader.Body}")
    End Sub

    Sub Example2()
        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new message.
        Dim message As New MailMessage("sender@example.com", "receiver@example.com") With
        {
            .Subject = "Example Message",
            .BodyText = "High priority email with comments."
        }

        ' Add message comments.
        message.MimeEntity.Headers.Add(
            New Header(HeaderId.Comments, "Example of mail message comment"))

        ' Add message priority.
        message.MimeEntity.Headers.Add(
            New Header("Importance", "high"))
        message.MimeEntity.Headers.Add(
            New Header("Priority", "urgent"))
        message.MimeEntity.Headers.Add(
            New Header("X-Priority", "1"))

        message.Save("High Priority Message.eml")
    End Sub
End Module
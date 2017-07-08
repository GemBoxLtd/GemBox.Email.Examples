Imports System
Imports System.Collections.Generic
Imports GemBox.Email
Imports GemBox.Email.Mime

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create New message
        Dim message As New MailMessage(New MailAddress("sender@example.com"),
                                       New MailAddress("receiver-1@example.com", "First"),
                                       New MailAddress("receiver-2@example.com", "Second"))

        ' Get 'From' reference
        Dim fromAddresses As MailAddressCollection = message.From

        ' Get 'To' header
        Dim headerTo As Header = message.MimeEntity.Headers(HeaderId.To)

        Console.WriteLine("Original value of property 'To': " & message.To.ToString())

        ' Change header value
        headerTo.Body = "new.receiver@example.com"
        Console.WriteLine("Header 'To' value changed to: " & headerTo.Body)
        Console.WriteLine("Modified value of property 'To': " & message.To.ToString())

        Dim headerFrom As Header = Nothing

        ' Try to get 'From' header
        If Not message.MimeEntity.Headers.TryGetHeader("From", headerFrom) Then
            Throw New KeyNotFoundException("Header not found.")
        End If

        Console.WriteLine()
        Console.WriteLine("Original value of variable 'fromAddresses': " & fromAddresses.ToString())

        ' Change header value
        headerFrom.Body = "New sender <new.sender@example.com>"
        Console.WriteLine("Header 'From' value changed to: " & headerFrom.Body)
        Console.WriteLine("Modified value of variable 'fromAddresses': " & fromAddresses.ToString())

    End Sub

End Module
Imports GemBox.Email
Imports GemBox.Email.Graph
Imports System

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new Graph client.
        Dim graphClient = New GraphClient()
        graphClient.Authenticate("<OAUTH2.0-TOKEN>")
        graphClient.ImpersonateUser("<USER-ID-OR-EMAIL>")

        ' List the first ten messages in the Inbox folder.
        Dim messages = graphClient.ListMessages("Inbox", 0, 10)

        For Each message In messages
            If Not message.IsRead Then
                ' Get the full mail message.
                Dim mailMessage = graphClient.GetMessage(message.MessageId)
                Console.WriteLine("From: " & String.Join(", ", mailMessage.From))
                Console.WriteLine(If(mailMessage.BodyHtml, mailMessage.BodyText))
                Console.WriteLine()

                ' Mark message as read.
                graphClient.MarkMessageAsRead(message.MessageId)
            End If
        Next

    End Sub
End Module

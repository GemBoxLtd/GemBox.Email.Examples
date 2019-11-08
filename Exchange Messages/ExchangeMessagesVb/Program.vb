Imports System
Imports GemBox.Email
Imports GemBox.Email.Exchange

Module Program

    Sub Main()

        ' If using Professional version, put your serial key below.
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
End Module
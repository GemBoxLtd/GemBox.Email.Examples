Imports GemBox.Email
Imports GemBox.Email.Exchange
Imports GemBox.Email.Imap
Imports GemBox.Email.Pop
Imports GemBox.Email.Smtp

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create a new POP client.
        Using pop As New PopClient("<ADDRESS> (e.g. pop.gmail.com)")

            '  Connect and sign to POP server using OAuth 2.0.
            pop.Connect()
            pop.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", PopAuthentication.XOAuth2)
        End Using

        ' Create a new IMAP client.
        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")

            '  Connect and sign to IMAP server using OAuth 2.0.
            imap.Connect()
            imap.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", ImapAuthentication.XOAuth2)
        End Using

        ' Create a new SMTP client.
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")

            '  Connect and sign to SMTP server using OAuth 2.0.
            smtp.Connect()
            smtp.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", SmtpAuthentication.XOAuth2)
        End Using

        ' Create a new Exchange client.
        Dim exchangeClient = New ExchangeClient("<HOST> (e.g. https://outlook.office365.com/EWS/Exchange.asmx)")
        ' Authenticate the client using OAuth 2.0.
        exchangeClient.Authenticate("<USERNAME>", "<ACCESS-TOKEN>", ExchangeAuthentication.OAuth2)

    End Sub
End Module
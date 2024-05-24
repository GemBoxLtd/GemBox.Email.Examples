Imports GemBox.Email
Imports GemBox.Email.Security
Imports GemBox.Email.Smtp
Imports System
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create certificate validation delegate.
        Dim validationDelegate As RemoteCertificateValidationCallback =
            Function(sender As Object,
                     certificate As X509Certificate,
                     chain As X509Chain,
                     errors As SslPolicyErrors) As Boolean

                If errors = SslPolicyErrors.None OrElse errors = SslPolicyErrors.RemoteCertificateNameMismatch Then
                    Console.WriteLine("Server certificate is valid.")
                    Return True
                Else
                    Console.WriteLine($"Server certificate is invalid: {errors}")
                    Return False
                End If
            End Function

        ' Create new SmtpClient and specify host, port, security and certificate validation callback.
        Using smtp As New SmtpClient(
            "<ADDRESS> (e.g. smtp.gmail.com)",
            465,
            ConnectionSecurity.Ssl,
            validationDelegate)

            ' Connect to email server.
            smtp.Connect()
            Console.WriteLine("Connected.")

            ' Authenticate with specified username, password and authentication mechanism.
            smtp.Authenticate("<USERNAME>", "<PASSWORD>", SmtpAuthentication.Plain)
            Console.WriteLine("Authenticated.")
        End Using

    End Sub
End Module

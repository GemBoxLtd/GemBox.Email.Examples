Imports System
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports GemBox.Email
Imports GemBox.Email.Smtp
Imports GemBox.Email.Security

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Define certificate validation delegate which will ignore
        ' 'Certificate name mismatch' errors
        Dim validationDelegate As RemoteCertificateValidationCallback =
            Function(sender As Object,
                     certificate As X509Certificate,
                     chain As X509Chain,
                     sslPolicyErrors As SslPolicyErrors) As Boolean

                If sslPolicyErrors = SslPolicyErrors.None OrElse
                   sslPolicyErrors = SslPolicyErrors.RemoteCertificateNameMismatch Then
                    Console.WriteLine("Server certificate is valid.")
                    Return True
                Else
                    Console.WriteLine("Server certificate is invalid. Errors: " &
                                      sslPolicyErrors.ToString())
                    Return False
                End If
            End Function

        ' Create new SmtpClient and specify IP port,
        ' security type And certificate validation callback
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)",
                                 465,
                                 ConnectionSecurity.Ssl,
                                 validationDelegate)

            ' Connect to mail server
            smtp.Connect()
            Console.WriteLine("Connected.")

            ' Authenticate with specified username,
            ' password And authentication mechanism
            smtp.Authenticate("<USERNAME>", "<PASSWORD>", SmtpAuthentication.Plain)
            Console.WriteLine("Authenticated.")
        End Using

    End Sub

End Module
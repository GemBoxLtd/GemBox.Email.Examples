Imports System
Imports GemBox.Email

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create New message with specified 'from' and 'to' addresses, including their display names
        Dim message As New MailMessage(New MailAddress("sender@example.com", "Mail sender"),
                                       New MailAddress("receiver@example.com", "Message receiver"))

        ' Set subject And text body
        message.Subject = "HTML email message sample"

        ' Set HTML body ...
        message.BodyHtml = "<html>" &
                              "<body style=""background-color: #eae7e3"">" &
                                 "<div style=""background-color:lightblue; " &
                                             "width: 500px; " &
                                             "margin: auto; " &
                                             "padding: 10px; " &
                                             "text-align: center"">" &
                                    "<h1 style=""color:red"">" &
                                       "GemBox.Email<br/>Html Message sample" &
                                     "</h1>" &
                                     "<p style=""text-align:left"">" &
                                        "This sample demonstrates how to create " &
                                        "<code style=""color:blue"">" &
                                           "GemBox.Email.MailMessage" &
                                        "</code>" &
                                        "with styled <b>HTML</b> body." &
                                     "</p>" &
                                  "</div>" &
                               "</body>" &
                           "</html>"

        ' ... and also, set text body for clients who doesn't support mail messages with HTML body
        message.BodyText = "GemBox.Email Html Message sample" & vbCrLf &
                           "This sample demonstrates how To create " &
                           "GemBox.Email.MailMessage With styled HTML body."

        ' Save message to disk
        message.Save("HtmlMessage.eml", MailMessageFormat.Eml)

    End Sub

End Module
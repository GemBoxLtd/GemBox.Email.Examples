Imports System
Imports GemBox.Email

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create new message
        Dim message As MailMessage = New MailMessage(New MailAddress("sender@example.com", "Sender"),
                                     New MailAddress("first.receiver@example.com", "First receiver"))

        ' Add second receiver to CC And set subject
        message.Cc.Add(New MailAddress("carbon.copy@example.com", "Carbon Copy receiver"))
        message.Subject = "GemBox.Email .NET component save example"

        ' Add HTML And text body
        message.BodyHtml = "<html>" &
                              "<body>" &
                                "<p>Hi!<br/><br/>This message was created and saved with " &
                                  "<b>GemBox.Email .NET component</b>.<br/>" &
                                  "More info can be found at <a href=""http://www.gemboxsoftware.com/"">" &
                                  "GemBox Software website</a>.<br/><br/>" &
                                  "Regards,<br/>" &
                                  "GemBox" &
                                "</p>" &
                              "</body>" &
                            "</html>"

        message.BodyText = "Hi!" & vbCrLf &
                           vbCrLf &
                           "This message was created and saved with GemBox.Email .NET component." & vbCrLf &
                           "More info can be found at http://www.gemboxsoftware.com/." & vbCrLf & vbCrLf &
                           "Regards," & vbCrLf &
                           "GemBox"

        message.Save("Save.eml")

    End Sub

End Module
Imports System
Imports System.Data
Imports System.Collections.Generic
Imports GemBox.Email

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create template message
        Dim template As New MailMessage(New MailAddress("sender@example.com"))
        template.Subject = "%FirstName%, check our new offer ..."
        template.BodyText = "Dear %Title% %LastName%,\r\n" &
                            "\r\n" &
                            "Check out or new offer on %link%.\r\n" &
                            "Visit us today and get additional %discount%% discount!\r\n" &
                            "\r\n" &
                            "Your,\r\n" &
                            "Special Store\r\n" &
                            "\r\n" &
                            "This email was sent to %To%."
        template.BodyHtml = "<div>" &
                                "Dear <strong>%Title% %LastName%</strong>,<br/>" &
                                "<br/>" &
                                "Check out our new offer on this <a href=""%link%"">link</a>.<br/>" &
                                "<span style=""color:red;font-size:90%"">Visit us today and get additional %discount%% discount!</span><br/>" &
                                "<br/>" &
                                "Sincerly Yours,<br/>" &
                                "Special Store<br/>" &
                                "<br/>" &
                                "<span style=""color:gray;font-size:80%"">This email was sent to <a href=""mailto:%To%"">%To%</a>.</span>" &
                            "</div>"

        ' Define data table columns ...
        Dim data As New DataTable()
        data.Columns.Add("To", GetType(String))
        data.Columns.Add("Title", GetType(String))
        data.Columns.Add("FirstName", GetType(String))
        data.Columns.Add("LastName", GetType(String))
        data.Columns.Add("Discount", GetType(Integer))
        data.Columns.Add("Link", GetType(String))

        ' ... And add some data
        data.Rows.Add("jonh@example.com", "Mr.", "John", "Doe", 10, "http://example.com/check.html?name=John")
        data.Rows.Add("jane@example.com", "Mrs.", "Jane", "Doe", 20, "http://example.com/check.html?name=Jane")
        data.Rows.Add("joe@example.com", "Mr.", "Joe", "Unknown", 15, "http://example.com/check.html?name=Joe")

        ' Perform mail merge
        Dim messages As IList(Of MailMessage) = MailMerge.Merge(template, data)

        ' Save messages to disk
        For i As Integer = 0 To messages.Count - 1
            messages(i).Save("Message_" & i, MailMessageFormat.Eml)
        Next

    End Sub

End Module
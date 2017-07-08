Imports System
Imports System.Collections.Generic
Imports GemBox.Email
Imports GemBox.Email.Smtp

Module Module1

    Sub Main()

        ' If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create template message
        Dim template As New MailMessage(New MailAddress("sender@example.com"))
        template.Subject = "%FirstName%, check our new offer ..."
        template.BodyText = "Dear %Title% %LastName%," & vbCrLf &
                            vbCrLf &
                            "Check out or new offer on %link%." & vbCrLf &
                            "Visit us today and get additional %discount%% discount!" & vbCrLf &
                            vbCrLf &
                            "Your," & vbCrLf &
                            "Special Store" & vbCrLf &
                            vbCrLf &
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

        Dim data As New List(Of DataObject) From
        {
            New DataObject(New MailAddress("jonh@example.com"), "Mr.", "John", "Doe", 10, "http://example.com/check.html?name=John"),
            New DataObject(New MailAddress("jane@example.com"), "Mrs.", "Jane", "Doe", 20, "http://example.com/check.html?name=Jane"),
            New DataObject(New MailAddress("joe@example.com"), "Mr.", "Joe", "Unknown", 15, "http://example.com/check.html?name=Joe")
        }

        ' Perform mail merge
        Dim messages As IList(Of MailMessage) = MailMerge.Merge(template, data)

        ' Send messages
        Using smtp As New SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)")
            smtp.Connect()
            Console.WriteLine("Connected.")

            smtp.Authenticate("<USERNAME>", "<PASSWORD>")
            Console.WriteLine("Authenticated.")

            For Each message As MailMessage In messages
                smtp.SendMessage(message)
            Next

            Console.WriteLine("Messages sent.")
        End Using
    End Sub
End Module

Class DataObject
    Public ReadOnly Property [To] As MailAddress
    Public ReadOnly Property Title As String
    Public ReadOnly Property FirstName As String
    Public ReadOnly Property FamilyName As String
    Public ReadOnly Property Discount As Integer
    Public ReadOnly Property Link As String

    Public Sub New([to] As MailAddress, title As String, firstName As String, familyName As String, discount As Integer, link As String)
        Me.To = [to]
        Me.Title = title
        Me.FirstName = firstName
        Me.FamilyName = familyName
        Me.Discount = discount
        Me.Link = link
    End Sub
End Class

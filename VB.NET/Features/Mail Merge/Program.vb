Imports GemBox.Email
Imports System.Collections.Generic
Imports System.Data

Module Program

    Sub Main()
        Example1()
        Example2()
    End Sub

    Sub Example1()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create template message.
        Dim template As New MailMessage("sender@example.com")
        template.Subject = "%FirstName%, check our new offer!"
        template.BodyHtml =
"<div>
Dear <strong>%Title% %LastName%</strong><br/><br/>
Check out our new offer on this <a href=""%link%"">link</a>.<br/>
<span style=""color:red;font-size:90%"">Visit us today and get additional %discount%% discount!</span><br/><br/>
Sincerely Yours,<br/>
Special Store<br/><br/>
<span style=""color:gray;font-size:80%"">This email was sent to <a href=""mailto:%To%"">%To%</a>.</span>
</div>"

        ' Create data source.
        Dim data As New DataTable()
        data.Columns.Add("To", GetType(String))
        data.Columns.Add("Title", GetType(String))
        data.Columns.Add("FirstName", GetType(String))
        data.Columns.Add("LastName", GetType(String))
        data.Columns.Add("Discount", GetType(String))
        data.Columns.Add("Link", GetType(String))

        ' Fill data source with some data.
        data.Rows.Add("jonh@example.com", "Mr.", "John", "Doe", 10, "https://example.com/check.html?name=John")
        data.Rows.Add("jane@example.com", "Mrs.", "Jane", "Doe", 20, "https://example.com/check.html?name=Jane")
        data.Rows.Add("joe@example.com", "Mr.", "Joe", "Unknown", 15, "https://example.com/check.html?name=Joe")

        ' Perform mail merge operation.
        Dim messages As IList(Of MailMessage) = GemBox.Email.MailMerge.Merge(template, data)

        ' Save mail messages.
        For i As Integer = 0 To messages.Count - 1
            messages(i).Save($"Message_{i}.eml")
        Next
    End Sub

    Sub Example2()
        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        ' Create template message.
        Dim template As New MailMessage("sender@example.com")
        template.Subject = "%FirstName%, check our new offer!"
        template.BodyHtml =
"<div>
Dear <strong>%Title% %LastName%</strong><br/><br/>
Check out our new offer on this <a href=""%link%"">link</a>.<br/>
<span style=""color:red;font-size:90%"">Visit us today and get additional %discount%% discount!</span><br/><br/>
Sincerely Yours,<br/>
Special Store<br/><br/>
<span style=""color:gray;font-size:80%"">This email was sent to <a href=""mailto:%To%"">%To%</a>.</span>
</div>"

        ' Create data source.
        Dim data As New List(Of DataObject) From
        {
            New DataObject("jonh@example.com", "Mr.", "John", "Doe", 10, "https://example.com/check.html?name=John"),
            New DataObject("jane@example.com", "Mrs.", "Jane", "Doe", 20, "https://example.com/check.html?name=Jane"),
            New DataObject("joe@example.com", "Mr.", "Joe", "Unknown", 15, "https://example.com/check.html?name=Joe")
        }

        ' Perform mail merge operation.
        Dim messages As IList(Of MailMessage) = GemBox.Email.MailMerge.Merge(template, data)

        ' Save mail messages.
        For i As Integer = 0 To messages.Count - 1
            messages(i).Save($"Message_{i}.eml")
        Next
    End Sub

    Class DataObject
        Public ReadOnly Property [To] As String
        Public ReadOnly Property Title As String
        Public ReadOnly Property FirstName As String
        Public ReadOnly Property LastName As String
        Public ReadOnly Property Discount As Integer
        Public ReadOnly Property Link As String

        Public Sub New([to] As String, title As String, firstName As String, lastName As String, discount As Integer, link As String)
            Me.To = [to]
            Me.Title = title
            Me.FirstName = firstName
            Me.LastName = lastName
            Me.Discount = discount
            Me.Link = link
        End Sub
    End Class

End Module

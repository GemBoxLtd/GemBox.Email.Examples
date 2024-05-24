Imports GemBox.Email
Imports GemBox.Email.Imap
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading

Module Program

    Sub Main()

        ' If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        Using imap As New ImapClient("<ADDRESS> (e.g. imap.gmail.com)")
            imap.Connect()
            imap.Authenticate("<USERNAME>", "<PASSWORD>")
            imap.SelectInbox()

            Using listener = New ImapListener(imap)
                AddHandler listener.MessagesChanged, AddressOf OnMessagesChanged
                imap.IdleEnable()

                Console.WriteLine("Press any key to exit...")
                Console.ReadKey()

                imap.IdleDisable()
                RemoveHandler listener.MessagesChanged, AddressOf OnMessagesChanged
            End Using
        End Using

    End Sub

    Private Sub OnMessagesChanged(sender As Object, e As ImapListenerEventArgs)
        For Each info In e.NewMessages
            Console.WriteLine($"Message '{info.Uid}' received.")
        Next

        For Each info In e.OldMessages
            Console.WriteLine($"Message '{info.Uid}' deleted.")
        Next
    End Sub

End Module

Class ImapListener
    Implements IDisposable

    Private ReadOnly client As ImapClient
    Private messages As Dictionary(Of String, ImapMessageInfo)
    Private running As Boolean
    Private listenerThread As Thread

    Public Event MessagesChanged As EventHandler(Of ImapListenerEventArgs)

    Public Sub New(client As ImapClient)
        Me.client = client
        Me.messages = Me.GetMessages()
        Me.running = True
        Me.listenerThread = New Thread(AddressOf Listen) With {.IsBackground = True}
        Me.listenerThread.Start()
    End Sub

    Private Function GetMessages() As Dictionary(Of String, ImapMessageInfo)
        Return Me.client.ListMessages().ToDictionary(Function(info) info.Uid, Function(info) info)
    End Function

    Private Sub Listen()
        While Me.running
            Thread.Sleep(100)

            ' Compare the previous and current message count of the selected folder.
            Dim comparison As Integer = Me.client.SelectedFolder.Count.CompareTo(Me.messages.Count)
            If comparison = 0 Then Continue While

            Dim currentMessages = Me.GetMessages()
            Dim emptyMessages = Enumerable.Empty(Of ImapMessageInfo)()

            If comparison > 0 Then
                ' New message(s) was added.
                Dim newMessages = currentMessages _
                    .Where(Function(message) Not Me.messages.ContainsKey(message.Key)) _
                    .Select(Function(message) message.Value)
                RaiseEvent MessagesChanged(Me, New ImapListenerEventArgs(newMessages, emptyMessages))
            Else
                ' Old message(s) was deleted.
                Dim oldMessages = Me.messages _
                    .Where(Function(message) Not currentMessages.ContainsKey(message.Key)) _
                    .Select(Function(message) message.Value)
                RaiseEvent MessagesChanged(Me, New ImapListenerEventArgs(emptyMessages, oldMessages))
            End If

            Me.messages = currentMessages
        End While
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Me.running = False
        Me.listenerThread?.Join(5000)
        Me.listenerThread = Nothing
    End Sub
End Class

Class ImapListenerEventArgs
    Inherits EventArgs
    Public ReadOnly Property NewMessages As IEnumerable(Of ImapMessageInfo)
    Public ReadOnly Property OldMessages As IEnumerable(Of ImapMessageInfo)
    Public Sub New(newMessages As IEnumerable(Of ImapMessageInfo), oldMessages As IEnumerable(Of ImapMessageInfo))
        Me.NewMessages = newMessages
        Me.OldMessages = oldMessages
    End Sub
End Class

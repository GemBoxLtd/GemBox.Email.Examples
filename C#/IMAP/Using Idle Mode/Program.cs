using GemBox.Email;
using GemBox.Email.Imap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        using (var imap = new ImapClient("<ADDRESS> (e.g. imap.gmail.com)"))
        {
            imap.Connect();
            imap.Authenticate("<USERNAME>", "<PASSWORD>");
            imap.SelectInbox();

            using (var listener = new ImapListener(imap))
            {
                listener.MessagesChanged += OnMessagesChanged;
                imap.IdleEnable();

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

                imap.IdleDisable();
                listener.MessagesChanged -= OnMessagesChanged;
            }
        }
    }

    static void OnMessagesChanged(object sender, ImapListenerEventArgs e)
    {
        foreach (var info in e.NewMessages)
            Console.WriteLine($"Message '{info.Uid}' received.");

        foreach (var info in e.OldMessages)
            Console.WriteLine($"Message '{info.Uid}' deleted.");
    }
}

class ImapListener : IDisposable
{
    private readonly ImapClient client;
    private Dictionary<string, ImapMessageInfo> messages;
    private bool running;
    private Thread listenerThread;

    public event EventHandler<ImapListenerEventArgs> MessagesChanged;

    public ImapListener(ImapClient client)
    {
        this.client = client;
        this.messages = this.GetMessages();
        this.running = true;
        this.listenerThread = new Thread(Listen) { IsBackground = true };
        this.listenerThread.Start();
    }

    private Dictionary<string, ImapMessageInfo> GetMessages()
    {
        return this.client.ListMessages().ToDictionary(info => info.Uid, info => info);
    }

    private void Listen()
    {
        while (this.running)
        {
            Thread.Sleep(100);

            // Compare the previous and current message count of the selected folder.
            int comparison = this.client.SelectedFolder.Count.CompareTo(this.messages.Count);
            if (comparison == 0)
                continue;

            var currentMessages = this.GetMessages();
            var emptyMessages = Enumerable.Empty<ImapMessageInfo>();

            // New message(s) was added.
            if (comparison > 0)
            {
                var newMessages = currentMessages
                    .Where(message => !this.messages.ContainsKey(message.Key))
                    .Select(message => message.Value);
                this.MessagesChanged?.Invoke(this, new ImapListenerEventArgs(newMessages, emptyMessages));
            }
            // Old message(s) was deleted.
            else
            {
                var oldMessages = this.messages
                    .Where(message => !currentMessages.ContainsKey(message.Key))
                    .Select(message => message.Value);
                this.MessagesChanged?.Invoke(this, new ImapListenerEventArgs(emptyMessages, oldMessages));
            }

            this.messages = currentMessages;
        }
    }

    public void Dispose()
    {
        this.running = false;
        this.listenerThread?.Join(5000);
        this.listenerThread = null;
    }
}

class ImapListenerEventArgs : EventArgs
{
    public IEnumerable<ImapMessageInfo> NewMessages { get; }
    public IEnumerable<ImapMessageInfo> OldMessages { get; }
    public ImapListenerEventArgs(IEnumerable<ImapMessageInfo> newMessages, IEnumerable<ImapMessageInfo> oldMessages)
    {
        this.NewMessages = newMessages;
        this.OldMessages = oldMessages;
    }
}

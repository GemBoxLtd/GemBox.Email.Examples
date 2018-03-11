using System;
using System.Linq;
using GemBox.Email;
using GemBox.Email.Calendar;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message.
        MailMessage message = new MailMessage(new MailAddress("sender@example.com", "Sender"),
                              new MailAddress("first.receiver@example.com", "First receiver"));

        message.Subject = "This is a mail message with a calendar";
        message.BodyText = "Hi! I am sending you my calendar.";

        // Create new calendar.
        Calendar calendar = new Calendar();
        Event e = new Event();
        e.Organizer = message.Sender;
        e.Name = "GemBox conference";
        e.Start = new DateTime(2018, 1, 10, 9, 0, 0, DateTimeKind.Utc);
        e.End = new DateTime(2018, 1, 12, 18, 0, 0, DateTimeKind.Utc);
        e.Attendees.Add(message.To.First()); 
        calendar.Events.Add(e);

        // Add a calendar to the mail message.
        message.Calendars.Add(calendar);

        // ... a mail message can be sent using SMTP or saved to a file.
        message.Save("Add Calendar to a Message.eml");
    }
}
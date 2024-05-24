using GemBox.Email;
using GemBox.Email.Calendar;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new message.
        MailMessage message = new MailMessage("sender@example.com", "receiver@example.com");

        message.Subject = "Mail Message With Calendar";
        message.BodyText = "Hi! I am sending you my calendar.";

        // Create new calendar.
        Calendar calendar = new Calendar();
        Event ev = new Event();
        ev.Organizer = message.Sender;
        ev.Name = "GemBox Meeting Request";
        ev.Start = new DateTime(2018, 1, 10, 9, 0, 0, DateTimeKind.Utc);
        ev.End = new DateTime(2018, 1, 12, 18, 0, 0, DateTimeKind.Utc);
        ev.Attendees.Add(message.To.First());
        calendar.Events.Add(ev);

        // Add calendar to the mail message.
        message.Calendars.Add(calendar);

        message.Save("Add To Message.eml");
    }
}

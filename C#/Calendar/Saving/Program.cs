using System;
using GemBox.Email;
using GemBox.Email.Calendar;

class Program
{
    static void Main()
    {
        // If using the Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new calendar.
        Calendar calendar = new Calendar();

        // Create new event.
        Event ev = new Event();
        ev.Organizer = new MailAddress("info@gemboxsoftware.com", "GemBox Ltd.");
        ev.Name = "GemBox Meeting Request";
        ev.Location = "152 City Road, London";
        ev.Start = new DateTime(2018, 1, 10, 9, 0, 0, DateTimeKind.Utc);
        ev.End = new DateTime(2018, 1, 12, 18, 0, 0, DateTimeKind.Utc);
        ev.Attendees.Add(new MailAddress("invited@example.com"));

        // Create new reminder.
        Reminder reminder = new Reminder();
        reminder.ReminderAction = ReminderAction.Email;
        reminder.ReminderAttendees.Add(new MailAddress("invited@example.com"));
        reminder.TriggerBeforeStart = new TimeSpan(2, 0, 0, 0);

        // Add reminder to the event.
        ev.Reminders.Add(reminder);

        // Add event to the calendar.
        calendar.Events.Add(ev);

        // Create new task.
        Task task = new Task();
        task.Organizer = new MailAddress("info@gemboxsoftware.com", "GemBox Ltd.");
        task.Name = "Implement iCalendar Support";
        task.Start = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        task.Deadline = new DateTime(2018, 1, 15, 0, 0, 0, DateTimeKind.Utc);
        task.Priority = 5;
        task.Categories.Add("New '.ics' format support");
        task.Attendees.Add(new MailAddress("programmer@example.com"));

        // Add task to the calendar.
        calendar.Tasks.Add(task);

        calendar.Save("Create And Save.ics");
    }
}
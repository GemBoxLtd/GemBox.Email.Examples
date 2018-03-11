using System;
using GemBox.Email;
using GemBox.Email.Calendar;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        // Create new calendar.
        Calendar calendar = new Calendar();

        // Create new event.
        Event e = new Event();
        e.Organizer = new MailAddress("info@gemboxsoftware.com", "GemBox Ltd");
        e.Name = "GemBox conference";
        e.Location = "152 City Road, London";
        e.Start = new DateTime(2018, 1, 10, 9, 0, 0, DateTimeKind.Utc);
        e.End = new DateTime(2018, 1, 12, 18, 0, 0, DateTimeKind.Utc);
        e.Attendees.Add(new MailAddress("invited@example.com"));

        // Create new reminder.
        Reminder reminder = new Reminder();
        reminder.ReminderAction = ReminderAction.Email;
        reminder.ReminderAttendees.Add(new MailAddress("invited@example.com"));
        reminder.TriggerBeforeStart = new TimeSpan(2,0,0,0); // Remind two days before the event

        // Add reminder to the event.
        e.Reminders.Add(reminder);

        // Add event to the calendar.
        calendar.Events.Add(e);

        // Create new task.
        Task task = new Task();
        task.Organizer = new MailAddress("info@gemboxsoftware.com", "GemBox Ltd");
        task.Name = "Implement iCalendar support";
        task.Start = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc); 
        task.Deadline = new DateTime(2018, 1, 15, 0, 0, 0, DateTimeKind.Utc);
        task.Priority = 5;
        task.Categories.Add("new format support");
        task.Attendees.Add(new MailAddress("programmer@gemboxsoftware.com"));

        // Add task to the calendar.
        calendar.Tasks.Add(task);

        calendar.Save("Save.ics");
    }
}
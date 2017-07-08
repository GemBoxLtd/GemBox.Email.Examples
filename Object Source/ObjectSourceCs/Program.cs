using System;
using System.Collections.Generic;
using GemBox.Email;
using GemBox.Email.Smtp;

class Program
{
    static void Main(string[] args)
    {
        // If using Professional version, put your serial key below.
        ComponentInfo.SetLicense("FREE-LIMITED-KEY");


        // Create template message
        MailMessage template = new MailMessage(new MailAddress("sender@example.com"));
        template.Subject = "%FirstName%, check our new offer ...";
        template.BodyText = "Dear %Title% %LastName%,\r\n" +
                            "\r\n" +
                            "Check out or new offer on %link%.\r\n" +
                            "Visit us today and get additional %discount%% discount!\r\n" +
                            "\r\n" +
                            "Your,\r\n" +
                            "Special Store\r\n" +
                            "\r\n" +
                            "This email was sent to %To%.";
        template.BodyHtml = "<div>" +
                                "Dear <strong>%Title% %LastName%</strong>,<br/>" +
                                "<br/>" +
                                "Check out our new offer on this <a href=\"%link%\">link</a>.<br/>" +
                                "<span style=\"color:red;font-size:90%\">Visit us today and get additional %discount%% discount!</span><br/>" +
                                "<br/>" +
                                "Sincerly Yours,<br/>" +
                                "Special Store<br/>" +
                                "<br/>" +
                                "<span style=\"color:gray;font-size:80%\">This email was sent to <a href=\"mailto:%To%\">%To%</a>.</span>" +
                            "</div>";

        List<DataObject> data = new List<DataObject>()
         {
             new DataObject(new MailAddress("jonh@example.com"), "Mr.", "John", "Doe", 10, "http://example.com/check.html?name=John"),
             new DataObject(new MailAddress("jane@example.com"), "Mrs.", "Jane", "Doe", 20, "http://example.com/check.html?name=Jane"),
             new DataObject(new MailAddress("joe@example.com"), "Mr.", "Joe", "Unknown", 15, "http://example.com/check.html?name=Joe")
         };

        // Perform mail merge
        IList<MailMessage> messages = MailMerge.Merge(template, data);

        // Send messages
        using (SmtpClient smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
        {
            smtp.Connect();
            Console.WriteLine("Connected.");

            smtp.Authenticate("<USERNAME>", "<PASSWORD>");
            Console.WriteLine("Authenticated.");

            foreach (MailMessage message in messages)
                smtp.SendMessage(message);

            Console.WriteLine("Messages sent.");
        }
    }
}

class DataObject
{
    public MailAddress To { get; private set; }
    public string Title { get; private set; }
    public string FirstName { get; private set; }
    public string FamilyName { get; private set; }
    public int Discount { get; private set; }
    public string Link { get; private set; }

    public DataObject(MailAddress to, string title, string firstName, string familyName, int discount, string link)
    {
        this.To = to;
        this.Title = title;
        this.FirstName = firstName;
        this.FamilyName = familyName;
        this.Discount = discount;
        this.Link = link;
    }
}

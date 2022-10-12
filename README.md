[![NuGet version](https://img.shields.io/nuget/v/GemBox.Email?style=for-the-badge)](https://www.nuget.org/packages/GemBox.Email/) [![NuGet downloads](https://img.shields.io/nuget/dt/GemBox.Email?style=for-the-badge)](https://www.nuget.org/packages/GemBox.Email/) [![Visual Studio Marketplace rating](https://img.shields.io/visual-studio-marketplace/stars/GemBoxSoftware.GemBoxEmail?style=for-the-badge)](https://marketplace.visualstudio.com/items?itemName=GemBoxSoftware.GemBoxEmail)

<img src="https://www.gemboxsoftware.com/images/NugetGbe.png" alt="GemBox.Email logo" align="left" />

## What is GemBox.Email?

GemBox.Email is a .NET component that enables you to read, write, and convert email files (MSG, EML, and MHTML), or send and receive email messages (POP, IMAP, SMTP, and EWS) from .NET applications.

With GemBox.Email you get a fast and reliable component that’s easy to use and doesn't depend on Microsoft Outlook. It requires only .NET so you can deploy your applications without having to think about other licenses.

## GemBox.Email features

- [Create a mail message](https://www.gemboxsoftware.com/email/examples/send-html-email-with-attachment-c-sharp-vb-net/603) with attachments and a multi-format message body.
- [Save and load mail messages](https://www.gemboxsoftware.com/email/examples/c-sharp-outlook-msg-eml-mht/106) to and from an MSG / EML / MHTML / MBOX file or a stream.
- Modify mail message [headers](https://www.gemboxsoftware.com/email/examples/headers/604) using an advanced MIME model.
- [List](https://www.gemboxsoftware.com/email/examples/list-email-messages-pop/702) all mail messages using the POP protocol.
- Do custom [SSL certificate](https://www.gemboxsoftware.com/email/examples/ssl-certificate-validation-pop/706) validation when connecting to a mail server using [PopClient](https://www.gemboxsoftware.com/email/examples/c-sharp-pop3-client/701), [ImapClient](https://www.gemboxsoftware.com/email/examples/c-sharp-imap-client/301), or [SmtpClient](https://www.gemboxsoftware.com/email/examples/c-sharp-smtp-client/801).
- Create calendar events, tasks, reminders and [add](https://www.gemboxsoftware.com/email/examples/add-calendar-to-mail-message/903) them to an email.
- Download a mail message using the [POP](https://www.gemboxsoftware.com/email/examples/c-sharp-pop3-client/701) or [IMAP](https://www.gemboxsoftware.com/email/examples/c-sharp-imap-client/301) protocol.
- [Send, list, and download messages](https://www.gemboxsoftware.com/email/examples/send-email-exchange-ews/1001) on the Exchange Server using the EWS protocol.
- [List and modify](https://www.gemboxsoftware.com/email/examples/modify-folders-exchange-ews/1003) folders on the Exchange Server using the EWS protocol.
- [Validate](https://www.gemboxsoftware.com/email/examples/c-sharp-validate-email/401) mail addresses.
- Perform a [mail merge](https://www.gemboxsoftware.com/email/examples/c-sharp-vb-net-mail-merge-datatable/501).
- [Save](https://www.gemboxsoftware.com/email/examples/create-and-save-calendar/901) and [Load](https://www.gemboxsoftware.com/email/examples/load-calendar/902) calendars in iCalendar format.
- Create and [send](https://www.gemboxsoftware.com/email/examples/send-email-c-sharp-vb-asp-net/101) mail messages using the [SMTP](https://www.gemboxsoftware.com/email/examples/c-sharp-smtp-client/801) protocol.
- [List and modify](https://www.gemboxsoftware.com/email/examples/imap-email-folders/302) folders on a mail server using the IMAP protocol.
- List and modify [message flags](https://www.gemboxsoftware.com/email/examples/message-flags/306) using the IMAP protocol.
- [Search](https://www.gemboxsoftware.com/email/examples/c-sharp-vb-net-search-emails/308) for messages on a mail server using the IMAP protocol.

## Get Started

You are not sure how to start working with email messages in .NET using GemBox.Email? Check the code below that shows how to create an email message from scratch and send it.

```CSharp
// If using Professional version, put your serial key below.
ComponentInfo.SetLicense("FREE-LIMITED-KEY");
 
// Create a new email message.
MailMessage message = new MailMessage(
    new MailAddress("sender@example.com", "Sender"),
    new MailAddress("first.receiver@example.com", "First receiver"),
    new MailAddress("second.receiver@example.com", "Second receiver"));


// Add subject and body.
message.Subject = "Hello World!";
message.BodyText = "Hi 👋,\n" +
    "This message was created and sent with GemBox.Email.";

// Create a new SMTP client and send the email message.
using (SmtpClient smtp = new SmtpClient("<ADDRESS> (e.g. smtp.gmail.com)"))
{
    smtp.Connect();
    smtp.Authenticate("<USERNAME>", "<PASSWORD>");
    smtp.SendMessage(message);
}
```

For more GemBox.Email code examples and demos, please visit our [examples page](https://www.gemboxsoftware.com/email/examples/c-sharp-vb-net-email-library/201).

## Installation

You can download GemBox.Email from [BugFixes 🛠️](https://www.gemboxsoftware.com/email/downloads/bugfixes.html) or from [NuGet 📦](https://www.nuget.org/packages/GemBox.Email/).

## Resources

* [Product Page](https://www.gemboxsoftware.com/email)
* [Documentation](https://www.gemboxsoftware.com/email/docs/introduction.html)
* [Blog](https://www.gemboxsoftware.com/gembox-email)
* [API Reference](https://www.gemboxsoftware.com/email/docs/GemBox.Email.html)
* [Examples](https://www.gemboxsoftware.com/email/examples)
* [Forum](https://forum.gemboxsoftware.com/c/gembox-email/9)

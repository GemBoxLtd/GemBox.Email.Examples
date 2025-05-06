[![NuGet version](https://img.shields.io/nuget/v/GemBox.Email?style=for-the-badge)](https://www.nuget.org/packages/GemBox.Email/) [![NuGet downloads](https://img.shields.io/nuget/dt/GemBox.Email?style=for-the-badge)](https://www.nuget.org/packages/GemBox.Email/) [![Visual Studio Marketplace rating](https://img.shields.io/visual-studio-marketplace/stars/GemBoxSoftware.GemBoxEmail?style=for-the-badge)](https://marketplace.visualstudio.com/items?itemName=GemBoxSoftware.GemBoxEmail)

## What is GemBox.Email?

GemBox.Email is a .NET component that enables you to read, write, and convert email files (MSG, EML, and MHTML), or send and receive email messages (POP, IMAP, SMTP, and EWS) from .NET applications.

With GemBox.Email you get a fast and reliable component that's easy to use and doesn't depend on Microsoft Outlook. It requires only .NET so you can deploy your applications without having to think about other licenses.

## GemBox.Email Features

- [Send](https://www.gemboxsoftware.com/email/examples/send-email-c-sharp-vb-asp-net/101) mail messages using [SMTP](https://www.gemboxsoftware.com/email/examples/c-sharp-smtp-client/801) protocol.
- [Receive](https://www.gemboxsoftware.com/email/examples/receive-read-email-c-sharp-vb/102), [reply, and forward](https://www.gemboxsoftware.com/email/examples/reply-forward-email-c-sharp-vb-net/103) mail messages using [POP](https://www.gemboxsoftware.com/email/examples/list-email-messages-pop/702) or [IMAP](https://www.gemboxsoftware.com/email/examples/list-email-messages-imap/303) protocol.
- [Create](https://www.gemboxsoftware.com/email/examples/send-html-email-with-attachment-c-sharp-vb-net/603) mail message with attachments and multi-format message body.
- [Convert](https://www.gemboxsoftware.com/email/examples/c-sharp-outlook-msg-eml-mht/106) emails to MSG, EML, and MHTML format.
- Create, send, and receive emails in [ASP.NET Core](https://www.gemboxsoftware.com/email/examples/asp-net-core-mail-message/5101), [Blazor](https://www.gemboxsoftware.com/email/examples/blazor-mail-message/5102), [MAUI](https://www.gemboxsoftware.com/email/examples/get-email-message-maui/2002), and other .NET applications.
- Process emails on Windows, Linux, macOS, [Android, and iOS](https://www.gemboxsoftware.com/email/examples/get-email-message-xamarin/2001) operating systems.
- Modify mail message [headers](https://www.gemboxsoftware.com/email/examples/headers/604) using advanced MIME model.
- List and modify [folders](https://www.gemboxsoftware.com/email/examples/imap-email-folders/302) using IMAP protocol.
- List and modify [message flags](https://www.gemboxsoftware.com/email/examples/message-flags/306) using IMAP protocol.
- [Search](https://www.gemboxsoftware.com/email/examples/c-sharp-vb-net-search-emails/308) for mail message using IMAP protocol.
- [Send](https://www.gemboxsoftware.com/email/examples/send-email-exchange-ews/1001), [list, and download](https://www.gemboxsoftware.com/email/examples/manipulate-messages-exchange-ews/1002) messages on the Exchange Server using EWS protocol.
- [List and modify](https://www.gemboxsoftware.com/email/examples/modify-folders-exchange-ews/1003) folders on the Exchange Server using the EWS protocol.
- [Send](https://www.gemboxsoftware.com/email/examples/send-email-microsoft-graph/3001), [list, and download](https://www.gemboxsoftware.com/email/examples/manipulate-messages-microsoft-graph/3002) messages on the Office 365 Server using Microsoft Graph API.
- [List and modify](https://www.gemboxsoftware.com/email/examples/modify-folders-microsoft-graph/3003) folders on the Office 365 Server using Microsoft Graph API.
- Custom [SSL certificate validation](https://www.gemboxsoftware.com/email/examples/ssl-certificate-validation-pop/706) when connecting to mail server.
- [Validate mail addresses](https://www.gemboxsoftware.com/email/examples/c-sharp-validate-email/401).
- [Sign, unsign](https://www.gemboxsoftware.com/email/examples/c-sharp-vb-net-sign-email/1202), and [validate](https://www.gemboxsoftware.com/email/examples/c-sharp-vb-net-sign-email/1202) emails.
- Create [personalized mail messages](https://www.gemboxsoftware.com/email/examples/c-sharp-vb-net-mail-merge-datatable/501) based on a single template and variable data.
- [Load](https://www.gemboxsoftware.com/email/examples/load-calendar/902) and [save](https://www.gemboxsoftware.com/email/examples/create-and-save-calendar/901) calendars in iCalendar format.
- [Create and add](https://www.gemboxsoftware.com/email/examples/add-calendar-to-mail-message/903) calendar events, tasks, and reminders to an email.
- [OAuth 2.0](https://www.gemboxsoftware.com/email/examples/authenticate-using-oauth-c-sharp-vb/109) support.

## Get Started

You are not sure how to start working with email messages in .NET using GemBox.Email? Check the code below that shows how to create an email message from scratch and send it.

```csharp
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

For more GemBox.Email code examples and demos, please visit our [examples page](https://www.gemboxsoftware.com/email/examples/getting-started/201).

## Installation

You can download GemBox.Email from [NuGet 📦](https://www.nuget.org/packages/GemBox.Email/) or from [Downloads 🛠️](https://www.gemboxsoftware.com/email/downloads/).

## Resources

- [Product Page](https://www.gemboxsoftware.com/email)
- [Examples](https://www.gemboxsoftware.com/email/examples)
- [Documentation](https://www.gemboxsoftware.com/email/docs/introduction.html)
- [API Reference](https://www.gemboxsoftware.com/email/docs/GemBox.Email.html)
- [Forum](https://forum.gemboxsoftware.com/c/gembox-email/9)
- [Blog](https://www.gemboxsoftware.com/gembox-email)

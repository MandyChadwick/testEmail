using System;
using System.Net;
using System.Net.Mail;
using System.Threading;

public class EmailSender
{
    public static void Main(string[] args)
    {
        string fromAddress = "";
        string toAddress = "";
        string password = ""; // Replace with your App Password
        string subject = "Automated Email";
        string body = "This is an automated email sent every minute.";

        while (true)
        {
            try
            {
                SendEmail(fromAddress, toAddress, password, subject, body);
                Console.WriteLine($"Email sent at {DateTime.Now}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }

            Thread.Sleep(60000); // Sleep for 1 minute (60,000 milliseconds)
        }
    }

    public static void SendEmail(string fromAddress, string toAddress, string password, string subject, string body)
    {
        MailMessage message = new MailMessage(fromAddress, toAddress, subject, body);

        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
        {
            smtp.Credentials = new NetworkCredential(fromAddress, password);
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
    }
}

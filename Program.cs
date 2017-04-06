using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace amarelDevOps
{
    class Program
    {
        public static void Main(string[] args)
        {
            string introduceName, emailAddrr;
            Console.WriteLine("Hello Amarel");
            Console.WriteLine("Who do I have an honour with?");
            introduceName = Console.ReadLine();
            Console.WriteLine("Hello {0}, Boris would like to send you a confirmation email, please type your email address", introduceName);
            emailAddrr = Console.ReadLine();
            Program p = new Program();
            p.mailSender(emailAddrr, introduceName);
        }
        public string mailSender(string emailAddrr, string introduceName)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("i.m.devops.eng@gmail.com", "Boris DevOps Gmail");
            msg.To.Add(emailAddrr);
            msg.Subject = "Hello " + introduceName + ", the date is: " + DateTime.Now.ToString();
            msg.Body = "This email message was sent as compiled C# code of Boris's DevOps candidate task. please confirm Boris that you received this email";
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("i.m.devops.eng@gmail.com", "Th1s!st3st");
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
                return "Mail has been successfully sent!";
            }
            catch (Exception ex)
            {
                return "Fail Has error" + ex.Message;
            }
            finally
            {
                msg.Dispose();
            }
        }
    }
}

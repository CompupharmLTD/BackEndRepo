using CompupharmLtd.Interface;
using CompupharmLtd.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using System.IO;
using System.Threading.Tasks;
//using MailKit.Net.Smtp;

using MailKit.Security;
using System.Net.Mail;
using System;

namespace CompupharmLtd.Service
{
    public class EmailSendingService : IEmailSending
    {
        //    public SendEmail();
        private readonly MailSettings _mailSettings;

        public int Send(string fromad, string toad, string body, string header, string subjectcontent)
        {
            int result = 0;
            MailMessage usermail = Mailbodplain(fromad, toad, body, header, subjectcontent);
            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password
            client.Credentials = new System.Net.NetworkCredential("compupharml@gmail.com", "vkrzekxnpykihkhc"); 

            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            try
            {
                client.Send(usermail);
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
            } // end try

            return result;

        }
        public MailMessage Mailbodplain(string fromad, string toad, string body, string header, string subjectcontent)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            try
            {
                string from = fromad;
                string to = toad;
                mail.To.Add(to);
                mail.From = new MailAddress(from, header, System.Text.Encoding.UTF8);
                mail.Subject = subjectcontent;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = body;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
            }
            catch (Exception ex)
            {
                throw;
            }
            return mail;
        }
    }
}
using Lips.Tool.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Tool.MailHelper
{
    public class MailSend
    {
        // Methods
        public static bool SendMail(string xmlModel, string xslt, string email, string subject)
        {
            bool flag;
            string str = XsltOperations.ReturnFilledHtml(xmlModel, xslt);
            SmtpClient client = new SmtpClient(SMTPSERVER, PORTNO)
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(MyMail, Password)
            };
            //client.
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(MyMail,"WasApp+");
                message.Subject = (subject == null) ? "" : subject;
                message.Body = str;
                
                message.IsBodyHtml = true;
                message.To.Add(email);
                try
                {
                    client.Send(message);
                    flag = true;
                }
                catch(Exception ex)

                {
                    flag = false;
                    throw ex;
                }
            }
            return flag;
        }

        // Properties
        private static string MyMail
        {
            get
            {
                return Mail.Default.Email;
            }
        }

        private static string Password
        {
            get
            {
                return Mail.Default.PasswordMail;
            }
        }

        private static int PORTNO
        {
            get
            {
                return Mail.Default.Portno;
            }
        }

        private static string SMTPSERVER
        {
            get
            {
                return Mail.Default.SmtpServer;
            }
        }
    }


}

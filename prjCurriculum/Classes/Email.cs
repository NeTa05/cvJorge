using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace prjCurriculum.Classes
{
    public class Email
    {
        private string email { get; set; }
        private string message { get; set; }
        private string name { get; set; }

        public Email(string email, string message, string name)
        {
            this.email = email;
            this.message = message;
            this.name = name;
        }


        public void SendEmail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(this.email);
            mail.To.Add("testingequiz1.1@gmail.com");
            mail.Subject = "De :"+this.email;
            mail.Body = this.message+"\n"+"Enviado por: "+ this.name+"\nCorreo :"+this.email;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("testingequiz1.1@gmail.com", "Jorge1234");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        

    }
}
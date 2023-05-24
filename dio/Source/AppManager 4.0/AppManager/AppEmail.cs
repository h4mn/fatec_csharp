using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace AppManager
{
    class Email
    {
        
        /// <summary>
        /// Envia um e-mail para a conta definida no parâmetro "to"
        /// </summary>
        /// <param name="from">Conta que esta enviando o email, deve ser a mesma usada na autenticação do server smtp</param>
        /// <param name="to">Conta que recebe o email</param>
        /// <param name="subject">Titulo do email</param>
        /// <param name="body">Texto do corpo do email</param>
        public void Send(string from, string to, string subject, string body)
        {
            SmtpClient smtpMail = new SmtpClient();
            MailMessage email = new MailMessage();
            MailAddress eFrom = new MailAddress(from);

            email.To.Add(to);
            email.Subject = subject;
            email.IsBodyHtml = true;
            email.Body = body;

            smtpMail.Host = "meuserversmtp@server.com.br";
            smtpMail.Credentials = new NetworkCredential("User", "password");
            smtpMail.Send(email);

        }

    }
}

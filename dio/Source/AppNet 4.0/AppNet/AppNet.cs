using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// NameSpaces para enviar e-mail
using System.Net;
using System.Net.Mail;

namespace AppNet
{

    /// <summary>
    /// Classe para enviar email
    /// </summary>
    public class Mail
    {
    
        /// <summary>
        /// Obtem ou Define o servidor de e-mail
        /// </summary>
        public string Host
        {
            get
            {
                return m_Host;
            }
            set
            {
                m_Host = value;
            }
        }
        private string m_Host;

        /// <summary>
        /// Obtem ou define a porta do servidor SMTP
        /// </summary>
        public Int16 Port
        {
            get
            {
                return m_Port;
            }
            set
            {
                m_Port = value;
            }
        }
        private Int16 m_Port = 587;
     
        /// <summary>
        /// Obtem ou define o usuário para autenticação no servidor SMTP
        /// </summary>
        public string User
        {
            get
            {
                return m_User;
            }
            set
            {
                m_User = value;
            }
        }
        private string m_User;

        /// <summary>
        /// Obtem ou define o senha de autenticação no servidor SMPT
        /// </summary>
        public string Pass
        {
            get
            {
                return m_Pass;
            }
            set
            {
                m_Pass = value;
            }
        }
        private string m_Pass;


        /// <summary>
        /// Obtem a Exceção ocorrida no envio do email
        /// </summary>
        public Exception Exception
        {
            get
            {
                return m_Exception;
            }
        }
        private Exception m_Exception;


        /// <summary>
        /// Habilita a conexão segura com o servidor SMTP.
        /// </summary>
        public bool EnabledSsl
        {
            set
            {
                m_Ssl = value;
            }
        }
        private bool m_Ssl = false;


        /// <summary>
        /// Métoto para enviar o e-mail
        /// Se houver uma exceção no processo de envio, recupere os dados a partir da propriedade Exception.
        /// </summary>
        /// <param name="mailTo">conta de e-mail que receberá o email</param>
        /// <param name="mailFrom">conta e-mail utilizada para enviar o e-mail</param>
        /// <param name="mailSubject">Titulo do e-mail</param>
        /// <param name="mailBody">Corpo do e-mail</param>
        /// <returns></returns>
        public bool Send(string mailTo, string mailFrom, string mailSubject, string mailBody)
        {
            SmtpClient smtpMail = new SmtpClient();
            MailMessage Email = new MailMessage();
            try
            {
                // Dados do email
                MailAddress eFrom = new MailAddress(mailFrom);
                Email.From = eFrom;
                Email.To.Add(mailTo);
                Email.Subject = mailSubject.ToString();
                Email.Body = mailBody.ToString();
                Email.IsBodyHtml = false;
                Email.Priority = System.Net.Mail.MailPriority.Normal;
                Email.SubjectEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                Email.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                // Envia o Email
                smtpMail.Host = m_Host;
                smtpMail.EnableSsl = m_Ssl;
                smtpMail.Credentials = new NetworkCredential(m_User, m_Pass);
                smtpMail.Port = m_Port;
                smtpMail.Send(Email);
                return true;
            }
            catch (Exception ex)
            {
                m_Exception = ex;
                return false;

            }
            finally
            {
                smtpMail.Dispose();
                Email.Dispose();
            }
        }

    }
}

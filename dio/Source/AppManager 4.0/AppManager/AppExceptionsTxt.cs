using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

// BLIBLIOTECA PARA OBTER DADOS DA EXCEÇÃO
using System.Diagnostics;

// BIBLIOTECA PARA ENVIAR EMAIL
using System.Net.Mail;

// BIBLIOTECA PARA ENTRADA E SAIDA 
using System.IO;

namespace AppManager
{

    /// <summary>
    /// Recupera os dados de uma exceção da aplicação.
    /// </summary>
    public class AppExceptionsTxt
    {

        #region PROPRIEDADES
        private string m_pathException = Directory.GetCurrentDirectory();
        /// <summary>
        /// Obtem ou define o caminho completo do arquivo de registro das exceções.
        /// </summary>
        public string PathSaveFile
        {
            get
            {
                return m_pathException;
            }
            set
            {
                m_pathException = value;
            }
        }


        /// <summary>
        /// Obtem ou define o nome e extensão do arquivo txt para salvar as exceções.
        /// </summary>
        public string FileName
        {
            get { return nomeArquivo; }
            set { nomeArquivo = value; }
        }
        private string nomeArquivo = "Exceptions.txt";

        /// <summary>
        /// Obtem ou define o provedor smtp para enviar o email
        /// </summary>
        public string Host
        {
            get { return hostName; }
            set { hostName = value; }
        }
        private string hostName = "smtp.photopost.com.br";

        /// <summary>
        /// Obtem ou define o email para enviar a mensagem
        /// </summary>
        public string EmailFrom
        {
            get { return EmailFrom; }
            set { EmailFrom = value; }
        }

        /// <summary>
        /// Obtem ou define o nome de usuário para autenticação no servidor smtp
        /// </summary>
        public string EmailUser
        {
            get { return EmailUser; }
            set { EmailUser = value; }
        }

        /// <summary>
        /// Obtem ou define a senha do usuário para autenticação no servidor smtp
        /// </summary>
        public string EmailPassword
        {
            get { return EmailPassword; }
            set { EmailPassword = value; }
        }

        /// <summary>
        /// Obtem ou define o email para enviar a mensagem
        /// </summary>
        public string EmailTo
        {
            get { return EmailTo; }
            set { EmailTo = value; }
        }

        #endregion

        /// <summary>
        ///  Salva uma exceção no arquivo de log exception.txt.
        /// </summary>
        /// <param name="ex">Dados da exceção do tipo exception.</param>
        public void SaveException(Exception ex)
        {
            string message = DateTime.Now.ToString() + "\r\n";
            message += ex.Message + "\r\n";
            message += ex.Source + "\r\n";
            message += ex.GetType().FullName + "\r\n";

            // obtem o numero da linha onde ocorreu a exceção
            //using System.Diagnostics;
            StackFrame stackFrame = new StackFrame(1, true);

            message += stackFrame.GetMethod().ToString() + "\r\n";
            message += stackFrame.GetFileLineNumber().ToString() + "\r\n";
            message += "-----------------------------------------------\r\n";

            //Dim st As Diagnostics.StackTrace = New Diagnostics.StackTrace(ex, True)
            //         If st.FrameCount > 0 Then
            //            exFull.AppendLine("-------------------------------------------------------------------")
            //            exFull.AppendLine("FRAMES : " + st.FrameCount.ToString)
            //            exFull.AppendLine("-------------------------------------------------------------------")
            //            For i = 0 To st.FrameCount - 1
            //               Dim sf As Diagnostics.StackFrame = st.GetFrame(i)
            //               exFull.AppendLine("Frame  : " + i.ToString)
            //               exFull.AppendLine("Code   : " + sf.GetHashCode().ToString)
            //               exFull.AppendLine("Method : " + sf.GetMethod().Name.ToString)
            //               exFull.AppendLine("Line   : " + sf.GetFileLineNumber().ToString)
            //               exFull.AppendLine("Column : " + sf.GetFileColumnNumber().ToString)
            //               exFull.AppendLine("-------------------------------------------------------------------")
            //            Next
            //         End If



            // GRAVA NO ARQUIVO EXCEPTIONS.TXT
            File.AppendAllText(PathSaveFile+"//"+FileName, message);

        }

        /// <summary>
        /// Obtem todas as exceções do arquivo de exceptions.txt
        /// </summary>
        /// <returns></returns>
        public string LoadException()
        {
            string str = "";

            if (File.Exists(m_pathException))
            {
                FileInfo src = new FileInfo(m_pathException);
                TextReader reader = null;

                reader = src.OpenText();
                string line = reader.ReadLine();
                while (line != null)
                {
                    str += line + "\r\n";
                    line = reader.ReadLine();
                }
                reader.Close();
            }
            return str;
        }

        /// <summary>
        /// Limpa o conteúdo do arquivo de exceções.
        /// </summary>
        /// <returns></returns>
        public Boolean ClearException()
        {
            if (File.Exists(m_pathException))
            {
                FileInfo src = new FileInfo(m_pathException);
                src.Delete();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Enviar os dados da exceção para o administrador do sistema
        /// </summary>
        /// <param name="excecao">dados da exceção</param>
        /// <returns></returns>
        private void EnviaExcecao(string excecao)
        {
            SmtpClient smtpMail = new SmtpClient();
            MailMessage email = new MailMessage();

            // Montar a mensagem de email
            email.Subject = "Exceção ocorrida";
            email.IsBodyHtml = false;
            email.Body = excecao;
            email.Priority = MailPriority.Normal;
            email.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            email.To.Add(EmailTo);

            // quem vai enviar o email
            MailAddress eFrom = new MailAddress(EmailFrom);
            email.From = eFrom;

            // Autenticar no servidor SMTP
            smtpMail.Host = Host;
            smtpMail.Port = 587;
            smtpMail.EnableSsl = true;
            smtpMail.Credentials = new NetworkCredential(EmailUser, EmailPassword);
            // Conect ao servidor SMTP e envia o email
            smtpMail.Send(email);

        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// pacote para email SMTP
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;
using Ads2023;


namespace WebApplicationFATEC
{
    public partial class contato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            Mensagem.Text = "";

            //VALIDAÇÃO DOS DADOS
            if (NomeCompleto.Text.Trim() == "")
            {
                Mensagem.Text = "Digite seu nome";

            }

            else if (Email.Text.Trim() == "")
            {
                Mensagem.Text = "Digite seu Email";

            }

            else if (Observacoes.MaxLength > 255)
            {
                Mensagem.Text = "Digite no máximo 255 caracteres na mensagem";
            }

            else if (Observacoes.Text.Trim() == "")
            {
                Mensagem.Text = "Digite uma mensagem para ser enviada";
            }

            //inserir metodo para o envio de email

            else
            {

                try
                {
                    //1. criar o pacote email
                    MailMessage mail = new MailMessage();
                    mail.To.Add("contato@seudominio.com.br");
                    MailAddress from = new MailAddress
                        ("contato@seudominio.com.br");
                    //atribui ao rom do email 
                    mail.From = from;
                    mail.Subject = "E-mail enviado pela pagina de contato";
                    mail.Body = "Nome: " + NomeCompleto.Text + "\n";
                    mail.Body += "Email: " + Email.Text + "\n";
                    mail.Body += "Mensagem: " + Mensagem.Text + "\n";
                    mail.IsBodyHtml = false;

                    //2. Envia o email protocolo SMTP
                    //Protocolo (TCP/IP) Padrão de envio de mensagens de correio eletronico "email",
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.seudominio.com.br";
                    smtp.Credentials = new NetworkCredential("contato@seudominio.com.br", "sua senha");
                    smtp.EnableSsl = true; // pre requisito definido pelo provedor
                    smtp.Send(mail);


                }
                catch (Exception ex)
                {
                    Mensagem.Text = "Houve uma falha ao enviar o e-mail";
                    RecoverExceptions.SaveException(ex);

                }
               
            }

        }
    }
}
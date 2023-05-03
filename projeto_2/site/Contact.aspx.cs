using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Adicionado para enviar email
using System.Net;
using System.Net.Mail;
using ADS_2023;

namespace site
{
  public partial class Contact : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
      // Enviar os dados de contato por email

      string nome = edtNome.Text;
      string email = edtEmail.Text;
      string mensagem = edtMensagem.Text;

      MailMessage mail = new MailMessage();

      // Substitua pelo seu e-mail
      mail.From = new MailAddress("seu_email@example.com"); 
      
      // Substitua pelo e-mail do destinatário
      mail.To.Add("destinatario@example.com");

      mail.Subject = "Mensagem do Formulário de Contato";
      mail.Body = $"Nome: {nome}\nEmail: {email}\n\nMensagem:\n{mensagem}";

      // Substitua pelo seu servidor SMTP
      SmtpClient smtp = new SmtpClient("smtp.example.com");
      smtp.Port = 587;
      
      // Substitua pelo seu e-mail e senha
      smtp.Credentials = new NetworkCredential("seu_email@example.com", "sua_senha"); 
      smtp.EnableSsl = true;

      try
      {
          smtp.Send(mail);
          Response.Write("<script>alert('Mensagem enviada com sucesso!');</script>");
      }
      catch (Exception ex)
      {
          //Código que pode gerar exceção
          RecoverExceptions.SaveExceptions(ex);

          lblMensagem.Text = "Ocorreu um erro ao enviar a mensagem. Tente novamente mais tarde.";
      }
    }
  }
}
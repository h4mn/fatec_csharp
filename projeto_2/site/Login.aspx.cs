using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace site
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Entrar_Click(object sender, EventArgs e)
        {
            if (NomeAcesso.Text == "Admin" && Senha.Text == "12345")
            {
                // Cria a variavel de sessão para identificar que o usuário esta autenticado e
                // permitir a exibição das opções do menu.
                Session["autenticado"] = "";
                // 1. Inicializa a classe de autenticação
                System.Web.Security.FormsAuthentication.Initialize();
                // 2. CRIAR O TICKET
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "admin",
                DateTime.Now, DateTime.Now.AddMinutes(20), false,
                FormsAuthentication.FormsCookiePath);
                // 3. CRIPTOGRAFA P TICKET E GRAVAR NO COOKIE DO NAVEGADOR
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(ticket)));
                // Redireciona para o form que o usuário tentou acessar
                Response.Redirect(FormsAuthentication.GetRedirectUrl("Admin", false));
            }
            else
            {
                Erro.Text = "Dados de acesso invalidos";
            }
            }
        }
    }
}
using Datapost.Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
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
            // String de conexão
            string conexao = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={HttpContext.Current.Server.MapPath("~/App_Data/Usuarios.accdb")};Persist Security Info=False;";
            
            // Transação com o banco de dados
            DAO acesso = new DAO();

            string comando = $"SELECT * FROM Usuarios WHERE NomeAcesso = '{NomeAcesso.Text}' AND Senha = '{Senha.Text}'";
            
            DataTable dados = new DataTable();

            acesso.DataProviderName = DAO.ProviderName.OleDb;
            acesso.ConnectionString = conexao;

            dados = (DataTable)acesso.Query(comando);

            //if (dados.Rows.Count == 0) // Fazer tratamento de cadastro de usuário único (pra nota 10)
            if (dados.Rows.Count > 0)
            {
                // Cria a variavel de sessão para identificar que o usuário esta autenticado e
                // permitir a exibição das opções do menu.
                Session["autenticado"] = "";
                
                // 1. Inicializa a classe de autenticação
                FormsAuthentication.Initialize();
                
                // 2. CRIAR O TICKET                
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,                                      // Versão do ticket
                    "admin",                                // Nome do usuário
                    DateTime.Now,                           // Data e hora de criação do ticket
                    DateTime.Now.AddMinutes(20),            // Tempo de expiração do cookie
                    false,                                  // Se true, o cookie é persistente
                    FormsAuthentication.FormsCookiePath     // Caminho do cookie
                );
                
                // 3. CRIPTOGRAFA P TICKET E GRAVAR NO COOKIE DO NAVEGADOR
                string encryptTicket = FormsAuthentication.Encrypt(ticket);

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);

                Response.Cookies.Add(cookie);
                
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
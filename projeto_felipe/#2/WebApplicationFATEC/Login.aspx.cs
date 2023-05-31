using Datapost.Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationFATEC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Entrar_Click(object sender, EventArgs e)
        {
            // 1. definir a string de conexão
            string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/Usuarios.accdb") + ";Persist Security Info=False;";

            //2. Classe de Transação com o banco de dados
            DAO data = new DAO();

            string SQL = "SELECT * FROM Usuarios WHERE NomeAcesso='" + NomeAcesso.Text + "' AND Senha='" + Senha.Text + "'";

            DataTable tb = new DataTable();

            data.DataProviderName = DAO.ProviderName.OleDb;
            data.ConnectionString = conexao;

            tb = (DataTable)data.Query(SQL);

            //Se a tabela tb contém uma linha significa que o usuario foi encontrado
            if (tb.Rows.Count == 1)
            {
                // Cria a variavel de sessão para identificar que o usuário esta autenticado e
                // permitir a exibição das opções do menu.
                Session["autenticado"] = "";
                // 1. Inicializa a classe de autenticação
                System.Web.Security.FormsAuthentication.Initialize();
                // 2. CRIAR O TICKET
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, tb.Rows[0]["NomeCompleto"].ToString(),
                DateTime.Now, DateTime.Now.AddMinutes(20), false,
                FormsAuthentication.FormsCookiePath);
                // 3. CRIPTOGRAFA P TICKET E GRAVAR NO COOKIE DO NAVEGADOR
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(ticket)));
                // Redireciona para o form que o usuário tentou acessar
                Response.Redirect(FormsAuthentication.GetRedirectUrl(tb.Rows[0]["NomeCompleto"].ToString(), false));
                
            }
            else
            {
                Erro.Text = "Dados de acesso invalidos";
            }
        }
    }
    
}
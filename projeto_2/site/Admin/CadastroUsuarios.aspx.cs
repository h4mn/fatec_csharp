using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datapost.Access;

namespace site.Admin
{
    public partial class CadastroUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            // Validar os campos do formulário
            if (txtNomeAcesso.Text == string.Empty)
            {
                lblMensagem.Text = "O campo Nome é obrigatório!";
                return;
            } else {
                try
                {
                    // Se os campos estiverem válidos, então cria conexão com o banco de dados
                    // https://www.connectionstrings.com/access
                    string conexao = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={HttpContext.Current.Server.MapPath("~/App_Data/Database/Usuarios.accdb")};Persist Security Info=False;";

                    //<!-- Campos: Nome Completo, Email, NomeAcesso, Anotacoes, Senha -->
                    string comando = $"INSERT INTO Usuarios (NomeCompleto, Email, NomeAcesso, Anotacoes, Senha) VALUES ('{txtNomeCompleto.Text}', '{txtEmail.Text}', '{txtNomeAcesso.Text}', '{txtAnotacoes.Text}', '{txtSenha.Text}')";

                    DAO acesso = new DAO();
                    acesso.DataProviderName = DAO.ProviderName.OleDb;
                    acesso.ConnectionString = conexao;
                    acesso.Query(comando);

                }
                catch (Exception)
                {

                    throw;
                }
            }
            lblMensagem.Text = "Usuário cadastrado com sucesso!";
        }
       
    }
}
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
                // Se os campos estiverem válidos, então cria conexão com o banco de dados
                // https://www.connectionstrings.com/access
                // Provider=Microsoft.Jet.OLEDB.12.0;Data Source=C:\mydatabase.mdb;User Id=admin;Password=;

                string conexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/Database/Usuarios.accdb") + ";Persist Security Info=False;";

                //<!-- Campos: Nome Completo, Email, NomeAcesso, Anotacoes, Senha -->
                string comando = $"INSERT INTO Usuarios (NomeCompleto, Email, NomeAcesso, Anotacoes, Senha) VALUES ('{txtNome.Text}', '{txtEmail.Text}', '{txtNomeAcesso.Text}', '{txtAnotacoes.Text}', '{txtSenha.Text}')";

                // Criar objeto da classe AcessoDados
                DAO acesso = new DAO(conexao);
                acesso.DataProviderName = DAO.DataProvider.OleDb;
                acesso.ConnectionString = conexao;
                acesso.Query = comando;
            }


            // Enviar o comando SQL para o banco de dados inserir um novo usuário


            //Criar objeto da classe Usuario

            //Atribuir os valores dos campos do formulário para as propriedades do objeto

            //Chamar o método Inserir da classe Usuario

            //Limpar os campos do formulário

            //Exibir mensagem de sucesso
            lblMensagem.Text = "Usuário cadastrado com sucesso!";
        }
       
    }
}
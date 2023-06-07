using System;
using System.Data;
using System.Web;
using Datapost.Access;

namespace site.Admin
{
    public partial class CadastroUsuarios : System.Web.UI.Page
    {
        // https://www.connectionstrings.com/access
        string conexao = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={HttpContext.Current.Server.MapPath("~/App_Data/Usuarios.accdb")};Persist Security Info=False;";

        DAO acesso = new DAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarGrid();
            }
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            // Validar os campos do formulário
            if (txtNomeAcesso.Text == string.Empty)
            {
                lblMensagem.Text = "O campo Nome é obrigatório!";
                return;
            } else {
                string comando = "";

                if (Codigo.Text == "")
                {
                    comando = $"INSERT INTO Usuarios (NomeCompleto, Email, NomeAcesso, Anotacoes, Senha) VALUES ('{txtNomeCompleto.Text}', '{txtEmail.Text}', '{txtNomeAcesso.Text}', '{txtAnotacoes.Text}', '{txtSenha.Text}')";
                }
                else
                {
                    comando = $"UPDATE Usuarios SET NomeCompleto='{txtNomeCompleto.Text}', Email='{txtEmail.Text}', NomeAcesso='{txtNomeAcesso.Text}', Anotacoes='{txtAnotacoes.Text}', Senha='{txtSenha.Text}' WHERE Codigo = {Codigo.Text}";

                }
                acesso.DataProviderName = DAO.ProviderName.OleDb;
                acesso.ConnectionString = conexao;

                // Verifica se o nome de acesso já existe
                if (!PossoGravar(txtNomeAcesso.Text, Convert.ToInt32(Codigo.Text)))
                {
                    lblMensagem.Text = "Já existe um usuário com este nome de acesso!";
                    return;
                }
                acesso.Query(comando);

                CarregarGrid();
                LimparCampos();
            }
            lblMensagem.Text = "Usuário cadastrado com sucesso!";
        }

        protected void LimparCampos()
        {
            Codigo.Text = "";
            txtNomeCompleto.Text = "";
            txtEmail.Text = "";
            txtNomeAcesso.Text = "";
            txtAnotacoes.Text = "";
            txtSenha.Text = "";
            btnSalvar.Text = "Inserir";
            btnExcluir.Visible = false;
        }

        protected void CarregarGrid()
        {
            //Carrega o GridView com os dados da tabela Usuarios
            string comando = "SELECT Codigo, NomeCompleto, NomeAcesso FROM Usuarios ORDER BY NomeCompleto;";
            acesso.DataProviderName = DAO.ProviderName.OleDb;
            acesso.ConnectionString = conexao;
            ViewUsuarios.DataSource = acesso.Query(comando);
            ViewUsuarios.DataBind();
        }

        protected void ViewUsuarios_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //Preenche os campos do formulário com os dados do registro selecionado no GridView
            Codigo.Text = ViewUsuarios.SelectedRow.Cells[1].Text;
            string comando = $"SELECT * FROM Usuarios WHERE Codigo = {Codigo.Text};";

            acesso.DataProviderName = DAO.ProviderName.OleDb;
            acesso.ConnectionString = conexao;
            DataTable tabela = new DataTable();
            tabela = (DataTable)acesso.Query(comando);

            txtNomeCompleto.Text = tabela.Rows[0]["NomeCompleto"].ToString();
            txtEmail.Text = tabela.Rows[0]["Email"].ToString();
            txtNomeAcesso.Text = tabela.Rows[0]["NomeAcesso"].ToString();
            txtAnotacoes.Text = tabela.Rows[0]["Anotacoes"].ToString();
            txtSenha.Text = tabela.Rows[0]["Senha"].ToString();

            btnSalvar.Text = "Alterar";
            btnExcluir.Visible = true;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            string comando = $"DELETE FROM Usuarios WHERE Codigo = {Codigo.Text};";

            acesso.DataProviderName = DAO.ProviderName.OleDb;
            acesso.ConnectionString = conexao;
            acesso.Query(comando);
            CarregarGrid();
            LimparCampos();
            lblMensagem.Text = "Usuário excluído com sucesso!";
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected bool PossoGravar(string NomeAcesso, int Codigo)
        {
            string comando = $"select * from Usuarios where NomeAcesso = '{NomeAcesso}';";
            acesso.DataProviderName = DAO.ProviderName.OleDb;
            acesso.ConnectionString = conexao;
            DataTable tabela = new DataTable();
            tabela = (DataTable)acesso.Query(comando);

            if (tabela.Rows.Count > 0) {
                return (Codigo == Convert.ToInt32(tabela.Rows[0]["Codigo"])) ? true : false;
            } else {
                return true; // Não existe nenhum usuário com este nome de acesso
            }
        }

    }
}
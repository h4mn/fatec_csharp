using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datapost.Access;
using System.Data;

namespace WebApplicationFATEC.Admin
{
    public partial class CadastroUsuarios : System.Web.UI.Page
    {
        // 1. definir a string de conexão
        string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/Usuarios.accdb") + ";Persist Security Info=False;";

        //2. Classe de Transação com o banco de dados
        DAO data = new DAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CarregaGrid();
            }

        }
        protected void CarregaGrid()
        {
            //String de comando sql
            string sql = "SELECT Codigo, NomeCompleto FROM Usuarios ORDER BY NomeCompleto ";
            //Conecta no banco
            data.DataProviderName = DAO.ProviderName.OleDb;
            data.ConnectionString = conexao;
            //Executa o comando SQL e coloca o resultado no GridView
            ViewUsuarios.DataSource = data.Query(sql);
            ViewUsuarios.DataBind();
        }
        protected void Inserir_Click(object sender, EventArgs e)
        {
            //VALIDAÇÃO DOS DADOS
            if(NomeCompleto.Text.Trim() == "")
            {
                MsgError.Text = "Digite seu nome!";
            }
            //elseif, elseif elseif

            else
            {
                string comando = "";
                if(Codigo.Text == "")
                {
                    // 2. define string de comando SQL para Inserir o registro
                    comando = "INSERT INTO Usuarios(NomeCompleto,Email,NomeAcesso,Senha,Anotacoes) VALUES('" + NomeCompleto.Text + "','" + Email.Text + "','" + NomeAcesso.Text + "','" + Senha.Text + "','" + Anotacoes.Text + "')";
                }
                else
                {
                    comando = "UPDATE Usuarios SET Nomecompleto='" + NomeCompleto.Text + "',Email='" + Email.Text + "',NomeAcesso='" + NomeAcesso.Text + "',Senha='" + Senha.Text + "',Anotacoes='" + Anotacoes.Text + "'WHERE Codigo=" + Codigo.Text;
                }

                

                

                // 3. Enviar o comando para inserir
                //DAO data = new DAO();
                data.DataProviderName = DAO.ProviderName.OleDb;
                data.ConnectionString = conexao;
                data.Query(comando);

                CarregaGrid();
                Limpar();
                
            }
        }

        protected void Limpar()
        {
            Codigo.Text = "";
            NomeAcesso.Text = "";
            NomeCompleto.Text = "";
            Email.Text = "";
            Senha.Text = "";
            Anotacoes.Text = "";
            Inserir.Text = "Inserir";
            Excluir.Visible = false;
        }

        protected void ViewUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Codigo.Text = ViewUsuarios.SelectedRow.Cells[1].Text;

            string sql = "SELECT * FROM Usuarios WHERE Codigo=" + Codigo.Text;

            data.DataProviderName = DAO.ProviderName.OleDb;
            data.ConnectionString = conexao;

            System.Data.DataTable tb = new System.Data.DataTable();

            tb = (DataTable)data.Query(sql);

            NomeCompleto.Text = tb.Rows[0]["NomeCompleto"].ToString();
            Email.Text = tb.Rows[0]["Email"].ToString();
            NomeAcesso.Text = tb.Rows[0]["NomeAcesso"].ToString();
            Senha.Text = tb.Rows[0]["Senha"].ToString();
            Anotacoes.Text = tb.Rows[0]["Anotacoes"].ToString();
            Inserir.Text = "Editar";
            Excluir.Visible = true;
        }

        protected void Excluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Usuarios WHERE Codigo=" + Codigo.Text;

            data.DataProviderName = DAO.ProviderName.OleDb;
            data.ConnectionString = conexao;
            data.Query(sql);
            CarregaGrid();
            Limpar();
        }
    }
}
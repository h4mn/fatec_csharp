using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using Microsoft.VisualBasic; //Necessário para usar a função IsDate

namespace fatec_csharp
{
	public partial class _default : System.Web.UI.Page
	{
		// Criar uma contante para o arquivo cadastro
		const string FILE_CADASTRO = "~/content/cadastro.txt";

		protected void Page_Load(object sender, EventArgs e)
		{
			//Lbl_Mensagem.Text = $"Usuário {Request.Form["TxtBox_NomeCompleto"]} cadastrado";
			//Debug.WriteLine(Request.Form["TxtBox_NomeCompleto"]);
			//Debug.WriteLine(Request.Form["TxtBox_Email"]);
		}
		protected void OnClick_Enviar(object sender, EventArgs e)
		{
			DateTime dtResult;
			//validação
			if (TxtBox_NomeCompleto.Text.Trim() == "")
			{
				Lbl_Mensagem.Text = "Preencha o campo Nome";
			}
			else if (TxtBox_Email.Text.Trim() == "")
			{
				Lbl_Mensagem.Text = "Preencha o campo Email";
			}
			else if (TxtBox_Telefone.Text.Trim() == "")
			{
				Lbl_Mensagem.Text = "Preencha o campo Telefone";
			}
			//Modo C#
			//else if (!DateTime.TryParse(TxtBox_Nascimento.Text.Trim(), out dtResult))
			//Modo Visual Basic
			else if (!Information.IsDate(TxtBox_Nascimento.Text.Trim()))
			{			
				//Lbl_Mensagem.Text = $"Data {dtResult} inválida";
				Lbl_Mensagem.Text = "Data inválida";
			}
			else if (RadioBtnList_Sexo.SelectedValue == "")
			{
				Lbl_Mensagem.Text = "Selecione o Sexo";
			}
			else if (DropDownList_Atividade.SelectedValue == "0")
			{
				Lbl_Mensagem.Text = "Selecione a Atividade";
			}
			else if (!Information.IsNumeric(TextBox_NumFuncionarios.Text)
				& Math.Sign(Convert.ToInt16(TextBox_NumFuncionarios.Text)) == -1
				)
            {
				Lbl_Mensagem.Text = "Digite o Número de Funcionários";
			}
			else if (TextBox_Observacoes.Text.Length > 255)
			{
				Lbl_Mensagem.Text = "O campo Observações deve ter no máximo 255 caracteres";
			}
			else
			{
				Lbl_Mensagem.Text = $"Usuário <b>{Request.Form["TxtBox_NomeCompleto"]}</b> cadastrado";
				Debug.WriteLine(Request.Form["TxtBox_NomeCompleto"]);
				Debug.WriteLine(Request.Form["TxtBox_Email"]);

				//Execute o processamento
				//Gravar os dados emum arquivo txt no disco

				// 1. construa a string que será gravada do disco, concatenando os dados do formulário
				string strDados = $"{DateTime.Now.ToString("yyyyMMddHHmmss")},"
					+ $"\"{TxtBox_NomeCompleto.Text.Trim()}\","
					+ $"\"{TxtBox_Email.Text.Trim()}\","
					+ $"\"{TxtBox_Telefone.Text.Trim()}\","
					+ $"\"{TxtBox_Nascimento.Text.Trim()}\","
					+ $"\"{RadioBtnList_Sexo.SelectedValue}\","
					+ $"\"{DropDownList_Atividade.SelectedValue}\","
					+ $"\"{TextBox_NumFuncionarios.Text.Trim()}\","
					+ $"\"{TextBox_Observacoes.Text.Trim()}\""
					+ Environment.NewLine;

				// Usar label para depurar
				// Lbl_Mensagem.Text = strDados + $" {Int16.Parse(TextBox_NumFuncionarios.Text) <= 0}";
				Lbl_Mensagem.Text = strDados;

				// 2. Gravar os dados em um arquivo txt no disco, chamado "cadastro.txt"
				string caminho = Context.Server.MapPath(FILE_CADASTRO);
				System.IO.File.AppendAllText(caminho, strDados);

			}
		}

        protected void OnClick_Excluir(object sender, EventArgs e)
        {
			// Excluir o arquivo cadastro.txt
			string caminho = Context.Server.MapPath(FILE_CADASTRO);
			
			// Verifica se o arquivo existe
			if (System.IO.File.Exists(caminho))
				System.IO.File.Delete(caminho);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace fatec_csharp
{
	public partial class _default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//Lbl_Mensagem.Text = $"Usuário {Request.Form["TxtBox_NomeCompleto"]} cadastrado";
			//Debug.WriteLine(Request.Form["TxtBox_NomeCompleto"]);
			//Debug.WriteLine(Request.Form["TxtBox_Email"]);
		}
		protected void OnClick_Enviar(object sender, EventArgs e)
		{
			//validação
			if(TxtBox_NomeCompleto.Text.Trim() == "") {
				Lbl_Mensagem.Text = "Preencha o campo Nome";
			}
			else
            {
				Lbl_Mensagem.Text = $"Usuário <b>{Request.Form["TxtBox_NomeCompleto"]}</b> cadastrado";
				Debug.WriteLine(Request.Form["TxtBox_NomeCompleto"]);
				Debug.WriteLine(Request.Form["TxtBox_Email"]);
			}
		}

	}
}
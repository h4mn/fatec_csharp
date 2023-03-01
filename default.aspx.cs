using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace fatec_csharp
{
	public partial class _default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Lbl_Mensagem.Text = $"Usuário {Request.Form["TxtBox_NomeCompleto"]} cadastrado";
			Console.WriteLine(Request.Form["TxtBox_NomeCompleto"]);
			Console.WriteLine(Request.Form["TxtBox_Email"]);

		}
	}
}
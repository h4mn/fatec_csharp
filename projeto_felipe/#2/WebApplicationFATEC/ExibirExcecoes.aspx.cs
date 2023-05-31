using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ads2023;

namespace WebApplicationFATEC
{
    public partial class ExibirExcecoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string texto = RecoverExceptions.LoadExceptions().Replace("\n", "<br/>");
            Excecoes.Text = texto;
        }
    }
}
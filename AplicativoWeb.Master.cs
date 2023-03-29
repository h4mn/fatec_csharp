using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace fatec_csharp
{
    public partial class AplicativoWeb : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(
                    Page.Master.FindControl("menu").ToString()
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            // atribuir ao objeto menu o elemento div com id "menu" do arquivo AplicativoWeb.Master
            HtmlGenericControl menu = (HtmlGenericControl)FindControl("menu");


            // Pegar a tag a de uma div com id "menu" e adicionar o atributo class "menu-active" no elemento a que contem o texto "Home"
            if (Page.Title == "Home")
            {
                menu.InnerHtml = menu.InnerHtml.Replace("<a href=\"Home.aspx\">Home</a>", "<a href=\"Home.aspx\" class=\"menu-active\">Home</a>");
            }
            else if (Page.Title == "Sobre")
            {
                menu.InnerHtml = menu.InnerHtml.Replace("<a href=\"Sobre.aspx\">Sobre</a>", "<a href=\"Sobre.aspx\" class=\"menu-active\">Sobre</a>");
            }
        }
        public void MarcarMenuItem(object tag_a)
        {
            // exibir o texto do elemento clicado na janela imediata
            Console.WriteLine(tag_a.ToString());
        }
    }
}
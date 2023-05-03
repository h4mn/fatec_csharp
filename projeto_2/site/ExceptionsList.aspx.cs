using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Newtonsoft.Json;
using ADS_2023;

namespace site
{
  public partial class ExceptionsList : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string RenderExceptionsTable()
    {
        List<Dictionary<string, string>> exceptions = RecoverExceptions.ReadExceptions();
        StringBuilder tableContent = new StringBuilder();

        foreach (var ex in exceptions)
        {
            string conteudo = ex["conteudo"];
            tableContent.AppendLine($"<tr>");
            tableContent.AppendLine($"  <td>{ex["Date"]}</td>");
            tableContent.AppendLine($"  <td>{ex["Message"]}</td>");
            tableContent.AppendLine($"  <td><a href=\"ExceptionsDetails.aspx?conteudo={conteudo}\">Detalhes</a></td>");
            tableContent.AppendLine($"</tr>");
        }

        return tableContent.ToString();
    }

  }
}
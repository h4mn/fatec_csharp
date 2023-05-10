using System;
using System.Collections.Generic;
using System.Text;
using ADS_2023;

namespace site
{
    public partial class ExceptionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LiteralExceptions.Text = RenderExceptionsTable();
        }
        protected string RenderExceptionsTable()
        {
            List<Dictionary<string, string>> exceptions = RecoverExceptions.ReadExceptions();
            StringBuilder tableContent = new StringBuilder();

            foreach (var ex in exceptions)
            {
                tableContent.AppendLine($"<tr>");
                tableContent.AppendLine($"  <td>{ex["Date"]}</td>");
                tableContent.AppendLine($"  <td>{ex["Message"]}</td>");
                tableContent.AppendLine($"  <td><a href=\"ExceptionsDetails.aspx?Date={ex["Date"]}&Message={ex["Message"]}&Type={ex["Type"]}&Source={ex["Source"]}&StackTrace={ex["StackTrace"]}&TargetSite={ex["TargetSite"]}\">Detalhes</a></td>");
                tableContent.AppendLine($"</tr>");
            }

            return tableContent.ToString();
        }
    }
}
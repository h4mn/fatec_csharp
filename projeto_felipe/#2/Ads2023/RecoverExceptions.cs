using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ads2023
{
    public static class RecoverExceptions
    {   /// <summary>
        /// Salva os dados da exceção no arquivo de log
        /// </summary>
        /// <param name="ex"></param>
        public static void SaveException(Exception ex)
        {
            string caminhoFisico = System.Web.HttpContext.Current.Server.MapPath("~/LogExceptions.txt");
            string conteudo = "Data: " + DateTime.Now.ToString() + "\n";
            conteudo += "Mensagem: " + ex.Message + "\n";
            conteudo += ex.GetType().ToString() + "\n";
            conteudo += ex.StackTrace + "\n"; //TRAZ AS INFORMAÇÕES SOBRE O ERRO, LINHAS, ETC...
            conteudo += "-----------------------------------------------------------------\n";

            System.IO.File.AppendAllText(caminhoFisico, conteudo);//SALVA O ARQUIVO
        }
        /// <summary>
        /// Lê o arquivo de log de exceções e retorna o texto
        /// </summary>
        /// <returns></returns>
        public static string LoadExceptions()
        {
            string caminhoFisico = System.Web.HttpContext.Current.Server.MapPath("~/LogExceptions.txt");
            return System.IO.File.ReadAllText(caminhoFisico);//VERIFICAR SE PODE RETIRAR O SYSTEM.WEB
        }

    }
}

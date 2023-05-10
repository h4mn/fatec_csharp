using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ADS_2023
{

    /// <summary>
    /// Responsável por salvar as exceções em um arquivo de texto
    /// </summary>
    public static class RecoverExceptions
    {
        /// <summary>
        /// Retorna o caminho físico do arquivo de "LogExceptions.txt"
        /// </summary>
        public static string GetCaminhoFisico()
        {
            //Retorna o caminho físico do arquivo de "LogExceptions.txt"
            string caminhoFisico = System.Web.HttpContext.Current.Server.MapPath("~/LogExceptions.txt");

            return caminhoFisico;
        }

        /// <summary>
        /// Salva as exceções em um arquivo de texto
        /// </summary>
        public static void SaveExceptions_(Exception ex)
        {
            string conteudo = "Date: " + DateTime.Now.ToString() + "\n";
            conteudo += "Message: " + ex.Message + "\n";
            conteudo += "Type: " + ex.GetType().ToString() + "\n";
            conteudo += "Source: " + ex.Source + "\n";
            conteudo += "StackTrace: " + ex.StackTrace + "\n";
            conteudo += "TargetSite: " + ex.TargetSite + "\n";
            conteudo += "--------------------------------------------------\n";

            System.IO.File.AppendAllText(GetCaminhoFisico(), conteudo);

        }

        /// <summary>
        /// Salva as exceções em um arquivo de texto
        /// </summary>
        public static void SaveExceptions(Exception ex)
        {
            string filePath = GetCaminhoFisico();
            List<Dictionary<string, string>> exceptions = new List<Dictionary<string, string>>();

            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(jsonContent))
                {
                    try
                    {
                        exceptions = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonContent);
                    }
                    catch (JsonException)
                    {
                        // O arquivo pode estar corrompido ou em um formato inválido. 
                        // Neste caso, ignore o erro e comece com uma lista vazia de exceções.
                    }
                }
            }

            Dictionary<string, string> exceptionData = new Dictionary<string, string>
            {
                { "Date", DateTime.Now.ToString() },
                { "Message", ex.Message },
                { "Type", ex.GetType().ToString() },
                { "Source", ex.Source },
                { "StackTrace", ex.StackTrace },
                { "TargetSite", ex.TargetSite?.ToString() }
            };

            exceptions.Add(exceptionData);

            string jsonExceptions = JsonConvert.SerializeObject(exceptions, Formatting.Indented);
            File.WriteAllText(filePath, jsonExceptions);
        }

        /// <summary>
        /// Lê as exceções salvas no arquivo de texto
        /// </summary>
        public static string ReadExceptions_()
        {
            string conteudo = System.IO.File.ReadAllText(GetCaminhoFisico());
            conteudo = conteudo.Replace("\n", "<br />");
            return conteudo;
        }

        /// <summary>
        /// Lê as exceções salvas no arquivo de texto
        /// </summary>
        public static List<Dictionary<string, string>> ReadExceptions()
        {
            string filePath = GetCaminhoFisico();
            List<Dictionary<string, string>> exceptions = new List<Dictionary<string, string>>();

            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(jsonContent))
                {
                    exceptions = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonContent);
                }
            }

            return exceptions;
        }
    }

}

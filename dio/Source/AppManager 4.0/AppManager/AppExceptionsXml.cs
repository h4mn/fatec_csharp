using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// namespace para manipular xml
using System.Xml;
// namespace para trab. arquinove/pastas
using System.IO;
// namespace para trabalhar com dados
using System.Data;

namespace AppManager
{
    /// <summary>
    /// Recupera os dados de uma exceção da aplicação.
    /// </summary>
    public class AppExceptionXml
    {
        #region PUBLICAS
        /// <summary>
        ///  Caminho do arquivo LogExceptions.xml
        /// </summary>
        public string PathFullFile
        {
            get
            {
                return m_pathException;
            }
            set
            {
                m_pathException = value;
            }
        }
        private string m_pathException = Directory.GetCurrentDirectory() + @"\Exceptions.xml";

        /// <summary>
        /// Salva uma exceção no arquivo de log exception.xml.
        /// </summary>
        /// <param name="ex">Dados da exceção do tipo exception. </param>
        public Boolean SaveException(Exception ex)
        {
            Create();
            string dt = DateTime.Now.ToString();
            if (AddRow(dt))
            {
                AddColumn(dt, "source", ex.Source);
                AddColumn(dt, "message", ex.Message);
                AddColumn(dt, "datetime", dt);
            }
            return true;
        }

        /// <summary>
        /// Retorna o arquivo de log de exceções em um DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable LoadException()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            if (File.Exists(m_pathException))
            {
                ds.ReadXml(m_pathException);
                dt = ds.Tables[0];
            }
            ds.Dispose();
            return dt;
        }

        /// <summary>
        /// Limpa o arquivo de log das exceções
        /// </summary>
        /// <returns></returns>
        public Boolean ClearException()
        {
            if (File.Exists(m_pathException))
            {
                FileInfo src = new FileInfo(m_pathException);
                src.Delete();
                return true;
            }
            else
                return false;
        }
        #endregion
       
        #region PRIVADAS
        /// <summary>
        ///  Cria o arquivo XML das exceções LogExceptions.xml
        /// </summary>
        /// <param name="subscribe">Determina se o arquivo sera "true" ou não "false" subscrito se existir.Default: false.</param>
        /// <returns>Retorna True ou False</returns>
        private bool Create(Boolean subscribe = false)
        {
            if ((!File.Exists(m_pathException)) | (File.Exists(m_pathException) & subscribe))
            {
                XmlTextWriter xmlDoc = new XmlTextWriter(m_pathException, Encoding.UTF8);
                xmlDoc.WriteStartDocument();
                xmlDoc.WriteStartElement("rows");

                xmlDoc.WriteEndElement();
                xmlDoc.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Adiciona uma nova exceção "linha" na tabela de exceções. 
        /// </summary>
        /// <param name="key">Código da linha</param>
        private Boolean AddRow(string key)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList rows = null;
            XmlNode row = null;
            XmlElement newLine = null;
            xmlDoc.Load(m_pathException);
            rows = xmlDoc.SelectNodes("rows");
            if (rows.Count > 0)
            {
                row = rows.Item(0);
                newLine = xmlDoc.CreateElement("row");
                newLine.SetAttribute("key", key);
                row.AppendChild(newLine);
                xmlDoc.Save(m_pathException);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Adiciona uma nova coluna na linha da exceção definida pela chave "key"
        /// </summary>
        /// <param name="key">Código da linha  </param>
        /// <param name="name">Nome da coluna          </param>
        /// <param name="value">Valor da coluna                </param>
        /// <returns></returns>
        private bool AddColumn(string key, string name, string value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList rows = null;
            XmlNode row = null;
            XmlElement newColumn = null;
            xmlDoc.Load(m_pathException);
            rows = xmlDoc.SelectNodes("rows/row[@key='" + key + "']");
            if (rows.Count > 0)
            {
                row = rows.Item(0);
                //insere o item 
                newColumn = xmlDoc.CreateElement(name);
                newColumn.InnerText = value;
                row.AppendChild(newColumn);
                xmlDoc.Save(m_pathException);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina o arquivo de exceções
        /// </summary>
        /// <returns></returns>
        private Boolean Delete()
        {
            try
            {
                System.IO.File.Delete(m_pathException);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

    }

}

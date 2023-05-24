using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace AppUtilities
{
    /// <summary>
    /// Esta Classe contém métodos utilitários  
    /// </summary>
    public class Util
    {

        /// <summary>
        /// Obtem a string de mudança de linha em função da plataforma.
        /// "\r\n" (\u000D\u000A) para Windows
        /// "\n" (\u000A) para Linux
        /// </summary>
        public static String NewLine
        {
            get
            {
                Contract.Ensures(Contract.Result<String>() != null);
#if !PLATFORM_UNIX
                return "\r\n";
#else
                    return "\n";
#endif // !PLATFORM_UNIX
            }
        }


        /// <summary>
        /// Obtem o endereço completo a partir do CEP informado
        /// </summary>
        /// <param name="cep">numero do cep</param>
        /// <returns>Retorna a estrutura CEP com os dados do endereço</returns>
        public static CEP GetCEP(string cep)
        {
            //Link WebService dos Correios : https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl

            CEP cp = new CEP();
            try
            {
                // cria uma instancia do web service do correio
                Correios.AtendeClienteClient ws = new Correios.AtendeClienteClient("AtendeClientePort");
                var dados = ws.consultaCEP(cep);

                if (dados != null)
                {
                    cp.Endereco = dados.end;
                    cp.Complemento = dados.complemento;
                    cp.Complemento2 = dados.complemento2;
                    cp.Bairro = dados.bairro;
                    cp.Cidade = dados.cidade;
                    cp.Estado = dados.uf;
                }
            }
            catch (Exception)
            {
                cp.Falha = "CEP Inválido";
            }

            return cp;
        }
        /// <summary>
        /// Dados obtidos a partir do CEP informado
        /// </summary>
        public struct CEP
        {
            /// <summary>
            /// 
            /// </summary>
            public string Falha;
            /// <summary>
            /// 
            /// </summary>
            public string Endereco;
            /// <summary>
            /// 
            /// 
            /// </summary>
            public string Complemento;
            /// <summary>
            /// 
            /// </summary>
            public string Complemento2;
            /// <summary>
            /// 
            /// </summary>
            public string Bairro;
            /// <summary>
            /// 
            /// </summary>
            public string Cidade;
            /// <summary>
            /// 
            /// </summary>
            public string Estado;
        }
    }
}
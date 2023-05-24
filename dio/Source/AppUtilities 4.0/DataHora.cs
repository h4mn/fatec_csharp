using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace AppUtilities
{
   /// <summary>
   /// Classe para tratar de data e hora
   /// </summary>
   public class DataHora
   {

      /// <summary>
      /// Verifica se um valor pode ser convertido em uma data
      /// </summary>
      /// <param name="value">string com o valor</param>
      /// <returns></returns>
      public static bool isDate(string value)
      {
         DateTime date;
         string[] formatos = { "dd/MM/yyyy", "ddMMyyyy", "dMMyyyy" };

         foreach (var forma in formatos)
         {
            if (DateTime.TryParseExact(value, forma, CultureInfo.CurrentCulture, DateTimeStyles.None, out date)) return true;
         }
         return false;
      }

      /// <summary>
      /// Retorna verdadeiro se for possível converter o valor informado no formato espeficidado.
      /// </summary>
      /// <param name="value">valor para converter em data</param>
      /// <param name="format">formato para conversão</param>
      /// <returns></returns>
      public static bool isDate(string value, string format)
      {
         DateTime date;

         if (DateTime.TryParseExact(value, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out date)) return true;
         return false;
      }

   }
}

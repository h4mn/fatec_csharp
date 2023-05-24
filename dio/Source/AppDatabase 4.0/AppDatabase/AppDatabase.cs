using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace AppDatabase
{

   #region UTILITÁRIOS
   /// <summary>
   /// Contém métodos utilitários de banco de dados
   /// </summary>
   public static class Utilities
   {

      /// <summary>
      /// Método para filtrar caracteres/comandos indesejados em expressões sql.
      /// </summary>
      /// <param name="exp"></param>
      /// <returns></returns>
      public static string Filter(string exp)
      {
         if (!string.IsNullOrEmpty(exp))
         {
            exp = exp.Replace("'", "''");
            exp = exp.Trim();
            return exp;
         }
         else return "";
      }

   }

   #endregion

   #region TRANSAÇÕES NO ACCESS/EXCEL

   /// <summary>
   /// Transações no provedor de dados OLEDb (Access, Excel, Word)
   /// </summary>
   public class OleDBTransaction
   {
      /// <summary>
      /// String de conexão com o banco de Dados.
      /// Deve ser informada antes da execução do método Query.
      /// http://www.connectionstrings.com
      /// </summary>
      public string ConnectionString
      {
         get
         {
            return m_ConnectionString;
         }
         set
         {
            m_ConnectionString = value;
         }
      }
      private string m_ConnectionString;

      /// <summary>
      /// Obtem os dados da exceção ocorrida durante a execução do comando.  
      /// </summary>
      public Exception ExceptionDB
      {
         get
         {
            return m_ExceptionDB;
         }
      }
      private Exception m_ExceptionDB;


      /// <summary>
      /// Este método executa uma transação SQL no Banco de Dados OleDb ACCESS/EXCEL.
      /// Retorna um objeto "DataTable" se a consulta tiver um comando "SELECT" ou retorna o número de registros afetados se a consulta tiver "INSERT,UPDATE ou DELETE"
      /// </summary>
      /// <param name="querySql">String com o comando SQL. "Select, Insert, Update ou Delete"</param>
      public object Query(string querySql)
      {
         DataTable tb = new DataTable();
         OleDbConnection conn = new OleDbConnection(m_ConnectionString);
         OleDbCommand cmd = new OleDbCommand();
         try
         {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querySql;
            cmd.Connection = conn;
            conn.Open();
            // Se houver um select na query sql 
            if (querySql.ToLower().IndexOf("select", 0) == 0)
            {
               tb.Load(cmd.ExecuteReader());
               // Retorna o DataTable com o resultado da consulta
               return tb;
            }
            else
            {
               int n = cmd.ExecuteNonQuery();
               // Retorna o número de registros afetados pela consulta
               return n;
            }
         }
         catch (Exception ex)
         {
            // faça o tratamento da exceção aqui (registrar a exceção no arquivo de log por exemplo)

            m_ExceptionDB = ex;
            throw ex;
         }
         finally
         {
            tb.Dispose();
            conn.Close();
         }
      }

      /// <summary>
      /// Método para inserir ou editar um registro de uma tabela do banco de dados.\r\n
      /// se a chave primária informada existir, o registro será atualizado.\r\n 
      /// se a chave primária não existir o registro será adicionado.
      /// </summary>
      /// <param name="tableName">Nome da tabela do banco de dados</param>
      /// <param name="model">Model da tabela (atributos e valores)</param>
      /// <param name="Keys">Chave(s) primaria</param>
      /// <returns></returns>
      public bool InsertUpdate(string tableName, object model, string Keys)
      {
         string _values = "";
         string sqlSelect = "";
         string sqlUpdate = "";
         string sqlInsert = "";
         string _where = "";
         string _fields = "";

         Type tipo = model.GetType();
         PropertyInfo[] propriedades = tipo.GetProperties(BindingFlags.Public | BindingFlags.Instance);

         foreach (PropertyInfo info in propriedades)
         {
            if (info.GetValue(model, null) != null)
            {
               _fields += info.Name + ",";

               if (info.PropertyType == Type.GetType("System.String") || info.PropertyType == Type.GetType("System.Decimal"))
               {
                  _values += "'" + info.GetValue(model, null) + "',";
                  sqlUpdate += info.Name + " ='" + Utilities.Filter(info.GetValue(model, null).ToString()) + "',";
               }
               else
               {
                  _values += info.GetValue(model, null) + ",";
                  sqlUpdate += info.Name + " = " + Utilities.Filter(info.GetValue(model, null).ToString()) + ",";
               }

               if (Keys.IndexOf(info.Name, 0) != 0)
               {
                  _where += info.Name + " =" + Utilities.Filter(info.GetValue(model, null).ToString()) + " AND ";
               }
            }
         }
         sqlUpdate = sqlUpdate.Substring(0, sqlUpdate.Length - 1);
         _where = _where.Substring(0, _where.Length - 4);
         _fields = _fields.Substring(0, _fields.Length - 1);
         _values = _values.Substring(0, _values.Length - 1);

         sqlSelect = "SELECT * FROM " + tableName + " WHERE " + _where + ";";
         sqlUpdate = "UPDATE " + tableName + " SET " + sqlUpdate + " WHERE " + _where + ";";
         sqlInsert = "INSERT INTO " + tableName + "(" + _fields + ") VALUES(" + _values + ");";

         DataTable tb = (DataTable)Query(sqlSelect);
         if (tb.Rows.Count == 0) Query(sqlInsert);
         else Query(sqlUpdate);

         return true;
      }
   }

   #endregion

   #region TRANSAÇÕES NO FIREBIRD
   /// <summary>
   /// Transações no provedor de dados FireBird 2.5
   /// </summary>   /// 
   public class FireBirdTransaction
   {

      /// <summary>
      /// String de conexão com o banco de Dados.
      /// Deve ser informada antes da execução do método Query.
      /// </summary>
      public string ConnectionString
      {
         get
         {
            return m_ConnectionString;
         }
         set
         {
            m_ConnectionString = value;
         }
      }
      private string m_ConnectionString;

      /// <summary>
      /// Obtem os dados da exceção ocorrida durante a execução do comando.  
      /// </summary>
      public Exception ExceptionDB
      {
         get
         {
            return m_ExceptionDB;
         }
      }
      private Exception m_ExceptionDB;


      /// <summary>
      /// Este método executa uma transação SQL no Banco de Dados FireBird.
      /// Retorna um objeto "DataTable" se a consulta tem um comando "Select" ou o número de registros afetados se a consulta tem um "Insert,Update ou Delete"
      /// </summary>
      /// <param name="querySql">String com o comando SQL. "Select, Insert, Update ou Delete" </param>
      public object Query(string querySql)
      {
         DataTable tb = new DataTable();
         FbConnection conn = new FbConnection(m_ConnectionString);
         FbCommand cmd = new FbCommand();
         try
         {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querySql;
            cmd.Connection = conn;
            conn.Open();
            querySql = querySql.ToLower();
            // Se houver um select na query sql 
            if (querySql.IndexOf("select", 0) == 0)
            {
               tb.Load(cmd.ExecuteReader());
               // Retorna o DataTable com o resultado da consulta
               return tb;
            }
            else
            {
               int n = cmd.ExecuteNonQuery();
               // Retorna o número de registros afetados pela consulta
               return n;
            }
         }
         catch (Exception ex)
         {
            // faça o tratamento da exceção aqui (registrar a exceção no arquivo de log por exemplo)
            m_ExceptionDB = ex;
            throw ex;
         }
         finally
         {
            tb.Dispose();
            conn.Close();
         }
      }


      /// <summary>
      /// Executa um comando SELECT no database.
      /// Retorna um DataTable com o resultado da consulta.
      /// </summary>
      /// <param name="querySql">String com a query sql</param>
      /// <returns></returns>
      public DataTable Select(string querySql)
      {
         DataTable tb = new DataTable();
         FbConnection conn = new FbConnection(m_ConnectionString);
         FbCommand cmd = new FbCommand();
         try
         {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querySql;
            cmd.Connection = conn;
            conn.Open();
            tb.Load(cmd.ExecuteReader());
            return tb;
         }
         catch (Exception ex)
         {
            m_ExceptionDB = ex;
            throw ex;
         }
         finally
         {
            tb.Dispose();
            conn.Close();
         }
      }


      /// <summary>
      /// Executa um comando INSERT, UPDATE ou DELETE no banco de dados.
      /// Retorna um Int32 contendo o número de registros afetados pelo comando.
      /// </summary>
      /// <param name="querySql">string com a Query Sql</param>
      /// <returns></returns>
      public Int32 Cmd(string querySql)
      {
         FbConnection conn = new FbConnection(m_ConnectionString);
         FbCommand cmd = new FbCommand();
         try
         {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querySql;
            cmd.Connection = conn;
            conn.Open();
            int n = cmd.ExecuteNonQuery();
            return n;
         }
         catch (Exception ex)
         {
            m_ExceptionDB = ex;
            throw ex;
         }
         finally
         {
            conn.Close();
         }
      }


   }
   #endregion

   #region TRANSAÇÕES NO MYSQL
   /// <summary>
   /// Transação no provedor de dados MySql
   /// </summary>
   public class MySqlTransaction
   {

      /// <summary>
      /// String de conexão com o banco de Dados.
      /// Deve ser informada antes da execução do método Query.
      /// </summary>
      public string ConnectionString
      {
         get
         {
            return m_ConnectionString;
         }
         set
         {
            m_ConnectionString = value;
         }
      }
      private string m_ConnectionString;

      /// <summary>
      /// Obtem os dados da exceção ocorrida durante a execução do comando.  
      /// </summary>
      public Exception ExceptionDB
      {
         get
         {
            return m_ExceptionDB;
         }
      }
      private Exception m_ExceptionDB;


      /// <summary>
      /// Este método executa uma transação SQL no Banco de Dados FireBird.
      /// Retorna um objeto "DataTable" se a consulta tem um comando "Select" ou o número de registros afetados se a consulta tem um "Insert,Update ou Delete"
      /// </summary>
      /// <param name="querySql">String com o comando SQL. "Select, Insert, Update ou Delete" </param>
      public object Query(string querySql)
      {
         DataTable tb = new DataTable();
         MySqlConnection conn = new MySqlConnection(m_ConnectionString);
         MySqlCommand cmd = new MySqlCommand();
         try
         {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querySql;
            cmd.Connection = conn;
            conn.Open();
            querySql = querySql.ToLower();
            // Se houver um select na query sql 
            if (querySql.IndexOf("select", 0) == 0)
            {
               tb.Load(cmd.ExecuteReader());
               // Retorna o DataTable com o resultado da consulta
               return tb;
            }
            else
            {
               int n = cmd.ExecuteNonQuery();
               // Retorna o número de registros afetados pela consulta
               return n;
            }
         }
         catch (Exception ex)
         {
            // faça o tratamento da exceção aqui (registrar a exceção no arquivo de log por exemplo)
            m_ExceptionDB = ex;
            throw ex;
         }
         finally
         {
            tb.Dispose();
            conn.Close();
         }
      }

      /// <summary>
      /// Executa um comando SELECT no database.
      /// Retorna um DataTable com o resultado da consulta.
      /// </summary>
      /// <param name="querySql">String com a query sql</param>
      /// <returns></returns>
      public DataTable Select(string querySql)
      {
         DataTable tb = new DataTable();
         MySqlConnection conn = new MySqlConnection(m_ConnectionString);
         MySqlCommand cmd = new MySqlCommand();
         try
         {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querySql;
            cmd.Connection = conn;
            conn.Open();
            tb.Load(cmd.ExecuteReader());
            return tb;
         }
         catch (Exception ex)
         {
            m_ExceptionDB = ex;
            throw ex;
         }
         finally
         {
            tb.Dispose();
            conn.Close();
         }
      }


      /// <summary>
      /// Executa um comando INSERT, UPDATE ou DELETE no banco de dados.
      /// Retorna um Int32 contendo o número de registros afetados pelo comando.
      /// </summary>
      /// <param name="querySql">string com a Query Sql</param>
      /// <returns></returns>
      public Int32 Cmd(string querySql)
      {
         MySqlConnection conn = new MySqlConnection(m_ConnectionString);
         MySqlCommand cmd = new MySqlCommand();
         try
         {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querySql;
            cmd.Connection = conn;
            conn.Open();
            int n = cmd.ExecuteNonQuery();
            return n;
         }
         catch (Exception ex)
         {
            m_ExceptionDB = ex;
            throw ex;
         }
         finally
         {
            conn.Close();
         }
      }


   }
   #endregion
}

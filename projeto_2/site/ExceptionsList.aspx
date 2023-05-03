<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExceptionsList.aspx.cs" Inherits="site.ExceptionsList" %>

<div>
  <table>
    <tr>
      <th>Data</th>
      <th>Mensagem</th>
      <th>Detalhes</th>
    </tr>
    <%= RenderExceptionsTable() %>
  </table> 

</div>

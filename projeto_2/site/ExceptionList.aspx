<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExceptionList.aspx.cs" Inherits="site.ExceptionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
      <table>
        <tr>
          <th>Data</th>
          <th>Mensagem</th>
          <th>Detalhes</th>
        </tr>
        <asp:Literal ID="LiteralExceptions" runat="server" />    
      </table> 
    </div>
</asp:Content>
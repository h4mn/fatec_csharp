<%@ Page Title="" Language="C#" MasterPageFile="~/AplicativoWeb.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="fatec_csharp.Pages.Contato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudo" runat="server">
    <h2>Contato</h2>
    <form>
        <div>
            <label for="nome">Nome:</label>
            <input type="text" id="nome" name="nome">
        </div>
        <div>
            <label for="email">Email:</label>
            <input type="email" id="email" name="email">
        </div>
        <div>
            <label for="mensagem">Mensagem:</label>
            <textarea id="mensagem" name="mensagem" rows="4" cols="50"></textarea>
        </div>
        <div>
            <input type="submit" value="Enviar">
        </div>
    </form>    
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExibirExcecoes.aspx.cs" Inherits="WebApplicationFATEC.ExibirExcecoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="margin-top-60">
        <h2>Excecoes da aplicação</h2>
        <hr />
        <br />
        <asp:Label ID="Excecoes" runat="server"></asp:Label>
    </div>



</asp:Content>

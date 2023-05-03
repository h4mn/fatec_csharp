<%@ Page Title="Contato" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="site.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label>
        <asp:TextBox ID="edtNome" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="edtEmail" runat="server"></asp:TextBox>
    </div>
    <%--<div>--%>
        <asp:Label ID="txtMensagem" runat="server" Text="Mensagem"></asp:Label>
        <asp:TextBox ID="edtMensagem" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click"/>
    </div>    
</asp:Content>
    
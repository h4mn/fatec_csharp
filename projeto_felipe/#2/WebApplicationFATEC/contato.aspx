<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="contato.aspx.cs" Inherits="WebApplicationFATEC.contato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div style="width:400px" class="col-6">
            
            
            <asp:Label ID="Mensagem" runat="server" Font-Size="20px" ForeColor="Red"></asp:Label>
            <br />
            <br />

            <label>Nome</label><br />
            <asp:TextBox ID="NomeCompleto" MaxLength="60" runat="server"></asp:TextBox>
            <br />

            <label>Email</label><br />
            <asp:TextBox ID="Email" MaxiLength="255" TextMode="Email" runat="server"></asp:TextBox>
            <br />

            <label>Mensagem</label><br />
            <asp:TextBox ID="Observacoes" MaxiLength="255" TextMode="MultiLine" Rows="6" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Button ID="Enviar" OnClick="Enviar_Click" runat="server" Text="Enviar" />
                
        </div>
        <dvi class="col-6">
            MAPA

        </dvi>


    </div>
   
</asp:Content>

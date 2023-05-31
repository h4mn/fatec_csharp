<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CadastroUsuarios.aspx.cs" Inherits="WebApplicationFATEC.Admin.CadastroUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margin-top-60">
        <div class="row">
            <!-- CADASTRO -->
            <div class="col-6">
                <div class="box margin-right-20 border">
                    <h2>Cadastro de Usuario</h2>
                    <br />
                    <asp:Label ID="MsgError" runat="server" Text=""></asp:Label>
                    <br />
                    
                    <asp:Label ID="Codigo" Font-Size="20px" runat="server" ></asp:Label>

                    <label>Nome Completo</label>
                    <asp:TextBox ID="NomeCompleto" runat="server"></asp:TextBox>

                    <label>Email</label>
                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>

                    <label>Nome Acesso</label>
                    <asp:TextBox ID="NomeAcesso" runat="server"></asp:TextBox>

                    <label>Senha</label>
                    <asp:TextBox ID="Senha"  TextMode="Password" runat="server"></asp:TextBox>

                    <label>Anotacoes</label>
                    <asp:TextBox ID="Anotacoes" TextMode="MultiLine" Rows="6" runat="server"></asp:TextBox>

                    <asp:Button ID="Inserir" OnClick="Inserir_Click" runat="server" Text="Inserir" />

                    <asp:Button ID="Excluir" CssClass="botao-delete" Visible="false" OnClick="Excluir_Click"  runat="server" Text="Deletar" />
                </div>
            </div>
            <!-- GRID -->
            <div class="col-6">
                <div class="box border">
                    <asp:GridView ID="ViewUsuarios" AutoGenerateColumns="true" Width="100%" CellPadding="6" AutoGenerateSelectButton="true" OnSelectedIndexChanged="ViewUsuarios_SelectedIndexChanged" runat="server"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

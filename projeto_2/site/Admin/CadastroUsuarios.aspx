<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroUsuarios.aspx.cs" Inherits="site.Admin.CadastroUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="margin-top-60">
        <!-- O layout tem duas colunas, na primeira coluna o formulário para cadastrar o usuário, na segunda coluna uma grid com os usuários já cadastrados -->
        <div class="row">
            <!-- Coluna do formulário -->
            <div class="col-6">
                <div class="box margin-right-20 border">
                    <!-- Campos: Nome Completo, Email, NomeAcesso, Anotacoes, Senha -->
                    <h2>Cadastro de Usuários</h2>
                    <br />
                    <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="lblNomeCompleto" runat="server" Text="Nome Completo"></asp:Label>
                    <asp:TextBox ID="txtNomeCompleto" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblNomeAcesso" runat="server" Text="Nome de Acesso"></asp:Label>
                    <asp:TextBox ID="txtNomeAcesso" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label>
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblAnotacoes" runat="server" Text="Anotações"></asp:Label>
                    <asp:TextBox ID="txtAnotacoes" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSalvar" runat="server" Text="Inserir" CssClass="btn btn-primary" OnClick="btnInserir_Click" />
                </div>
            </div>
            <!-- Coluna da grid -->
            <div class="col-6">
                <!-- teacher sugestion: <div class="box border"></div> -->
                <div class="box margin-left-20 border">
                    <asp:GridView ID="ViewUsuarios" AutoGenerateColumns="true" AutoGenerateSelectButton="true" OnSelectIndexChanged="ViewUsuario_SelectedIndexChanged" runat="server"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="fatec_csharp._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Aula 03</title>
</head>
<body>
    <form id="Form_Cadastro" runat="server">
        <div style="margin-left:60px; padding:20px; border: 1px solid #c0c0c0;">
            <h2>Cadastro de Cliente</h2>
            <br />
            <asp:Label ID="Lbl_Mensagem" runat="server" Text="Mensagem" Font-Size="20px" ForeColor="Red"></asp:Label>
            <br />

            <br />

            <!-- Teste de conexão /-->
            <label>Nome Completo</label><br />
            <asp:TextBox ID="TxtBox_NomeCompleto" runat="server" MaxLength="50"></asp:TextBox>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource1" EmptyDataText="Não há registros de dados a serem exibidos.">
                <Columns>
                    <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
                </Columns>
            </asp:GridView>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="App_Data\dados.accdb" SelectCommand="SELECT `nome` FROM `usuarios`"></asp:AccessDataSource>
            <br />


            <label>E-mail</label><br />
            <asp:TextBox ID="TxtBox_Email" runat="server" MaxLength="255" TextMode="Email"></asp:TextBox>
            <br />

            <label>Telefone</label><br />
            <asp:TextBox ID="TxtBox_Telefone" runat="server" MaxLength="15" TextMode="Phone"></asp:TextBox>
            <br />

            <label>Data Nascimento</label><br />
            <asp:TextBox ID="TxtBox_Nascimento" runat="server" MaxLength="30" TextMode="Date"></asp:TextBox>
            <br />

            <label>Sexo</label><br />
            <asp:RadioButtonList ID="RadioBtnList_Sexo" runat="server">
                <asp:ListItem Text="Feminino" Value="0" />
                <asp:ListItem Text="Masculino" Value="1" />
            </asp:RadioButtonList>
            <br />

            <label>Atividade</label><br />
            <asp:DropDownList ID="DropDownList_Atividade" runat="server">
                <asp:ListItem Text="Selecione" Value="0" />
                <asp:ListItem Text="Gerente" Value="1" />
                <asp:ListItem Text="Supervisor" Value="2" />
                <asp:ListItem Text="Compras" Value="3" />
                <asp:ListItem Text="RH" Value="4" />
            </asp:DropDownList>
            <br />

            <label>Num. Funcionários</label><br />
            <asp:TextBox ID="TextBox_NumFuncionarios" runat="server" MaxLength="5" TextMode="Number"></asp:TextBox>
            <br />

            <label>Observações</label><br />
            <asp:TextBox ID="TextBox_Observacoes" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
            <br />

            <!-- <asp:Button ID="Button_Enviar" runat="server" Text="Enviar" OnClick="Page_Load"/> /-->
            <asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="OnClick_Enviar"/>

            <asp:Button ID="Button2" runat="server" Text="Excluir" OnClick="OnClick_Excluir"/>



        </div>
    </form>
</body>
</html>

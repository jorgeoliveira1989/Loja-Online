<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalho_rodapé.Master" AutoEventWireup="true" CodeBehind="carrinho.aspx.cs" Inherits="loja_online.carrinho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Carrinho de Compras</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="form1" runat="server">
        <div>
            <asp:Repeater ID="rptCarrinho" runat="server">
                <ItemTemplate>
                    <div>
                        <h3><%# Eval("produto") %></h3>
                        <p>Preço: <%# Eval("preco", "{0:C}") %></p>
                        <p>Quantidade: <asp:TextBox ID="txtQuantidade" runat="server" Text='<%# Eval("Quantidade") %>'></asp:TextBox></p>
                        <asp:Button ID="btnSubtrair" runat="server" Text="Subtrair" CommandName="Subtrair" CommandArgument='<%# Container.ItemIndex %>' />
                        <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" CommandName="Adicionar" CommandArgument='<%# Container.ItemIndex %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>

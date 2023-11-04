<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalho_rodapé.Master" AutoEventWireup="true" CodeBehind="carrinho.aspx.cs" Inherits="loja_online.carrinho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Carrinho de Compras</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="form1" runat="server" class="container mt-5">
    <asp:Repeater ID="rptCarrinho" runat="server" OnItemCommand="rptCarrinho_ItemCommand">
        <ItemTemplate>
            <!-- Card para cada item no carrinho -->
            <div class="card mb-3">
                <div class="row g-0">
                    <div class="col-md-4">
                        <asp:Image ID="foto_produto" runat="server" ImageUrl='<%# Eval("imagemSrc") %>' AlternateText="Pré-visualização" CssClass="img-fluid" />
                    </div>
                    <div class="col-md-8">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("produto") %></h5>
                            <p class="card-text">Preço: <%# Eval("preco", "{0:C}") %></p>
                            <div class="input-group">
                                <asp:TextBox ID="txtQuantidade" runat="server" Text='<%# Eval("Quantidade") %>' CssClass="form-control" />
                                <span class="input-group-btn">
                                    <asp:Button ID="btnSubtrair" runat="server" Text="-" CommandName="Subtrair" CommandArgument='<%# Container.ItemIndex %>' CssClass="btn btn-outline-danger" />
                                </span>
                                <span class="input-group-btn">
                                    <asp:Button ID="btnAdicionar" runat="server" Text="+" CommandName="Adicionar" CommandArgument='<%# Container.ItemIndex %>' CssClass="btn btn-outline-success" />
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <!-- Resumo da Encomenda -->
    <div class="card mt-3 float-right">
    <div class="card-body">
        <h5 class="card-title">Resumo da Encomenda</h5>
        <p class="card-text"><%= CalcularTotalArtigos() %> artigos</p>
        <hr>
        <p class="card-text">Valor Total:</p>
        <asp:Label ID="lbl_valor" runat="server" Font-Size="Large" ForeColor="Black" Font-Bold="true"></asp:Label>
        <hr>
        <asp:Button ID="btnFinalizarEncomenda" runat="server" Text="Finalizar Encomenda" CssClass="btn btn-danger" />
    </div>
</div>
</div>

</asp:Content>

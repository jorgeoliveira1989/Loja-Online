<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalho_rodapé.Master" AutoEventWireup="true" CodeBehind="zzzzz-apagar-index.aspx.cs" Inherits="loja_online.index1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        #productContainer {
        display: flex;
        flex-wrap: wrap;
        }

    .productCard {
        display: flex;
        flex-direction: column;
        height: 100%;
    }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div id="meuCarrossel" class="carousel slide w-100 h-700" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="image/image1.jpg" alt="Imagem 1" class="w-100">
                </div>
                <div class="carousel-item">
                    <img src="image/image2.jpg" alt="Imagem 2" class="w-100">
                </div>
                <div class="carousel-item">
                    <img src="image/image3.jpg" alt="Imagem 3" class="w-100">
                </div>
            </div>
            <a class="carousel-control-prev" href="#meuCarrossel" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Anterior</span>
            </a>
            <a class="carousel-control-next" href="#meuCarrossel" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Próximo</span>
            </a>
        </div>

        <div class="bg-white text-center py-4">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 mb-4">
                        <div class="bg-dark p-4 rounded text-white">
                            <img src="image/entrega-rapida.png" alt="Logo 1" class="mb-3" width="50">
                            <p><b>Envio Grátis Portugal Continental</b></p>
                        </div>
                    </div>
                    <div class="col-md-3 mb-4">
                        <div class="bg-dark p-4 rounded text-white">
                            <img src="image/escudo.png" alt="Logo 2" class="mb-3" width="50">
                            <p><b>Garantia de 30 dias</b></p>
                        </div>
                    </div>
                    <div class="col-md-3 mb-4">
                        <div class="bg-dark p-4 rounded text-white">
                            <img src="image/customer-support.png" alt="Logo 3" class="mb-3" width="50">
                            <p><b>Suporte Especializado</b></p>
                        </div>
                    </div>
                    <div class="col-md-3 mb-4">
                        <div class="bg-dark p-4 rounded text-white">
                            <img src="image/relogio.png" alt="Logo 4" class="mb-3" width="50">
                            <p><b>Entrega Rápida</b></p>
                        </div>
                    </div>
            </div>
        </div>
    </div>
    
<div id="form1" runat="server">
    <div class="container text-center">
        <h1 style="color: rgb(255, 0, 0); font-weight: bold;">Produtos</h1>
                <label __designer:mapid="196">
                <b>Ordenar:</b> <asp:DropDownList ID="ddl_opcoes" runat="server" AutoPostBack="True">
                    <asp:ListItem>-----------------</asp:ListItem>
                    <asp:ListItem>Nome Produto</asp:ListItem>
                    <asp:ListItem>Preço Ascendente</asp:ListItem>
                    <asp:ListItem>Preço Descendente</asp:ListItem>
                </asp:DropDownList>
                </label>
            <br />
        <br />
        <div class="row" id="productContainer">
            <asp:Repeater ID="rptProdutos" runat="server">
                <ItemTemplate>
                    <div class="col-md-3 mb-4 productCard">
                        <div class="card">
                            <asp:Image ID="foto_produto" runat="server" ImageUrl='<%# Eval("imagemSrc") %>' AlternateText="Pré-visualização" />
                            <div class="card-body">
                                <h4 class="card-title"><b><%# Eval("produto") %></b></h4>
                                <p class="card-text"><%# Eval("designacao") %></p>
                                <p class="card-text">Preço: <%# Eval("preco", "{0:C}") %></p>
                                <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" CssClass="btn btn-danger btn-lg" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
 </div>  

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.9/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>

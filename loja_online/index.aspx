<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalho_rodapé.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="loja_online.index1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div id="meuCarrossel" class="carousel slide w-100 h-700" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="image/imagem%201920x600.jpg" alt="Imagem 1" class="w-100">
                </div>
                <div class="carousel-item">
                    <img src="imagem2.jpg" alt="Imagem 2" class="w-100">
                </div>
                <div class="carousel-item">
                    <img src="imagem3.jpg" alt="Imagem 3" class="w-100">
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
<div class="container mt-5">
    <div class="row">
        <!-- Produto 1 -->
        <div class="col-md-3 mb-4">
            <div class="card text-center">
                <img src="produto1.jpg" class="card-img-top" alt="Produto 1">
                <div class="card-body">
                    <h5 class="card-title">Descrição do Produto 1</h5>
                    <p class="card-text">
                        Preço: <strong class="text-danger">XX,XX€</strong>
                    </p>
                    <a href="produto1.html" class="btn btn-danger">Ver Produto</a>
                </div>
            </div>
        </div>
   <!-- Produto 2 -->
        <div class="col-md-3 mb-4">
            <div class="card text-center">
                <img src="produto2.jpg" class="card-img-top" alt="Produto 2">
                <div class="card-body">
                    <h5 class="card-title">Descrição do Produto 2</h5>
                    <p class="card-text">
                        Preço: <strong class="text-danger">XX,XX€</strong>
                    </p>
                    <a href="produto2.html" class="btn btn-danger">Ver Produto</a>
                </div>
            </div>
        </div>

        <!-- Produto 3 -->
        <div class="col-md-3 mb-4">
            <div class="card text-center">
                <img src="produto3.jpg" class="card-img-top" alt="Produto 3">
                <div class="card-body">
                    <h5 class="card-title">Descrição do Produto 3</h5>
                    <p class="card-text">
                        Preço: <strong class="text-danger">XX,XX€</strong>
                    </p>
                    <a href="produto3.html" class="btn btn-danger">Ver Produto</a>
                </div>
            </div>
        </div>

        <!-- Produto 4 -->
        <div class="col-md-3 mb-4">
            <div class="card text-center">
                <img src="produto4.jpg" class="card-img-top" alt="Produto 4">
                <div class="card-body">
                    <h5 class="card-title">Descrição do Produto 4</h5>
                    <p class="card-text">
                        Preço: <strong class="text-danger">XX,XX€</strong>
                    </p>
                    <a href="produto4.html" class="btn btn-danger">Ver Produto</a>
                </div>
            </div>
        </div>

        <!-- Produto 5 -->
        <div class="col-md-3 mb-4">
            <div class="card text-center">
                <img src="produto5.jpg" class="card-img-top" alt="Produto 5">
                <div class="card-body">
                    <h5 class="card-title">Descrição do Produto 5</h5>
                    <p class="card-text">
                        Preço: <strong class="text-danger">XX,XX€</strong>
                    </p>
                    <a href="produto5.html" class="btn btn-danger">Ver Produto</a>
                </div>
            </div>
        </div>

        <!-- Produto 6 -->
        <div class="col-md-3 mb-4">
            <div class="card text-center">
                <img src="produto6.jpg" class="card-img-top" alt="Produto 6">
                <div class="card-body">
                    <h5 class="card-title">Descrição do Produto 6</h5>
                    <p class="card-text">
                        Preço: <strong class="text-danger">XX,XX€</strong>
                    </p>
                    <a href="produto6.html" class="btn btn-danger">Ver Produto</a>
                </div>
            </div>
        </div>

        <!-- Produto 7 -->
        <div class="col-md-3 mb-4">
            <div class="card text-center">
                <img src="produto7.jpg" class="card-img-top" alt="Produto 7">
                <div class="card-body">
                    <h5 class="card-title">Descrição do Produto 7</h5>
                    <p class="card-text">
                        Preço: <strong class="text-danger">XX,XX€</strong>
                    </p>
                    <a href="produto7.html" class="btn btn-danger">Ver Produto</a>
                </div>
            </div>
        </div>

        <!-- Produto 8 -->
        <div class="col-md-3 mb-4">
            <div class="card text-center">
                <img src="produto8.jpg" class="card-img-top" alt="Produto 8">
                <div class="card-body">
                    <h5 class="card-title">Descrição do Produto 8</h5>
                    <p class="card-text">
                        Preço: <strong class="text-danger">XX,XX€</strong>
                    </p>
                    <a href="produto8.html" class="btn btn-danger">Ver Produto</a>
                </div>
            </div>
        </div>
    </div>
</div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.9/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>

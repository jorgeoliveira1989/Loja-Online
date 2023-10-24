<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index1.aspx.cs" Inherits="loja_online.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .whatsapp-icon {
            color: #FF0000; /* Vermelho */
        }
        .custom-link {
            color: black; /* Define a cor do texto como preto */
            text-decoration: none; /* Remove o sublinhado */
            font-size: 1.2em; /* Define o tamanho da fonte (ajuste conforme necessário) */
        }
        #meuCarrossel {
            width: 100%;
            max-width: none;
            height: 600px;
        }
    </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/all.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="bg-dark p-3">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex justify-content-between align-items-center">
                            <!-- Ícones de redes sociais na esquerda -->
                            <div class="d-flex">
                                <a href="#" class="ms-2"><i class="fab fa-facebook fa-2x text-white"></i></a>
                                <a href="#" class="ms-2"><i class="fab fa-twitter fa-2x text-white"></i></a>
                            </div>

                            <!-- Caixa de pesquisa centralizada -->
                            <div class="input-group mb-3" style="max-width: 500px; margin: 0 auto;">
                                <asp:TextBox ID="text" runat="server" CssClass="form-control" placeholder="Pesquisar produtos"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Button ID="btn_procurar" runat="server" Text="Pesquisar" CssClass="btn btn-danger" />
                                </div>
                            </div>

                            <!-- Botão de Login/Minha Conta -->
                            <a href="login.aspx" class="btn btn-link text-white text-decoration-none">
                                <i class="fas fa-user fa-2x me-2 whatsapp-icon"></i>Login/Minha Conta
                            </a>

                            <!-- Ícone do WhatsApp e número de telefone -->
                            <div class="d-flex align-items-center">
                                <i class="fab fa-whatsapp fa-2x whatsapp-icon me-2"></i>
                                <label class="mb-0 text-white">910000000</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="bg-gray text-center py-3 h-105">
            <a href="pagina1.html" class="mx-3 custom-link">Opção 1</a>
            <a href="pagina2.html" class="mx-3 custom-link">Opção 2</a>
            <a href="pagina3.html" class="mx-3 custom-link">Opção 3</a>
            <a href="pagina4.html" class="mx-3 custom-link">Opção 4</a>
            <a href="pagina5.html" class="mx-3 custom-link">0,00 <i class="fas fa-euro-sign"></i></a>
            <a href="pagina6.html" class="mx-3 custom-link"><i class="fas fa-shopping-cart"></i></a>
        </div>

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
</form>
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.9/dist/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
